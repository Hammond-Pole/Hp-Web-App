using System.Text.RegularExpressions;

namespace Hp_Web_App.Shared.Functions;

public interface IHelperFunctions
{
    string ConvertPascalCaseToSpaced(string input);
}

public class HelperFunctions : IHelperFunctions
{
    public string ConvertPascalCaseToSpaced(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return Regex.Replace(input, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ").Trim();
    }
}