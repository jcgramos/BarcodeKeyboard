namespace BarcodeKeyboardServer
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHelpLine1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTransfer = new System.Windows.Forms.Label();
            this.lblQL = new System.Windows.Forms.Label();
            this.lblConexion = new System.Windows.Forms.Label();
            this.cboTipoConexion = new System.Windows.Forms.ComboBox();
            this.rbAddReturn = new System.Windows.Forms.RadioButton();
            this.rbAddTab = new System.Windows.Forms.RadioButton();
            this.rbOnlyText = new System.Windows.Forms.RadioButton();
            this.codigoQR = new System.Windows.Forms.PictureBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.codigoQR)).BeginInit();
            this.SuspendLayout();
            // 
            // ntfIcon
            // 
            resources.ApplyResources(this.ntfIcon, "ntfIcon");
            this.ntfIcon.Click += new System.EventHandler(this.ntfIcon_Click);
            // 
            // lblHelpTitle
            // 
            resources.ApplyResources(this.lblHelpTitle, "lblHelpTitle");
            this.lblHelpTitle.Name = "lblHelpTitle";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblHelpLine1
            // 
            resources.ApplyResources(this.lblHelpLine1, "lblHelpLine1");
            this.lblHelpLine1.Name = "lblHelpLine1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblTransfer
            // 
            resources.ApplyResources(this.lblTransfer, "lblTransfer");
            this.lblTransfer.Name = "lblTransfer";
            // 
            // lblQL
            // 
            resources.ApplyResources(this.lblQL, "lblQL");
            this.lblQL.Name = "lblQL";
            // 
            // lblConexion
            // 
            resources.ApplyResources(this.lblConexion, "lblConexion");
            this.lblConexion.Name = "lblConexion";
            // 
            // cboTipoConexion
            // 
            this.cboTipoConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoConexion.FormattingEnabled = true;
            resources.ApplyResources(this.cboTipoConexion, "cboTipoConexion");
            this.cboTipoConexion.Name = "cboTipoConexion";
            this.cboTipoConexion.SelectedIndexChanged += new System.EventHandler(this.cboTipoConexion_SelectedIndexChanged);
            // 
            // rbAddReturn
            // 
            resources.ApplyResources(this.rbAddReturn, "rbAddReturn");
            this.rbAddReturn.Name = "rbAddReturn";
            this.rbAddReturn.UseVisualStyleBackColor = true;
            this.rbAddReturn.Click += new System.EventHandler(this.rbOnlyText_Click);
            // 
            // rbAddTab
            // 
            resources.ApplyResources(this.rbAddTab, "rbAddTab");
            this.rbAddTab.Name = "rbAddTab";
            this.rbAddTab.UseVisualStyleBackColor = true;
            this.rbAddTab.Click += new System.EventHandler(this.rbOnlyText_Click);
            // 
            // rbOnlyText
            // 
            resources.ApplyResources(this.rbOnlyText, "rbOnlyText");
            this.rbOnlyText.Checked = true;
            this.rbOnlyText.Name = "rbOnlyText";
            this.rbOnlyText.TabStop = true;
            this.rbOnlyText.UseVisualStyleBackColor = true;
            this.rbOnlyText.Click += new System.EventHandler(this.rbOnlyText_Click);
            // 
            // codigoQR
            // 
            resources.ApplyResources(this.codigoQR, "codigoQR");
            this.codigoQR.Name = "codigoQR";
            this.codigoQR.TabStop = false;
            // 
            // btnHide
            // 
            this.btnHide.ForeColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.btnHide, "btnHide");
            this.btnHide.Name = "btnHide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnEnd
            // 
            resources.ApplyResources(this.btnEnd, "btnEnd");
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // frmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblTransfer);
            this.Controls.Add(this.lblQL);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.cboTipoConexion);
            this.Controls.Add(this.rbAddReturn);
            this.Controls.Add(this.rbAddTab);
            this.Controls.Add(this.rbOnlyText);
            this.Controls.Add(this.codigoQR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblHelpLine1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHelpTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.codigoQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.Label lblHelpTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHelpLine1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTransfer;
        private System.Windows.Forms.Label lblQL;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.ComboBox cboTipoConexion;
        private System.Windows.Forms.RadioButton rbAddReturn;
        private System.Windows.Forms.RadioButton rbAddTab;
        private System.Windows.Forms.RadioButton rbOnlyText;
        private System.Windows.Forms.PictureBox codigoQR;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnEnd;
    }
}

