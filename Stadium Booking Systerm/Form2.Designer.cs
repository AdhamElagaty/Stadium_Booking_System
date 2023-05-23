namespace Stadium_Booking_Systerm
{
    partial class Form_login
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            this.bunifuElipse_form = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textname = new System.Windows.Forms.TextBox();
            this.textpass = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lab_username_err = new System.Windows.Forms.Label();
            this.lab_pass_err = new System.Windows.Forms.Label();
            this.lab_login_error = new System.Windows.Forms.Label();
            this.show_pass_btn = new System.Windows.Forms.PictureBox();
            this.hide_pass_btn = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_form
            // 
            this.bunifuElipse_form.ElipseRadius = 80;
            this.bunifuElipse_form.TargetControl = this;
            // 
            // textname
            // 
            this.textname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.textname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textname.Font = new System.Drawing.Font("Ubuntu", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textname.ForeColor = System.Drawing.Color.Gray;
            this.textname.Location = new System.Drawing.Point(427, 259);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(399, 51);
            this.textname.TabIndex = 2;
            this.textname.Text = "UserName";
            this.textname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textname.WordWrap = false;
            this.textname.Enter += new System.EventHandler(this.textname_Enter);
            this.textname.Leave += new System.EventHandler(this.textname_Leave);
            // 
            // textpass
            // 
            this.textpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.textpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textpass.Font = new System.Drawing.Font("Ubuntu", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpass.ForeColor = System.Drawing.Color.Gray;
            this.textpass.Location = new System.Drawing.Point(427, 352);
            this.textpass.Name = "textpass";
            this.textpass.Size = new System.Drawing.Size(399, 51);
            this.textpass.TabIndex = 3;
            this.textpass.Text = "Password";
            this.textpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textpass.TextAlignChanged += new System.EventHandler(this.textpass_TextAlignChanged);
            this.textpass.Enter += new System.EventHandler(this.textpass_Enter);
            this.textpass.Leave += new System.EventHandler(this.textpass_Leave);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlogin.Font = new System.Drawing.Font("Ubuntu", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(531, 459);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(204, 64);
            this.btnlogin.TabIndex = 1;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            this.btnlogin.MouseLeave += new System.EventHandler(this.btnlogin_MouseLeave);
            this.btnlogin.MouseHover += new System.EventHandler(this.btnlogin_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lab_username_err
            // 
            this.lab_username_err.AutoSize = true;
            this.lab_username_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_username_err.ForeColor = System.Drawing.Color.IndianRed;
            this.lab_username_err.Location = new System.Drawing.Point(431, 313);
            this.lab_username_err.Name = "lab_username_err";
            this.lab_username_err.Size = new System.Drawing.Size(0, 27);
            this.lab_username_err.TabIndex = 26;
            // 
            // lab_pass_err
            // 
            this.lab_pass_err.AutoSize = true;
            this.lab_pass_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_pass_err.ForeColor = System.Drawing.Color.IndianRed;
            this.lab_pass_err.Location = new System.Drawing.Point(431, 415);
            this.lab_pass_err.Name = "lab_pass_err";
            this.lab_pass_err.Size = new System.Drawing.Size(0, 27);
            this.lab_pass_err.TabIndex = 27;
            // 
            // lab_login_error
            // 
            this.lab_login_error.AutoSize = true;
            this.lab_login_error.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_login_error.ForeColor = System.Drawing.Color.IndianRed;
            this.lab_login_error.Location = new System.Drawing.Point(454, 526);
            this.lab_login_error.Name = "lab_login_error";
            this.lab_login_error.Size = new System.Drawing.Size(0, 26);
            this.lab_login_error.TabIndex = 28;
            // 
            // show_pass_btn
            // 
            this.show_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_pass_btn.Image = global::Stadium_Booking_Systerm.Properties.Resources.Show;
            this.show_pass_btn.Location = new System.Drawing.Point(827, 355);
            this.show_pass_btn.Name = "show_pass_btn";
            this.show_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.show_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_pass_btn.TabIndex = 30;
            this.show_pass_btn.TabStop = false;
            this.show_pass_btn.Visible = false;
            this.show_pass_btn.Click += new System.EventHandler(this.show_pass_btn_Click);
            // 
            // hide_pass_btn
            // 
            this.hide_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide_pass_btn.Image = global::Stadium_Booking_Systerm.Properties.Resources.Hide;
            this.hide_pass_btn.Location = new System.Drawing.Point(827, 355);
            this.hide_pass_btn.Name = "hide_pass_btn";
            this.hide_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.hide_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hide_pass_btn.TabIndex = 29;
            this.hide_pass_btn.TabStop = false;
            this.hide_pass_btn.Visible = false;
            this.hide_pass_btn.Click += new System.EventHandler(this.hide_pass_btn_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Stadium_Booking_Systerm.Properties.Resources.exit;
            this.pictureBox3.Location = new System.Drawing.Point(858, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Stadium_Booking_Systerm.Properties.Resources.Welcome;
            this.pictureBox2.Location = new System.Drawing.Point(412, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(426, 198);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Stadium_Booking_Systerm.Properties.Resources.giphy__1_;
            this.pictureBox4.Location = new System.Drawing.Point(17, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stadium_Booking_Systerm.Properties.Resources.Soccer_Ball_Hexagon_Pattern_Loader1;
            this.pictureBox1.Location = new System.Drawing.Point(-794, -260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1795, 1180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(921, 573);
            this.Controls.Add(this.textpass);
            this.Controls.Add(this.show_pass_btn);
            this.Controls.Add(this.hide_pass_btn);
            this.Controls.Add(this.lab_login_error);
            this.Controls.Add(this.lab_pass_err);
            this.Controls.Add(this.lab_username_err);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.textname);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_form;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox textpass;
        private System.Windows.Forms.TextBox textname;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lab_username_err;
        private System.Windows.Forms.Label lab_pass_err;
        private System.Windows.Forms.Label lab_login_error;
        private System.Windows.Forms.PictureBox hide_pass_btn;
        private System.Windows.Forms.PictureBox show_pass_btn;
    }
}