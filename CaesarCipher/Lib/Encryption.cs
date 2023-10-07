using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.Lib
{
    public class Encryption
    {
        public char[] LettersTable { get; }

        public Encryption(char[] lettersTable)
        {
            LettersTable = lettersTable;
        }

        public void Encrypt(string text, int move, ref string cryptogram)
        {
            var letters = text.Where(l => char.IsLetter(l) || char.IsNumber(l)).ToArray();
            var encryptedText = new char[text.Length];

            for (int i = 0; i < letters.Length; i++)
            {
                encryptedText[i] = LettersTable[(Array.IndexOf(LettersTable, letters[i]) + move) % LettersTable.Length];
            }

            cryptogram = new string(encryptedText);
        }
    }
}
