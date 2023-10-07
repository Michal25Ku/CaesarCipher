using CaesarCipher.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaeserCipher
{
    public class DecryptionUnitTests
    {
        public char[] PolishLetters = new char[]
        {
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n',
            'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        [TestMethod]
        public void ConstructorTest_Decyprion_ShouldPolishLettersTableAssignToLettersTable()
        {
            var decrypt = new Decryption(PolishLetters);

            Assert.AreEqual(PolishLetters, decrypt.LettersTable);
        }

        [TestMethod]
        public void TestDecryptMethod_RandomTextWithoutMove_ShouldReturnThisRandomText()
        {
            var decrypt = new Decryption(PolishLetters);
            string randomTestText = "This is a random test text";
            string explicitText = string.Empty;
            decrypt.Decrypt(randomTestText, 0, ref explicitText);

            Assert.AreEqual(randomTestText, explicitText);
        }

        [DataTestMethod]
        [DataRow(1, "uęyu234")]
        [DataRow(2, "vfzv345")]
        [DataRow(3, "wgźw456")]
        public void TestDecryptMethod_RandomTextWithMove_ShouldReturnCryptogramTextAfterMove(int move, string encryptText)
        {
            var decrypt = new Decryption(PolishLetters);
            string result = "text123";
            string explicitText = string.Empty;
            decrypt.Decrypt(encryptText, move, ref explicitText);

            Assert.AreEqual(result, explicitText);
        }
    }
}
