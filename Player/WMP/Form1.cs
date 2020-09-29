using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
namespace WMP
{
    public partial class Form1 : Form
    {
        private SecurityController _security;
        const string SECRET_KEY = "YOUR_HASH_KEY";
        public Form1()
        {
            InitializeComponent();
            _security = new SecurityController();
            
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            


            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorId"].ToString();
                break;
            }
            textBox1.Text = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBox1.Text;
                string encryptedText = textBox2.Text;
                string notEncryptedText = _security.Decrypt(password, encryptedText);

                if (SECRET_KEY == notEncryptedText)
                {
                    this.Hide();
                    Form2 frm = new Form2();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("رمز عبور اشتباه است", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }
            }
            catch { }
        }



    }
}
