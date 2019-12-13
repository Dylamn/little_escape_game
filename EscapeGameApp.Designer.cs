namespace EscapeGame
{
    partial class EscapeGameApp
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscapeGameApp));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.lblAttempt = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.verticalProgressBar1 = new EscapeGame.VerticalProgressBar();
            this.input_pwd = new EscapeGame.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(260, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrez votre code d\'accès :";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(323, 321);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // lblAttempt
            // 
            this.lblAttempt.AutoSize = true;
            this.lblAttempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblAttempt.Location = new System.Drawing.Point(12, 9);
            this.lblAttempt.Name = "lblAttempt";
            this.lblAttempt.Size = new System.Drawing.Size(133, 22);
            this.lblAttempt.TabIndex = 4;
            this.lblAttempt.Text = "Tentative _ / @";
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(258, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 205);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(236, 121);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.BorderStyle = EscapeGame.BorderStyles.None;
            this.verticalProgressBar1.Color = System.Drawing.Color.Green;
            this.verticalProgressBar1.Location = new System.Drawing.Point(686, 12);
            this.verticalProgressBar1.Maximum = 240;
            this.verticalProgressBar1.Minimum = 0;
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(20, 397);
            this.verticalProgressBar1.Step = 1;
            this.verticalProgressBar1.Style = EscapeGame.Styles.Solid;
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 240;
            // 
            // input_pwd
            // 
            this.input_pwd.BorderColor = System.Drawing.Color.Empty;
            this.input_pwd.BorderColorBottom = System.Drawing.Color.DarkGray;
            this.input_pwd.BorderColorLeft = System.Drawing.Color.DarkGray;
            this.input_pwd.BorderColorRight = System.Drawing.Color.DarkGray;
            this.input_pwd.BorderColorTop = System.Drawing.Color.DarkGray;
            this.input_pwd.Location = new System.Drawing.Point(253, 295);
            this.input_pwd.Name = "input_pwd";
            this.input_pwd.Size = new System.Drawing.Size(215, 20);
            this.input_pwd.TabIndex = 0;
            this.input_pwd.TextChanged += new System.EventHandler(this.Input_pwd_TextChanged);
            // 
            // EscapeGameApp
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(718, 418);
            this.ControlBox = false;
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.input_pwd);
            this.Controls.Add(this.lblAttempt);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EscapeGameApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EscapeGameApp_FormClosing);
            this.Load += new System.EventHandler(this.EscapeGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label lblAttempt;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private CustomTextBox input_pwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private VerticalProgressBar verticalProgressBar1;
    }
}

