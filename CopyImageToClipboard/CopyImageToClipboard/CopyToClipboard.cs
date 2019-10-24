using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyImageToClipboard
{
    public partial class CopyToClipboard : Form
    {
        public CopyToClipboard()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                checkOk.Checked=true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Image image = new Bitmap(openFileDialog1.OpenFile());
            Clipboard.SetImage(image);
        }
    }
}
