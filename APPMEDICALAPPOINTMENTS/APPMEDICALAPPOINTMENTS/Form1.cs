using APPMEDICALAPPOINTMENTS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPMEDICALAPPOINTMENTS
{
    public partial class frmUser : MetroFramework.Forms.MetroForm
    {
        public frmUser()
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
    }
}
    
