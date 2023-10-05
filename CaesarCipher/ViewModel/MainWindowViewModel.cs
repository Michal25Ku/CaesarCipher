using CaesarCipher.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public Encryption encryption { get; }
        private string _textToEncrypt = "";

        public char[] PolishLetters = new char[] 
        { 
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n',
            'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public MainWindowViewModel()
        {
            encryption = new Encryption(PolishLetters);
        }

        private string _textToEncryption;
        public string TextToEncryption
        {
            get { return _textToEncryption; }
            set 
            {
                _textToEncryption = value;
                encryption.Encrypt(value.ToLower(), 2, ref _textToEncrypt);
                CryptogramText = _textToEncrypt;
                OnPropertyChanged();
            }
        }
        
        private string _cryptogramText;
        public string CryptogramText
        {
            get { return _cryptogramText; }
            set 
            {
                _cryptogramText = value;
                OnPropertyChanged();
            }
        }
        //--------------------------------------------

        //private int _numberOfMoveEncryption;
        //public int NumberOfMoveEncryption
        //{
        //    get { return _numberOfMoveEncryption; }
        //    set
        //    {
        //        _numberOfMoveEncryption = value;
        //        Encryption(TextToEncryption.ToLower(), 2);
        //        OnPropertyChanged();
        //    }
        //}

        //void Decryption(string text, int move)
        //{
        //    var letters = text.ToCharArray();
        //    var encryptedText = new char[text.Length];

        //    for (int i = 0; i < letters.Length; i++)
        //    {
        //        encryptedText[i] = PolishLetters[(Array.IndexOf(PolishLetters, letters[i]) - move) % PolishLetters.Length];
        //    }

        //    CryptogramText = new string(encryptedText);
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
