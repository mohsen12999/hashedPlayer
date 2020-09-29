using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WMP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var strTempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Video.mp4");

            try
            {
                // ResourceName = the resource you want to play
                File.WriteAllBytes(strTempFile, Properties.Resources.sa);
                amp.URL = strTempFile;
                amp.Ctlcontrols.play();
            }
            catch (Exception ex)
            {

                // Manage me
            }

        }
        private void Form2_Activated(object sender, EventArgs e)
        {
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string authorsFile = "Video.mp4";    
            try    
                {    
                    if (File.Exists(Path.Combine(rootFolder, authorsFile)))    
                        {    
                              File.Delete(Path.Combine(rootFolder, authorsFile));    
                        }    
                }catch (Exception ex)    
                {    } 
            Application.Exit();
        }
    }
}
