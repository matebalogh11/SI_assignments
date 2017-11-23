using System.Text.RegularExpressions;

namespace InputValidation
{
    public class Logic
    {

        public static bool CheckName(string name)
        {
            bool result = true;
            if (!Regex.IsMatch(name, @"^([A-Za-z]*\s*)+$")) result = false;
            return result;
        }

        public static bool CheckPhone(string phone)
        {
            bool result = true;
            if (!Regex.IsMatch(phone, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$")) result = false;
            return result;
        }

        public static bool CheckEmail(string email)
        {
            bool result = true;
            if (!Regex.IsMatch(email, @"^[^@]+@((\w|-)+\.)*[a-z]+$")) result = false;
            return result;
        }

        public static string ReformatPhone(string number)
        {
            Match m = Regex.Match(number, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return string.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }
    }
}
