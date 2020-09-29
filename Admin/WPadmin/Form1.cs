using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WPadmin
{
    public partial class Form1 : Form
    {
        private SecurityController _security;
        public Form1()
        {
            InitializeComponent();
            _security = new SecurityController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBox1.Text;
                string notEncryptedText = textBox2.Text;
                string encryptedText = _security.Encrypt(password, notEncryptedText);
                textBox3.Text = encryptedText;
            }
            catch { }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }
    }
}
