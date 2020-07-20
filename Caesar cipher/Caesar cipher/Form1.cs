using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar_cipher
{
    public partial class Form1 : Form
    {
        private int _key;
        string _sentence;
        private string _result;
        private int _plus;
        public Form1()
        {
            InitializeComponent();
        }

        private void StButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0 && !String.IsNullOrWhiteSpace(inputTextBox.Text) &&
                keyTextBox.Text.Length > 0) 
            {
                _key= int.Parse(keyTextBox.Text);
                _sentence = inputTextBox.Text.ToLower();
                _result = "";
                switch (comboBox1.Text)
                {
                    case "Encryption":
                        Encryption();
                        break;
                    
                    case "Decryption":
                        Decryption();
                        break;
                }
            }
        }


        private void Encryption()
        {
            foreach (var x in _sentence)
            {
                    _plus = x + _key;
                    if (_plus > 122)
                    {
                        _result +=  (char) ((char)97 + ((char) _plus - 123));
                    }
                    else
                        _result += (char)(x + _key);
            }

            resultTextBox.Text = _result;
        }

        private void Decryption()
        {
            foreach (var x in _sentence)
            {
                    _plus = x - _key;
                    if (_plus < 97)
                    {
                        int dKey = _key - (x - 96);
                        _result += (char) ((char)122 - dKey);
                    }
                    else
                        _result +=(char) (x - _key);
            }
            resultTextBox.Text = _result;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultTextBox.Text);
        }

        private void keyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                 e.Handled =false ;
            else
                e.Handled = true;
        }
    }
}
