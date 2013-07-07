using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ResourcesLibrary;

namespace CommonLibrary
{
    /// <summary>
    /// Class for data validation
    /// </summary>
    /// /// <autor>Evgeny Drapoguz</autor>
    /// <date>24 April 2013</date>
    public static class Validation
    {
        public static bool ValidEmail(string email)
        {
            bool validResult = false;

            if (!string.IsNullOrEmpty(email))
            {
                Regex rgxEmail = new Regex(RegularExpressions.Email, RegexOptions.IgnoreCase);

                validResult = rgxEmail.IsMatch(email);
            }

            return validResult;
        }

        public static bool ValidUsername(string username)
        {
            bool validResult = false;

            if (!string.IsNullOrEmpty(username))
            {
                Regex rgxEmail = new Regex(RegularExpressions.Username, RegexOptions.IgnoreCase);

                validResult = rgxEmail.IsMatch(username);
            }

            return validResult;
        }

        public static bool ValidPassword(string password)
        {
            bool validResult = false;

            if (!string.IsNullOrEmpty(password))
            {
                Regex rgxEmail = new Regex(RegularExpressions.Password);

                validResult = rgxEmail.IsMatch(password);
            }

            return validResult;
        }

        public static bool ValidText(string text, int min = 0, int max = 30)
        {
            bool validResult = false;
            if (text == null) return validResult;

            // if validation text in the range between "min" and "max"
            if (text.Length >= min && text.Length <= max)
            {
                Regex rgxText = new Regex(RegularExpressions.Text);

                validResult = rgxText.IsMatch(text);
            }

            return validResult;
        }

        public static bool ValidTextWithNumbers(string text, int min = 0, int max = 30)
        {
            bool validResult = false;
            if (text == null) return validResult;

            // if validation text in the range between "min" and "max"
            if (text.Length >= min && text.Length <= max)
            {
                Regex rgxText = new Regex(RegularExpressions.TextWithNumbers);

                validResult = rgxText.IsMatch(text);
            }

            return validResult;
        }

    }
}
