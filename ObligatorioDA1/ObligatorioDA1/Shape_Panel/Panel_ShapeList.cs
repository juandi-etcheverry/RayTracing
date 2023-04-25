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
        private Client _client;
        ShapeLogic _shapeLogic = new ShapeLogic(); 
        public Panel_ShapeList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            inititializeList();
            
        }
        public void refreshShapeList(Client _client)
        {
            dgvShapeList.Rows.Clear();
            foreach (Sphere shape in _shapeLogic.GetClientShapes().ToList())
            {
                if (shape.OwnerName == _client.Name)
                {
                    dgvShapeList.Rows.Add(null, null, shape.Name, shape.Radius);
                }
            }
        }
        private void inititializeList()
        {
            addColumns();
            setDisplayColumns();
            //refreshShapeList(_client);
        }
        private void btnAddShape_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToAddNewShape();
        }
        private void dgvShapeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String shapeName = dgvShapeList.CurrentRow.Cells[2].Value.ToString();
            Shape shape = _shapeLogic.GetShape(shapeName);
            if (this.dgvShapeList.Columns[e.ColumnIndex].Name == "Delete" )
            {
                _shapeLogic.RemoveShape(shape);
                dgvShapeList.Rows.Remove(dgvShapeList.CurrentRow);
            }
            if(this.dgvShapeList.Columns[e.ColumnIndex].Name == "Rename")
            {
                _panelGeneral.goToShapeRename(shape);
            }
        }
        private void dgvShapeList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex>=0 && e.RowIndex>=0) 
                this.dgvShapeList.Rows[e.RowIndex].Height = 50;
        }
       private void addColumns()
        {
            dgvShapeList.Columns.Add("name", "Name");
            dgvShapeList.Columns.Add("radius", "Radius");
        }
        private void setDisplayColumns()
        {
            dgvShapeList.Columns["name"].DisplayIndex = 0;
            dgvShapeList.Columns["radius"].DisplayIndex = 1;
            dgvShapeList.Columns["Rename"].DisplayIndex = 2;
            dgvShapeList.Columns["Delete"].DisplayIndex = 3;
        }
    }
}
