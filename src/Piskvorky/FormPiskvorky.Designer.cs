namespace Piskvorky
{
    partial class FormPiskvorky
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            sitovani.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPiskvorky));
            this.panelTypHry = new System.Windows.Forms.Panel();
            this.buttonSit = new System.Windows.Forms.Button();
            this.buttonJeden = new System.Windows.Forms.Button();
            this.buttonPripoj = new System.Windows.Forms.Button();
            this.panelSitove = new System.Windows.Forms.Panel();
            this.labelPortJa = new System.Windows.Forms.Label();
            this.textBoxPortJa = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.buttonPoslouchat = new System.Windows.Forms.Button();
            this.panelTypHry.SuspendLayout();
            this.panelSitove.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTypHry
            // 
            this.panelTypHry.BackColor = System.Drawing.SystemColors.Control;
            this.panelTypHry.Controls.Add(this.buttonSit);
            this.panelTypHry.Controls.Add(this.buttonJeden);
            this.panelTypHry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTypHry.Location = new System.Drawing.Point(0, 0);
            this.panelTypHry.Name = "panelTypHry";
            this.panelTypHry.Size = new System.Drawing.Size(388, 457);
            this.panelTypHry.TabIndex = 0;
            // 
            // buttonSit
            // 
            this.buttonSit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSit.Location = new System.Drawing.Point(12, 235);
            this.buttonSit.Name = "buttonSit";
            this.buttonSit.Size = new System.Drawing.Size(372, 220);
            this.buttonSit.TabIndex = 0;
            this.buttonSit.Text = "&Síťová hra";
            this.buttonSit.UseVisualStyleBackColor = true;
            this.buttonSit.Click += new System.EventHandler(this.buttonSit_Click);
            // 
            // buttonJeden
            // 
            this.buttonJeden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJeden.Location = new System.Drawing.Point(12, 12);
            this.buttonJeden.Name = "buttonJeden";
            this.buttonJeden.Size = new System.Drawing.Size(372, 220);
            this.buttonJeden.TabIndex = 0;
            this.buttonJeden.Text = "&Na jednom počítači";
            this.buttonJeden.UseVisualStyleBackColor = true;
            this.buttonJeden.Click += new System.EventHandler(this.buttonJeden_Click);
            // 
            // buttonPripoj
            // 
            this.buttonPripoj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPripoj.Location = new System.Drawing.Point(6, 253);
            this.buttonPripoj.Name = "buttonPripoj";
            this.buttonPripoj.Size = new System.Drawing.Size(379, 23);
            this.buttonPripoj.TabIndex = 6;
            this.buttonPripoj.Text = "&Připojit se";
            this.buttonPripoj.UseVisualStyleBackColor = true;
            this.buttonPripoj.Click += new System.EventHandler(this.buttonPripoj_Click);
            // 
            // panelSitove
            // 
            this.panelSitove.BackColor = System.Drawing.SystemColors.Control;
            this.panelSitove.Controls.Add(this.labelPortJa);
            this.panelSitove.Controls.Add(this.textBoxPortJa);
            this.panelSitove.Controls.Add(this.labelPort);
            this.panelSitove.Controls.Add(this.textBoxPort);
            this.panelSitove.Controls.Add(this.labelServer);
            this.panelSitove.Controls.Add(this.textBoxServer);
            this.panelSitove.Controls.Add(this.buttonPoslouchat);
            this.panelSitove.Controls.Add(this.buttonPripoj);
            this.panelSitove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSitove.Location = new System.Drawing.Point(0, 0);
            this.panelSitove.Name = "panelSitove";
            this.panelSitove.Size = new System.Drawing.Size(388, 457);
            this.panelSitove.TabIndex = 1;
            this.panelSitove.Visible = false;
            // 
            // labelPortJa
            // 
            this.labelPortJa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPortJa.AutoSize = true;
            this.labelPortJa.Location = new System.Drawing.Point(291, 138);
            this.labelPortJa.Name = "labelPortJa";
            this.labelPortJa.Size = new System.Drawing.Size(29, 13);
            this.labelPortJa.TabIndex = 4;
            this.labelPortJa.Text = "P&ort:";
            // 
            // textBoxPortJa
            // 
            this.textBoxPortJa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortJa.Location = new System.Drawing.Point(326, 138);
            this.textBoxPortJa.Name = "textBoxPortJa";
            this.textBoxPortJa.Size = new System.Drawing.Size(61, 20);
            this.textBoxPortJa.TabIndex = 5;
            this.textBoxPortJa.Text = "52456";
            this.textBoxPortJa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelPort
            // 
            this.labelPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(289, 229);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "P&ort:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(324, 229);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(61, 20);
            this.textBoxPort.TabIndex = 5;
            this.textBoxPort.Text = "52456";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelServer
            // 
            this.labelServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(3, 229);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(124, 13);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "&IP nebo jméno počítače:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.Location = new System.Drawing.Point(133, 229);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(150, 20);
            this.textBoxServer.TabIndex = 3;
            this.textBoxServer.Text = "localhost";
            // 
            // buttonPoslouchat
            // 
            this.buttonPoslouchat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPoslouchat.Location = new System.Drawing.Point(6, 164);
            this.buttonPoslouchat.Name = "buttonPoslouchat";
            this.buttonPoslouchat.Size = new System.Drawing.Size(379, 23);
            this.buttonPoslouchat.TabIndex = 6;
            this.buttonPoslouchat.Text = "&Očekávat připojení";
            this.buttonPoslouchat.UseVisualStyleBackColor = true;
            this.buttonPoslouchat.Click += new System.EventHandler(this.buttonPoslouchat_Click);
            // 
            // FormPiskvorky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(388, 457);
            this.Controls.Add(this.panelSitove);
            this.Controls.Add(this.panelTypHry);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPiskvorky";
            this.Text = "Piškvorky";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHlavni_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelHlavni_MouseDown);
            this.panelTypHry.ResumeLayout(false);
            this.panelSitove.ResumeLayout(false);
            this.panelSitove.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTypHry;
        private System.Windows.Forms.Button buttonPripoj;
        private System.Windows.Forms.Button buttonJeden;
        private System.Windows.Forms.Panel panelSitove;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonSit;
        private System.Windows.Forms.Label labelPortJa;
        private System.Windows.Forms.TextBox textBoxPortJa;
        private System.Windows.Forms.Button buttonPoslouchat;

    }
}

