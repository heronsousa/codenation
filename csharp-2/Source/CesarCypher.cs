using System;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            if (message==null)
            {
                throw new ArgumentNullException();
            }

            string alphabet = this.alphabet();
            string cryptedMessage = "";

            foreach (char letter in message.ToLower())
            {
                if (alphabet.Contains(letter))
                {
                    cryptedMessage += alphabet[(alphabet.IndexOf(letter) + 3) % 26];
                }
                else if (char.IsDigit(letter) || char.IsWhiteSpace(letter))
                {
                    cryptedMessage += letter;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return cryptedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
            {
                throw new ArgumentNullException();
            }

            string alphabet = this.alphabet();
            string message = "";

            foreach (char letter in cryptedMessage.ToLower())
            {
                if (alphabet.Contains(letter))
                {
                    var pos = alphabet.IndexOf(letter) - 3;
                    message += alphabet[(pos < 0 ? pos + 26 : pos)];
                }
                else if (char.IsDigit(letter) || char.IsWhiteSpace(letter))
                {
                    message += letter;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return message;
        }

        public string alphabet()
        {
            var values = Enumerable.Range('a', 26).Select(x => (char)x);
            return string.Join("", values);
        }
    }
}
