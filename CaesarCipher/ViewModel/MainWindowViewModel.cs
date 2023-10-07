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
        public Decryption decryption { get; }
        private string _textToEncrypt = "";
        private string _textToDecrypt = "";

        public char[] PolishLetters = new char[] 
        { 
            'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n',
            'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };
        public int MaximunNumberOfMoves() => PolishLetters.Length - 1;

        public MainWindowViewModel()
        {
            encryption = new Encryption(PolishLetters);
            decryption = new Decryption(PolishLetters);
            MoveNumberEncryption = "0";
        }

        #region Encryptio section
        private string _textToEncryption;
        public string TextToEncryption
        {
            get { return _textToEncryption; }
            set 
            {
                _textToEncryption = value;
                encryption.Encrypt(value.ToLower(), NumberOfMoveEncryption, ref _textToEncrypt);
                CryptogramText = _textToEncrypt;
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
                MoveNumberEncryption = value.ToString();
                if (TextToEncryption is not null)
                {
                    encryption.Encrypt(TextToEncryption.ToLower(), value, ref _textToEncrypt);
                    CryptogramText = _textToEncrypt;
                }
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

        private string _moveNumberEncryption;
        public string MoveNumberEncryption
        {
            get { return _moveNumberEncryption; }
            set
            {
                _moveNumberEncryption = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Decryption region
        private string _textToDecryption;
        public string TextToDecryption
        {
            get { return _textToDecryption; }
            set
            {
                _textToDecryption = value;
                decryption.Decrypt(value.ToLower(), NumberOfMoveDecryption, ref _textToDecrypt);
                ExplicitText = _textToDecrypt;
                OnPropertyChanged();
            }
        }

        private int _numberOfMoveDecryption;
        public int NumberOfMoveDecryption
        {
            get { return _numberOfMoveDecryption; }
            set
            {
                _numberOfMoveDecryption = value;
                MoveNumberDecryption = value.ToString();
                if (TextToDecryption is not null)
                {
                    decryption.Decrypt(TextToDecryption.ToLower(), value, ref _textToDecrypt);
                    ExplicitText = _textToDecrypt;
                }
                OnPropertyChanged();
            }
        }

        private string _explicitText;
        public string ExplicitText
        {
            get { return _explicitText; }
            set
            {
                _explicitText = value;
                OnPropertyChanged();
            }
        }

        private string _moveNumberDecryption;
        public string MoveNumberDecryption
        {
            get { return _moveNumberDecryption; }
            set
            {
                _moveNumberDecryption = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
