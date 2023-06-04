using Domain;
using GraphicsEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            lblSceneName.Text = _scene.SceneName;
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
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Console.WriteLine(filePath);
                Save(bitmap, filePath);
            }
            _panelGeneral.GoToSceneEditor(_scene);
        }
        private string FileType()
        {
            if (rbtnJPG.Checked) { return "JPeg Image|*.jpg"; }
            if (rbtnPNG.Checked) return "Png Image|*.png";
            return "PPM Image|*.ppm";
        }
        private void Save(Bitmap bitmap, string filePath)
        {
            if (rbtnPNG.Checked) SavePNG(bitmap, filePath);
            else if (rbtnJPG.Checked) SaveJPG(bitmap, filePath);
            else SavePPM(filePath);
        }

        private void SavePNG(Bitmap bitmap, string filePath)
        {
            bitmap.Save(filePath, ImageFormat.Png);
        }

        private void SaveJPG(Bitmap bitmap, string filePath)
        {
            bitmap.Save(filePath, ImageFormat.Jpeg);
        }

        private void SavePPM(string filePath)
        {
            int sceneDateTime = ImageParser.HashDate(_scene.LastRenderDate);
            string sceneFileName = $"{_scene.Client.Name}_{sceneDateTime}.ppm";
            File.Copy(sceneFileName, filePath);
        }
    }
}
