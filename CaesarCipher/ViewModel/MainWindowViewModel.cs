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
        public char[] PolishLetters = new char[] 
        { 
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n',
            'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż', 'ą'
        };

        public MainWindowViewModel()
        {

        }

        private string _textToEncryption;
        public string TextToEncryption
        {
            get { return _textToEncryption; }
            set 
            {
                _textToEncryption = value;
                Encryption(value.ToLower(), NumberOfMoveEncryption);
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

        private int _numberOfMoveEncryption;
        public int NumberOfMoveEncryption
        {
            get { return _numberOfMoveEncryption; }
            set
            {
                _numberOfMoveEncryption = value;
                Encryption(TextToEncryption.ToLower(), value);
                OnPropertyChanged();
            }
        }

        void Encryption(string text, int move)
        {
            var letters = text.ToCharArray();
            var encryptedText = new char[text.Length];

            for(int i = 0; i < letters.Length; i++)
            {
                encryptedText[i] = PolishLetters[(Array.IndexOf(PolishLetters, letters[i]) + move) % 34];
            }

            CryptogramText = new string(encryptedText);
        }

        void Decryption(string text, int move)
        {
            var letters = text.ToCharArray();
            var encryptedText = new char[text.Length];

            for (int i = 0; i < letters.Length; i++)
            {
                encryptedText[i] = PolishLetters[(Array.IndexOf(PolishLetters, letters[i]) - move) % 34];
            }

            CryptogramText = new string(encryptedText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
