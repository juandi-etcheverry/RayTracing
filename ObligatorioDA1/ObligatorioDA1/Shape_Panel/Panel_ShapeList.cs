using BusinessLogic;
using Domain;
using ObligatorioDA1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    
    public partial class Panel_ShapeList : UserControl
    {
        private Panel_General _panelGeneral;
        private ShapeLogic _shapeLogic = new ShapeLogic(); 
        public Panel_ShapeList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            InititializeList();
        }
        public void RefreshShapeList()
        {
            dgvShapeList.Rows.Clear();
            foreach (Sphere shape in _shapeLogic.GetClientShapes().ToList())
            {
                dgvShapeList.Rows.Add(null, null, shape.Name, shape.Radius);
            }
        }
        private void InititializeList()
        {
            AddColumns();
            SetDisplayColumns();
        }
        private void btnAddShape_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToAddNewShape();
        }
        private void dgvShapeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String shapeName;
            Shape shape;
            if (this.dgvShapeList.Columns[e.ColumnIndex].Name == "Delete" )
            {
                shapeName = dgvShapeList.CurrentRow.Cells[2].Value.ToString();
                shape = _shapeLogic.GetShape(shapeName);
                _shapeLogic.RemoveShape(shape);
                dgvShapeList.Rows.Remove(dgvShapeList.CurrentRow);
            }
            if(this.dgvShapeList.Columns[e.ColumnIndex].Name == "Rename")
            {
                shapeName = dgvShapeList.CurrentRow.Cells[2].Value.ToString();
                shape = _shapeLogic.GetShape(shapeName);
                _panelGeneral.GoToShapeRename(shape);
            }
        }
        private void dgvShapeList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex>=0 && e.RowIndex>=0) 
                this.dgvShapeList.Rows[e.RowIndex].Height = 50;
        }
       private void AddColumns()
        {
            dgvShapeList.Columns.Add("name", "Name");
            dgvShapeList.Columns.Add("radius", "Radius");
        }
        private void SetDisplayColumns()
        {
            dgvShapeList.Columns["name"].DisplayIndex = 0;
            dgvShapeList.Columns["radius"].DisplayIndex = 1;
            dgvShapeList.Columns["Rename"].DisplayIndex = 2;
            dgvShapeList.Columns["Delete"].DisplayIndex = 3;
        }
    }
}
