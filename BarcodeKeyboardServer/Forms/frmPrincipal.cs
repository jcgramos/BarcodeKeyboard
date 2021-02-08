using BarcodeKeyboardServer.Clases;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeKeyboardServer.Forms;

namespace BarcodeKeyboardServer
{
    public partial class frmPrincipal : Form
    {
        string ip;
        int port = Utils.FreeTcpPort();
        public frmPrincipal()
        {
            InitializeComponent();
            this.ntfIcon.Visible = true;
            this.cargarComboConexion();
            this.cboTipoConexion_SelectedIndexChanged(this.cboTipoConexion, new EventArgs());
            Server.Start(this.port);
            this.showBalloon("Se ha iniciado el servicio");

        }
        private void cargarComboConexion()
        {
            cboTipoConexion.DisplayMember = "Value";
            cboTipoConexion.ValueMember = "Key";
            cboTipoConexion.DataSource = Utils.GetConexionTypes();

        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
        }

        private void ntfIcon_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private void cboTipoConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((int)cboTipoConexion.SelectedValue)
            {
                case 999:
                    FrmConfiguracionAvanzada.Result result = FrmConfiguracionAvanzada.Open(this.ip, this.port);
                    if (result.dialogResult.Equals(DialogResult.OK))
                    {
                        this.ip = result.IP;
                        this.port = result.Port;
                        Server.Stop();
                        Server.Start(port);
                        this.showBalloon("El servicio se ha reiniciado con la nueva configuración");
                        this.showQR();
                    }
                    break;
                default:
                    this.ip = Utils.GetLocalIPv4((NetworkInterfaceType)cboTipoConexion.SelectedValue);
                    this.showQR();
                    break;
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.Stop();
        }

        private void rbOnlyText_Click(object sender, EventArgs e)
        {
            Server.option = rbOnlyText.Checked ? 1 : rbAddTab.Checked ? 2 : 3;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.ntfIcon.BalloonTipTitle = this.Text;
            this.showBalloon("La aplicación continuara ejecutandose en la barra de tareas.");
            this.ntfIcon.ShowBalloonTip(2000);
            this.Visible = false;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.showBalloon("Deteniendo servicio");
            Server.Stop();
            this.Close();
        }

        private void showQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(this.ip + ":" + this.port.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            this.codigoQR.Image = qrCode.GetGraphic(20);

        }
        private void showBalloon( string text)
        {
            this.ntfIcon.BalloonTipTitle = this.Text;
            this.ntfIcon.BalloonTipText = text;
            this.ntfIcon.ShowBalloonTip(2000);

        }
    }
}
