namespace V2_Dag3_Ovn1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cmdVisa = new Button();
            cmdDolj = new Button();
            cmdStang = new Button();
            lblVisa = new Label();
            txtText = new TextBox();
            lblTitle = new Label();
            lvlVal = new Label();
            txtVal = new TextBox();
            SuspendLayout();
            // 
            // cmdVisa
            // 
            cmdVisa.BackColor = Color.FromArgb(0, 120, 212);
            cmdVisa.Cursor = Cursors.Hand;
            cmdVisa.FlatAppearance.BorderSize = 0;
            cmdVisa.FlatStyle = FlatStyle.Flat;
            cmdVisa.Font = new Font("Segoe UI", 9.75F);
            cmdVisa.Location = new Point(40, 169);
            cmdVisa.Margin = new Padding(4, 3, 4, 3);
            cmdVisa.Name = "cmdVisa";
            cmdVisa.Size = new Size(75, 26);
            cmdVisa.TabIndex = 0;
            cmdVisa.Text = "Visa";
            cmdVisa.UseVisualStyleBackColor = false;
            cmdVisa.Click += cmdVisa_Click;
            // 
            // cmdDolj
            // 
            cmdDolj.BackColor = Color.FromArgb(0, 120, 212);
            cmdDolj.Cursor = Cursors.Hand;
            cmdDolj.FlatAppearance.BorderSize = 0;
            cmdDolj.FlatStyle = FlatStyle.Flat;
            cmdDolj.Font = new Font("Segoe UI", 9.75F);
            cmdDolj.Location = new Point(130, 169);
            cmdDolj.Margin = new Padding(4, 3, 4, 3);
            cmdDolj.Name = "cmdDolj";
            cmdDolj.Size = new Size(75, 26);
            cmdDolj.TabIndex = 1;
            cmdDolj.Text = "Dölj";
            cmdDolj.UseVisualStyleBackColor = false;
            cmdDolj.Click += cmdDolj_Click;
            // 
            // cmdStang
            // 
            cmdStang.BackColor = Color.FromArgb(0, 120, 212);
            cmdStang.Cursor = Cursors.Hand;
            cmdStang.FlatAppearance.BorderSize = 0;
            cmdStang.FlatStyle = FlatStyle.Flat;
            cmdStang.Font = new Font("Segoe UI", 9.75F);
            cmdStang.Location = new Point(501, 291);
            cmdStang.Margin = new Padding(4, 3, 4, 3);
            cmdStang.Name = "cmdStang";
            cmdStang.Size = new Size(75, 26);
            cmdStang.TabIndex = 2;
            cmdStang.Text = "Stäng";
            cmdStang.UseVisualStyleBackColor = false;
            cmdStang.Click += cmdStang_Click;
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.BackColor = Color.Transparent;
            lblVisa.BorderStyle = BorderStyle.Fixed3D;
            lblVisa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVisa.ForeColor = Color.FromArgb(208, 208, 208);
            lblVisa.Location = new Point(40, 214);
            lblVisa.Margin = new Padding(4, 0, 4, 0);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(2, 19);
            lblVisa.TabIndex = 3;
            // 
            // txtText
            // 
            txtText.BackColor = Color.FromArgb(45, 45, 48);
            txtText.BorderStyle = BorderStyle.FixedSingle;
            txtText.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtText.ForeColor = Color.White;
            txtText.Location = new Point(40, 120);
            txtText.Margin = new Padding(4, 3, 4, 3);
            txtText.Name = "txtText";
            txtText.Size = new Size(165, 25);
            txtText.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(40, 37);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 32);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Välkommen!";
            // 
            // lvlVal
            // 
            lvlVal.AutoSize = true;
            lvlVal.Location = new Point(367, 54);
            lvlVal.Name = "lvlVal";
            lvlVal.Size = new Size(43, 17);
            lvlVal.TabIndex = 6;
            lvlVal.Text = "label1";
            // 
            // txtVal
            // 
            txtVal.Location = new Point(375, 92);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(100, 25);
            txtVal.TabIndex = 7;
            txtVal.Text = "Gillar du C# ? Svara Ja, Nej eller Kanske";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(621, 351);
            Controls.Add(txtVal);
            Controls.Add(lvlVal);
            Controls.Add(lblTitle);
            Controls.Add(txtText);
            Controls.Add(lblVisa);
            Controls.Add(cmdStang);
            Controls.Add(cmdDolj);
            Controls.Add(cmdVisa);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdVisa;
        private Button cmdDolj;
        private Button cmdStang;
        private Label lblVisa;
        private TextBox txtText;
        private Label lblTitle;
        private Label lvlVal;
        private TextBox txtVal;
    }
}
