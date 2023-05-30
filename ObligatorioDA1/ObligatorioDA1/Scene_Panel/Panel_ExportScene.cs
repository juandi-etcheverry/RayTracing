using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_ExportScene : UserControl
    {
        private Scene _scene;
        private readonly Panel_General _panelGeneral;
        public Panel_ExportScene(Panel_General panelGeneral)
        {
            InitializeComponent();
            _panelGeneral = panelGeneral;
        }
        public void RefreshSceneExport(Scene newScene)
        {
            _scene = newScene;
            lblSceneName.Text = _scene.Name;
            rbtnPNG.Checked = true;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneEditor(_scene);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FileType();
            saveFileDialog.Title = "Save an Image File";
            Bitmap bitmap = _scene.Preview;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Console.WriteLine(filePath);
                bitmap.Save(filePath, FileType1());
            }
            _panelGeneral.GoToSceneEditor(_scene);
        }
        private string FileType()
        {
            if (rbtnJPG.Checked) return "JPeg Image|*.jpg";
            else if (rbtnPNG.Checked) return "Png Image|*.png";
            else return "PPM Image|*.ppm";
        }
        private ImageFormat FileType1()
        {
            ImageFormat imageFormat;
            if(rbtnPNG.Checked) imageFormat = ImageFormat.Png;
            else if (rbtnJPG.Checked) imageFormat = ImageFormat.Jpeg;
            else imageFormat = ImageFormat.Bmp;
            return imageFormat;
        }
    }
}
