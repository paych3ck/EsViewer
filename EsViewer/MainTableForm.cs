using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EsViewer
{
    public partial class MainTableForm : Form
    {
        public MainTableForm()
        {
            InitializeComponent();
            GenerateTableLayoutPanel();
        }

        private void ImgClickHandler(object sender, EventArgs e, string pathToImg)
        {
            ShowImageForm showImage = new ShowImageForm(pathToImg);
            showImage.ShowDialog();
        }

        public static Image ResizeImage(string path, int width, int height)
        {
            using (Image image = Image.FromFile(path))
            {
                Bitmap bImg = new Bitmap(image, width, height);
                Image resizedImage = (Image)bImg;
                return resizedImage;
            }
        }

        private void GenerateTableLayoutPanel()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)))) + @"\images";
            string[] allImages = Directory.GetFiles(path);

            PictureBox[] pictureBoxes = new PictureBox[allImages.Length];
            TableLayoutPanel imagesTable = new TableLayoutPanel();

            imagesTable.ColumnCount = 4;
            imagesTable.RowCount = allImages.Length / 4 + 1;
            imagesTable.AutoScroll = true;

            for (int i = 0; i < imagesTable.ColumnCount; i++)
            {
                imagesTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            for (int i = 0; i < imagesTable.RowCount; i++)
            {
                imagesTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            imagesTable.Dock = DockStyle.Fill;

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Size = new Size(320, 180);
                pictureBoxes[i].Image = ResizeImage(allImages[i], 320, 180);
                var p = allImages[i];
                pictureBoxes[i].Click += (sender, EventArgs) => { ImgClickHandler(sender, EventArgs, p); };
                imagesTable.Controls.Add(pictureBoxes[i]);
            }

            Controls.Add(imagesTable);
        }
    }
}
