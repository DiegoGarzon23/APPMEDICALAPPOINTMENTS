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
    public partial class FrmUser : MetroFramework.Forms.MetroForm
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                userBindingSource.DataSource =
                    dataContext.Users.ToList();

            }
            pnlDatos.Enabled = false;
            User user = userBindingSource.Current as User;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                User user =
                    userBindingSource.Current as User;
                if (user != null)
                {
                    if (dataContext.Entry<User>(user).State == EntityState.Detached)
                        dataContext.Set<User>().Attach(user);
                    if (user.Id == 0)
                        dataContext.Entry<User>(user).State = EntityState.Added;
                    else
                        dataContext.Entry<User>(user).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Usuario guardado");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtFirstName.Focus();
            User user =
                userBindingSource.Current as User;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            userBindingSource.Add(new User());
            userBindingSource.MoveLast();
            txtFirstName.Focus();
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
                    User user =
                        userBindingSource.Current as User;
                    if (user != null)
                    {
                        if (dataContext.Entry<User>(user).State == EntityState.Detached)
                            dataContext.Set<User>().Attach(user);
                        dataContext.Entry<User>(user).State = EntityState.Deleted;
                        dataContext.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Empleado eliminado");
                        userBindingSource.RemoveCurrent();
                        pnlDatos.Enabled = false;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = false;
            userBindingSource.ResetBindings(false);
            FrmUsers_Load(sender, e);

        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void grdDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            User user = userBindingSource.Current as User;
            
        }
    }
}
    
