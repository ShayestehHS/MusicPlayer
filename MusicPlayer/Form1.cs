using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class frmMP : Form
    {
        string[] Path;
        string[] FileName;

        public frmMP()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Audio (*.mp3,*.acc,*wma)|*.acc;*.mp3;*.wma|All Files (*.*)|*.*";
            OPF.Multiselect = true;
            OPF.Title = "Select One or Multiple Song";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName = OPF.SafeFileNames;
                Path = OPF.FileNames;
                for (int i = 0; i < FileName.Length; i++)
                {
                    if (FileName[i].Contains("________________________________"))
                    {
                        MessageBox.Show("Please select a music that doesnt contain '_____'");
                    }
                    else {
                        listName.Items.Add(FileName[i]);
                        listName.Items.Add("________________________________");
                    }

                }
            }
        }

        private void listName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selected Path ===> SelPath
            string SelPath = Path[listName.SelectedIndex];
            if (File.Exists(SelPath))
            {
                axWMP.URL = SelPath;
            }
        }
    }
}
