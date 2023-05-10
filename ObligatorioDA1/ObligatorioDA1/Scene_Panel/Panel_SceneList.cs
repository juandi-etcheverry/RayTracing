using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using Domain;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_SceneList : UserControl
    {
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();

        public Panel_SceneList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            InitializeSceneList();
        }

        public void RefreshSceneList()
        {
            dgvSceneList.Rows.Clear();
            foreach (var scene in _sceneLogic.GetClientScenes().ToList())
                dgvSceneList.Rows.Add(null, null, null, null, scene.Name, scene.LastModificationDate);
        }

        private void InitializeSceneList()
        {
            AddColumns();
            SetDisplayOrderColumns();
        }

        private void AddColumns()
        {
            dgvSceneList.Columns.Add("Name", "Name");
            dgvSceneList.Columns.Add("Last update", "Last update");
        }

        private void SetDisplayOrderColumns()
        {
            dgvSceneList.Columns["Preview"].DisplayIndex = 0;
            dgvSceneList.Columns["Name"].DisplayIndex = 1;
            dgvSceneList.Columns["Last update"].DisplayIndex = 2;
            dgvSceneList.Columns["Edit"].DisplayIndex = 3;
            dgvSceneList.Columns["Rename"].DisplayIndex = 4;
            dgvSceneList.Columns["Delete"].DisplayIndex = 5;
        }

        private void btnAddNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToNewSceneName();
        }

        private void dgvSceneList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvSceneList.Rows[e.RowIndex].Height = 40;
                if (dgvSceneList.Columns[e.ColumnIndex].Name == "Preview")
                {
                    //Insert preview
                }
            }
        }

        private void dgvSceneList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sceneName;
            Scene scene;
            if (dgvSceneList.Columns[e.ColumnIndex].Name == "Delete")
            {
                sceneName = dgvSceneList.CurrentRow.Cells[4].Value.ToString();
                scene = _sceneLogic.GetScene(sceneName);
                _sceneLogic.RemoveScene(scene);
                dgvSceneList.Rows.Remove(dgvSceneList.CurrentRow);
            }

            if (dgvSceneList.Columns[e.ColumnIndex].Name == "Rename")
            {
                sceneName = dgvSceneList.CurrentRow.Cells[4].Value.ToString();
                scene = _sceneLogic.GetScene(sceneName);
                _panelGeneral.GoToSceneRename(scene);
            }

            if (dgvSceneList.Columns[e.ColumnIndex].Name == "Edit")
            {
                sceneName = dgvSceneList.CurrentRow.Cells[4].Value.ToString();
                scene = _sceneLogic.GetScene(sceneName);
                _panelGeneral.GoToSceneEditor(scene);
            }
        }

        private void btnSetings_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSetCameraDefault();
        }
    }
}