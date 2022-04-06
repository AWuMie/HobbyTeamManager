namespace MySqlTestRazor.Models;

public class Password
{
    public int Id { get; set; }

    public int Salt { get; set; }

    public byte[]? Hash { get; set; }
}
