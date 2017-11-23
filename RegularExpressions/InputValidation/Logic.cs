using System.Text.RegularExpressions;

namespace InputValidation
{
    public class Logic
    {

        public static bool checkName(string name)
        {
            bool result = true;
            if (!Regex.IsMatch(name, @"^([A-Za-z]*\s*)+$")) result = false;
            return result;
        }

        public static bool checkPhone(string phone)
        {
            bool result = true;
            if (!Regex.IsMatch(phone, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$")) result = false;
            return result;
        }

        public static bool checkEmail(string email)
        {
            bool result = true;
            if (!Regex.IsMatch(email, @"^[^@]+@((\w|-)+\.)*[a-z]+$")) result = false;
            return result;
        }
    }
}
