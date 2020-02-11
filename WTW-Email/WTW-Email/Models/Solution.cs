using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace WTW_Email.Models
{
    public class Solution
    {
        public int NumberOfUniqueEmailAddresses(string[] emails)
        {
            var normalizedEmails = new List<string>();
            foreach (var email in emails)
            {
                // If email is valid, run checks
                // Otherwise, skip and move to next string
                if (IsValidEmail(email))
                {
                    // Split the email at the @
                    var splitEmail = email.ToLower().Split('@');

                    // Use a regular expression to replace all '.' or anything that comes after '+' (including the +) with an empty string
                    // Add this "normalized" email to a list of string
                    normalizedEmails.Add($"{Regex.Replace(splitEmail[0], @"(\.)|(\+.*)", "")}@{splitEmail[1]}");
                }
            }

            // Return the count of a distinct list of normalized email addresses
            return normalizedEmails.Distinct().Count();
        }

        #region Private Methods
        private bool IsValidEmail(string email)
        {
            // EmailAddressAttribute is a .NET Core Class
            // Using this to check the string before it even makes it to email logic
            return new EmailAddressAttribute().IsValid(email);
        }
        #endregion
    }
}