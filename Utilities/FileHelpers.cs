using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;

namespace HobbyTeamManager.Utilities
{
    /////////////////////////////////////////////
    // https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/models/file-uploads/samples/3.x/SampleApp/Utilities/FileHelpers.cs
    /////////////////////////////////////////////

    public static class FileHelpers
    {
        private static string[] _permittedExtensions = { ".png", ".jpg", ".jpeg" };

        public static string[] PermittedExtensions
        {
            get { return _permittedExtensions; }
            private set { _permittedExtensions = value; }
        }

        public static int MaxFileSize { get; private set; } = 2097152;

        // If you require a check on specific characters in the IsValidFileExtensionAndSignature
        // method, supply the characters in the _allowedChars field.
        // private static readonly byte[] _allowedChars = { };
        
        // For more file signatures, see the File Signatures Database (https://www.filesignatures.net/)
        // and the official specifications for the file types you wish to add.
        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new()
        {
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
        };

        // **WARNING!**
        // In the following file processing methods, the file's content isn't scanned.
        // In most production scenarios, an anti-virus/anti-malware scanner API is
        // used on the file before making the file available to users or other
        // systems. For more information, see the topic that accompanies this sample
        // app.

        public static async Task<byte[]> ProcessFormFile<T>(IFormFile formFile,
            ModelStateDictionary modelState, string[] permittedExtensions,
            long sizeLimit)
        {
            var fieldDisplayName = string.Empty;

            // Use reflection to obtain the display name for the model
            // property associated with this IFormFile. If a display
            // name isn't found, error messages simply won't show
            // a display name.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            MemberInfo property =
                typeof(T).GetProperty(
#pragma warning disable IDE0057 // Use range operator
                    formFile.Name.Substring(formFile.Name.IndexOf(".",
                    StringComparison.Ordinal) + 1));
#pragma warning restore IDE0057 // Use range operator
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (property != null)
            {
                if (property.GetCustomAttribute(typeof(DisplayAttribute)) is
                    DisplayAttribute displayAttribute)
                {
                    fieldDisplayName = $"{displayAttribute.Name} ";
                }
            }

            // Don't trust the file name sent by the client. To display
            // the file name, HTML-encode the value.
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                formFile.FileName);

            // Check the file length. This check doesn't catch files that only have 
            // a BOM as their content.
            if (formFile.Length == 0)
            {
                modelState.AddModelError(formFile.Name,
                    $"{fieldDisplayName}({trustedFileNameForDisplay}) is empty.");

                return Array.Empty<byte>();
            }

            if (formFile.Length > sizeLimit)
            {
                var megabyteSizeLimit = sizeLimit / 1048576;
                modelState.AddModelError(formFile.Name,
                    $"{fieldDisplayName}({trustedFileNameForDisplay}) exceeds " +
                    $"{megabyteSizeLimit:N1} MB.");

                return Array.Empty<byte>();
            }

            try
            {
                using var memoryStream = new MemoryStream();
                await formFile.CopyToAsync(memoryStream);

                // Check the content length in case the file's only
                // content was a BOM and the content is actually
                // empty after removing the BOM.
                if (memoryStream.Length == 0)
                {
                    modelState.AddModelError(formFile.Name,
                        $"{fieldDisplayName}({trustedFileNameForDisplay}) ist leer.");
                }

                if (!IsValidFileExtensionAndSignature(
                    formFile.FileName, memoryStream, permittedExtensions))
                {
                    modelState.AddModelError(formFile.Name,
                        $"{fieldDisplayName}({trustedFileNameForDisplay}) Dateityp " +
                        "ist nicht zulässig oder die Signatur der Datei " +
                        "stimmt nicht mit der Erweiterung der Datei überein.");
                }
                else
                {
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                modelState.AddModelError(formFile.Name,
                    $"{fieldDisplayName}({trustedFileNameForDisplay}) Upload fehlgeschlagen. " +
                    $"Bitte wenden Sie sich an den Helpdesk, um Unterstützung zu erhalten. Fehler: {ex.HResult}");
                // Log the exception
            }

            return Array.Empty<byte>();
        }

        public static async Task<byte[]> ProcessStreamedFile(
            MultipartSection section, ContentDispositionHeaderValue contentDisposition,
            ModelStateDictionary modelState, string[] permittedExtensions, long sizeLimit)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await section.Body.CopyToAsync(memoryStream);

                // Check if the file is empty or exceeds the size limit.
                if (memoryStream.Length == 0)
                {
                    modelState.AddModelError("Datei", "Die Datei ist leer.");
                }
                else if (memoryStream.Length > sizeLimit)
                {
                    var megabyteSizeLimit = sizeLimit / 1048576;
                    modelState.AddModelError("Datei",
                    $"Die Datei ist größer als {megabyteSizeLimit:N1} MB.");
                }
                else if (!IsValidFileExtensionAndSignature(
                    contentDisposition.FileName, memoryStream,
                    permittedExtensions))
                {
                    modelState.AddModelError("Datei",
                        "Der Dateityp ist nicht zulässig oder die Signatur " +
                        "der Datei stimmt nicht mit der Dateierweiterung überein.");
                }
                else
                {
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                modelState.AddModelError("Datei",
                    "Der Upload ist fehlgeschlagen. Bitte kontaktieren Sie den " +
                    $"Helpdesk für Unterstützung. Fehler: { ex.HResult}");

                // Log the exception
            }

            return Array.Empty<byte>();
        }

        private static bool IsValidFileExtensionAndSignature(string? fileName, Stream data, string[] permittedExtensions)
        {
            if (string.IsNullOrEmpty(fileName) || data == null || data.Length == 0)
            {
                return false;
            }

            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return false;
            }

            data.Position = 0;

            using var reader = new BinaryReader(data);
            #region UnNeededExtensions
            // should not be possible as we only want images
            //if (ext.Equals(".txt") || ext.Equals(".csv") || ext.Equals(".prn"))
            //{
            //    if (_allowedChars.Length == 0)
            //    {
            //        // Limits characters to ASCII encoding.
            //        for (var i = 0; i < data.Length; i++)
            //        {
            //            if (reader.ReadByte() > sbyte.MaxValue)
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // Limits characters to ASCII encoding and
            //        // values of the _allowedChars array.
            //        for (var i = 0; i < data.Length; i++)
            //        {
            //            var b = reader.ReadByte();
            //            if (b > sbyte.MaxValue ||
            //                !_allowedChars.Contains(b))
            //            {
            //                return false;
            //            }
            //        }
            //    }

            //    return true;
            //}

            // Uncomment the following code block if you must permit
            // files whose signature isn't provided in the _fileSignature
            // dictionary. We recommend that you add file signatures
            // for files (when possible) for all file types you intend
            // to allow on the system and perform the file signature
            // check.
            /*
            if (!_fileSignature.ContainsKey(ext))
            {
                return true;
            }
            */
            #endregion

            // File signature check
            // --------------------
            // With the file signatures provided in the _fileSignature
            // dictionary, the following code tests the input content's
            // file signature.
            var signatures = _fileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature =>
                headerBytes.Take(signature.Length).SequenceEqual(signature));
        }
    }
}
