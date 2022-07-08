using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EsViewer
{
    public partial class ShowImageForm : Form
    {
        public ShowImageForm(string pathToImg)
        {
            InitializeComponent(pathToImg);
            ShowImg(pathToImg);
        }

        private string NameCutter(string name)
        {
            int pos = name.LastIndexOf(".");
            name = name[..pos];
            return name;
        }

        private void ShowImg(string pathToImg)
        {
            PictureBox imgPictureBox = new PictureBox();
            imgPictureBox.Size = new Size(1280, 720);
            imgPictureBox.Image = MainTableForm.ResizeImage(pathToImg, 1280, 720);
            imgPictureBox.Click += (sender, EventArgs) => { Picturebox_Click(sender, EventArgs, pathToImg); };
            Controls.Add(imgPictureBox);
        }

        private void Picturebox_Click(object sender, EventArgs e, string pathToImg)
        {
            string n = NameCutter(Path.GetFileName(pathToImg));
            MessageBox.Show(n, "Значение скопировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(n);
            this.Close();
        }

    }
}
