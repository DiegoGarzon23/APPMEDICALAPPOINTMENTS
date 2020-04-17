using APPMEDICALAPPOINTMENTS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPMEDICALAPPOINTMENTS
{
    public partial class FrmCategoria : MetroFramework.Forms.MetroForm
    {
        

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                categoryBindingSource.DataSource =
                    dataContext.Categories.ToList();
            }
            pnlDatos.Enabled = false;
            Category category = categoryBindingSource.Current as Category;
                
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                Category category =
                    categoryBindingSource.Current as Category;
                if (category != null)
                {
                    if (dataContext.Entry<Category>(category).State == EntityState.Detached)
                        dataContext.Set<Category>().Attach(category);
                    if (category.Id == 0)
                        dataContext.Entry<Category>(category).State = EntityState.Added;
                    else
                        dataContext.Entry<Category>(category).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Categoria guardada");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtCategoryName.Focus();
            Category category =
                categoryBindingSource.Current as Category;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            categoryBindingSource.Add(new Category());
            categoryBindingSource.MoveLast();
            txtCategoryName.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this,
               "¿Quieres eliminar el registro?",
               "Eliminar",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (DataContext dataContext = new DataContext())
                {
                    Category category =
                        categoryBindingSource.Current as Category;
                    if (category != null)
                    {
                        if (dataContext.Entry<Category>(category).State == EntityState.Detached)
                            dataContext.Set<Category>().Attach(category);
                        dataContext.Entry<Category>(category).State = EntityState.Deleted;
                        dataContext.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Empleado eliminado");
                        categoryBindingSource.RemoveCurrent();
                        pnlDatos.Enabled = false;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = false;
            categoryBindingSource.ResetBindings(false);
            FrmCategoria_Load(sender, e);
        }

        private void grdDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Category category = categoryBindingSource.Current as Category;
          
        }
    }
}
