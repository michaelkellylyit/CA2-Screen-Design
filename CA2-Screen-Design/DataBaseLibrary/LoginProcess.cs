using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class LoginProcess
    {
        /// <summary>
        /// Validates user credentials against those in the database.
        /// </summary>
        /// <param name="username"></param>
        /// Username entered by user.
        /// <param name="password"></param>
        /// Password entered by user.
        /// <returns>
        /// Validated user.
        /// </returns>
        public bool ValidatedUserInput(string username, string password)
        {
            bool validated = true;
            try
            {
                if (username.Length == 0 || username.Length > 30)
                {
                    validated = false;
                }
                // Check each character of username for a number
                // System does not allow numbers in username
                foreach (char ch in username)
                {
                    if (ch >= '0' && ch <= '9'|| ch == '-')
                    {
                        validated = false;
                    }
                }
                // Password is required
                // Must be under 30 characters
                if (password.Length == 0 || password.Length > 30)
                {
                    validated = false;
                }
            }
            catch (Exception)
            {
                validated = false;

            }
            return validated;
        }

        public bool ValidatedUserInput(object username)
        {
            throw new NotImplementedException();
        }
    }
}
