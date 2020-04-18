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
    public partial class FrmPacient : MetroFramework.Forms.MetroForm
    {
        public FrmPacient()
        {
            InitializeComponent();
        }

        private void FrmPacient_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                pacientBindingSource.DataSource =
                    dataContext.Pacients.ToList();
            }
            pnlDatos.Enabled = false;
            Pacient pacient = pacientBindingSource.Current as Pacient;

        }
    }
}
