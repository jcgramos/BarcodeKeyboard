using BarcodeKeyboardServer.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeKeyboardServer.Forms
{
    public partial class FrmConfiguracionAvanzada : Form
    {
        public class Result
        {
            public DialogResult dialogResult { get;  set; }
            public string IP { get;  set; }
            public int Port { get;  set; }
        }
        public FrmConfiguracionAvanzada()
        {
            InitializeComponent();
        }

        public static Result Open(string ip, int port)
        {
            FrmConfiguracionAvanzada form = new FrmConfiguracionAvanzada();
            form.txtIP.Text = ip;
            form.txtPort.Value = port;

            DialogResult result = form.ShowDialog();
            return new Result()
            {
                dialogResult = result,
                IP = form.txtIP.Text,
                Port = int.Parse(form.txtPort.Value.ToString())
            };
        }

        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (sender as TextBox).Text.Count( f => f == char.Parse(".")) >= 3)
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
