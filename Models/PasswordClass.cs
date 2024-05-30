namespace AfriEnergy_ST10146835.Models
{
    public class PasswordClass
    {
        public static string PasswordEncrypt { get; set; }

        public static string SetPassword(string password)
        {

            PasswordEncrypt = Encrypt(password, 3);
            return PasswordEncrypt;
        }

        public static string Encrypt(string plainText, int shift)
        {
            string encryptedText = "";

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(c + shift);
                    if ((char.IsLower(c) && encryptedChar > 'z') || (char.IsUpper(c) && encryptedChar > 'Z'))
                    {
                        encryptedChar = (char)(c - (26 - shift));
                    }
                    encryptedText += encryptedChar;
                }
                else
                {
                    encryptedText += c; // Keep non-letter characters unchanged
                }
            }

            return encryptedText;
        }

        public static string Decrypt(string PasswordText, int shift)
        {
            return Encrypt(PasswordText, -shift);
        }

        public static bool VerifyPassword(string password, string userpassword)
        {
            bool val = false;
            string uPasswords = Decrypt(userpassword, 3);
            if (password == uPasswords)
            {
                val = true;
            }
            return val;
        }

    }
}
