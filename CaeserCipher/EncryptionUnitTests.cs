using CaesarCipher;
using CaesarCipher.Lib;

namespace CaeserCipher
{
    [TestClass]
    public class EncryptionUnitTests
    {
        public char[] PolishLetters = new char[]
        {
            'a', '�', 'b', 'c', '�', 'd', 'e', '�', 'f', 'g', 'h', 'i', 'j', 'k', 'l', '�', 'm', 'n',
            '�', 'o', '�', 'p', 'q', 'r', 's', '�', 't', 'u', 'v', 'w', 'x', 'y', 'z', '�', '�',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        [TestMethod]
        public void ConstructorTest_Ecryption_ShouldPolishLettersTableAssignToLettersTable()
        {
            var encrypt = new Encryption(PolishLetters);

            Assert.AreEqual(PolishLetters, encrypt.LettersTable);
        }

        [TestMethod]
        public void TestEncryptmMethod_RandomTextWithoutMove_ShouldReturnThisRandomText()
        {
            var encrypt = new Encryption(PolishLetters);
            string randomTestText = "This is a random test text";
            string cryptogram = string.Empty;
            encrypt.Encrypt(randomTestText, 0, ref cryptogram);

            Assert.AreEqual(randomTestText, cryptogram);
        }

        [DataTestMethod]
        [DataRow (1, "u�yu234")]
        [DataRow (2, "vfzv345")]
        [DataRow (3, "wg�w456")]
        public void TestEncryptmMethod_RandomTextWithMove_ShouldReturnCryptogramTextAfterMove(int move, string encryptText)
        {
            var encrypt = new Encryption(PolishLetters);
            string randomTestText = "text123";
            string cryptogram = string.Empty;
            encrypt.Encrypt(randomTestText, move, ref cryptogram);

            Assert.AreEqual(encryptText, cryptogram);
        }
    }
}