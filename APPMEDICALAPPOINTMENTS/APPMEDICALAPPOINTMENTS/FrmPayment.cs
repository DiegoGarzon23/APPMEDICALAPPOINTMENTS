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
    public partial class FrmPayment : MetroFramework.Forms.MetroForm
    {
        public FrmPayment()
        {
            InitializeComponent();
        }
        private void FrmPayment_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                paymentBindingSource.DataSource =
                    dataContext.Payments.ToList();
            }
            pnlDatos.Enabled = false;
            Payment payment = paymentBindingSource.Current as Payment;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                Payment payment =
                    paymentBindingSource.Current as Payment;
                if (payment != null)
                {
                    if (dataContext.Entry<Payment>(payment).State == EntityState.Detached)
                        dataContext.Set<Payment>().Attach(payment);
                    if (payment.Id == 0)
                        dataContext.Entry<Payment>(payment).State = EntityState.Added;
                    else
                        dataContext.Entry<Payment>(payment).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Pago guardado");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;



                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            paymentBindingSource.Add(new Payment());
            paymentBindingSource.MoveLast();
            txtPaymentName.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = true;
            txtPaymentName.Focus();
            Payment payment =
            paymentBindingSource.Current as Payment;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnlDatos.Enabled = false;
            paymentBindingSource.ResetBindings(false);
            FrmPayment_Load(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this,
               "¿Quieres eliminar el pago?",
               "Eliminar",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (DataContext dataContext = new DataContext())
                {
                    Payment payment =
                        paymentBindingSource.Current as Payment;
                    if (payment != null)
                    {
                        if (dataContext.Entry<Payment>(payment).State == EntityState.Detached)
                            dataContext.Set<Payment>().Attach(payment);
                        dataContext.Entry<Payment>(payment).State = EntityState.Deleted;
                        dataContext.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "pago eliminado");
                        paymentBindingSource.RemoveCurrent();
                        pnlDatos.Enabled = false;
                    }
                }
            }
        }

        private void grdDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Payment payment = paymentBindingSource.Current as Payment;
        }
    }
}
