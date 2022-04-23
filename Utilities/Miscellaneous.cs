using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HobbyTeamManager.Utilities;

public class Miscellaneous
{
    public static bool IsMailAddressCorrect(string mail)
    {
        try
        {
            var email = new MailAddress(mail);
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine("FEHLER: {0} / Art: {1}", e.Message, e.GetType());
            return false;
        }
    }

    /// <summary>
    /// Does the provided password fit to the rules:
    /// [1] minimum 8 characters
    /// [2] minimum 1 capital letter, 1 lower case letter, 1 number
    /// [3] minimum 1 special character from ",.-+;:_!§$"
    /// </summary>
    /// <param name="password">string</param>
    /// <returns>true or false if fits or not</returns>
    public static bool DoesPasswordFitRules(string password)
    {
        if (password.Length < 8)
            return false;

        var hasNumbers = new Regex(@"[0-9]+");
        var hasCapitalLetters = new Regex(@"[A-Z]+");
        var hasLowerCaseLetters = new Regex(@"[a-z]+");
        var hasSpecialCharacters = new Regex(@"[,.+-;:_!§$]+");

        return hasNumbers.IsMatch(password)
            && hasCapitalLetters.IsMatch(password)
            && hasLowerCaseLetters.IsMatch(password)
            && hasSpecialCharacters.IsMatch(password);
    }

    public static SelectList PopulateDropDownList(IEnumerable collection,
        string value, string data, object? selectedItem = null)
    {
        return new SelectList(collection, value, data, selectedItem);
    }

    public static void SetSessionStringFromObject<T>(T t, HttpContext context)
        where T : class
    {
        if (t == null)
            throw new ArgumentNullException(nameof(t));

        context.Session.SetString(typeof(T).Name, JsonConvert.SerializeObject(t));
    }

    public static T? GetObjectFromSessionString<T>(HttpContext context)
        where T : class
    {
        string t = typeof(T).Name;
        var s = context.Session.GetString(t);
        if (s == null)
            return null;

        return JsonConvert.DeserializeObject<T>(s);
    }
}
