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
    public partial class FrmStatus : MetroFramework.Forms.MetroForm
    {
        public FrmStatus()
        {
            InitializeComponent();
        }

        private void FrmStatus_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                statusBindingSource.DataSource =
                    dataContext.Statuses.ToList();
            }
            pnlDatos.Enabled = false;
            Status status = statusBindingSource.Current as Status;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                Status status =
                    statusBindingSource.Current as Status;
                if (status != null)
                {
                    if (dataContext.Entry<Status>(status).State == EntityState.Detached)
                        dataContext.Set<Status>().Attach(status);
                    if (status.Id == 0)
                        dataContext.Entry<Status>(status).State = EntityState.Added;
                    else
                        dataContext.Entry<Status>(status).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Estado guardado");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;
                }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            statusBindingSource.Add(new Status());
            statusBindingSource.MoveLast();
            lblStatusName.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            lblStatusName.Focus();
            Status status =
            statusBindingSource.Current as Status;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this,
               "¿Quieres eliminar el estado?",
               "Eliminar",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (DataContext dataContext = new DataContext())
                {
                    Status status =
                        statusBindingSource.Current as Status;
                    if (status != null)
                    {
                        if (dataContext.Entry<Status>(status).State == EntityState.Detached)
                            dataContext.Set<Status>().Attach(status);
                        dataContext.Entry<Status>(status).State = EntityState.Deleted;
                        dataContext.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Estado eliminado");
                        statusBindingSource.RemoveCurrent();
                        pnlDatos.Enabled = false;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = false;
            statusBindingSource.ResetBindings(false);
            FrmStatus_Load(sender, e);
        }
       

        private void grdDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Status status = statusBindingSource.Current as Status;
        }

      
    }
}
