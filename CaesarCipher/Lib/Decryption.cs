using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.Lib
{
    public class Decryption
    {
        public char[] LettersTable { get; }

        public Decryption(char[] lettersTable)
        {
            LettersTable = lettersTable;
        }

        public void Decrypt(string text, int move, ref string explicitText)
        {
            var letters = text.Where(l => char.IsLetter(l) || char.IsNumber(l)).ToArray();
            var decryptedText = new char[text.Length];

            for (int i = 0; i < letters.Length; i++)
            {
                decryptedText[i] = LettersTable[(Array.IndexOf(LettersTable, letters[i]) + LettersTable.Length - move) % LettersTable.Length];
            }

            explicitText = new string(decryptedText);
        }
    }
}
