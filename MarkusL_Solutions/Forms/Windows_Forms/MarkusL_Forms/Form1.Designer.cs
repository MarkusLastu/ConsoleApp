namespace MarkusL_Forms
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
            lblVisa = new Label();
            lblVal = new Label();
            cmdVisa = new Button();
            cmdDolj = new Button();
            cmdStang = new Button();
            cmdBeslut = new Button();
            txtText = new TextBox();
            txtVal = new TextBox();
            cmbDesert = new ComboBox();
            SuspendLayout();
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.BorderStyle = BorderStyle.Fixed3D;
            lblVisa.Font = new Font("Segoe UI", 18F);
            lblVisa.Location = new Point(227, 148);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(2, 34);
            lblVisa.TabIndex = 0;
            // 
            // lblVal
            // 
            lblVal.AutoSize = true;
            lblVal.BorderStyle = BorderStyle.Fixed3D;
            lblVal.Location = new Point(415, 148);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(212, 17);
            lblVal.TabIndex = 1;
            lblVal.Text = "Gillar du C# ? Svara Ja, Nej eller Kanske";
            // 
            // cmdVisa
            // 
            cmdVisa.Location = new Point(195, 243);
            cmdVisa.Name = "cmdVisa";
            cmdVisa.Size = new Size(75, 23);
            cmdVisa.TabIndex = 2;
            cmdVisa.Text = "Visa";
            cmdVisa.UseVisualStyleBackColor = true;
            cmdVisa.Click += cmdVisa_Click;
            // 
            // cmdDolj
            // 
            cmdDolj.Location = new Point(276, 243);
            cmdDolj.Name = "cmdDolj";
            cmdDolj.Size = new Size(75, 23);
            cmdDolj.TabIndex = 3;
            cmdDolj.Text = "Dölj";
            cmdDolj.UseVisualStyleBackColor = true;
            cmdDolj.Click += cmdDolj_Click;
            // 
            // cmdStang
            // 
            cmdStang.Location = new Point(641, 383);
            cmdStang.Name = "cmdStang";
            cmdStang.Size = new Size(75, 23);
            cmdStang.TabIndex = 4;
            cmdStang.Text = "Stäng";
            cmdStang.UseVisualStyleBackColor = true;
            cmdStang.Click += cmdStang_Click;
            // 
            // cmdBeslut
            // 
            cmdBeslut.Location = new Point(415, 207);
            cmdBeslut.Name = "cmdBeslut";
            cmdBeslut.Size = new Size(75, 23);
            cmdBeslut.TabIndex = 5;
            cmdBeslut.Text = "Beslut";
            cmdBeslut.UseVisualStyleBackColor = true;
            cmdBeslut.Click += cmdBeslut_Click;
            // 
            // txtText
            // 
            txtText.Location = new Point(195, 214);
            txtText.Name = "txtText";
            txtText.Size = new Size(156, 23);
            txtText.TabIndex = 6;
            // 
            // txtVal
            // 
            txtVal.Location = new Point(415, 178);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(100, 23);
            txtVal.TabIndex = 7;
            // 
            // cmbDesert
            // 
            cmbDesert.FormattingEnabled = true;
            cmbDesert.Location = new Point(521, 178);
            cmbDesert.Name = "cmbDesert";
            cmbDesert.Size = new Size(121, 23);
            cmbDesert.TabIndex = 8;
            cmbDesert.SelectedIndexChanged += cmbDesert_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbDesert);
            Controls.Add(txtVal);
            Controls.Add(txtText);
            Controls.Add(cmdBeslut);
            Controls.Add(cmdStang);
            Controls.Add(cmdDolj);
            Controls.Add(cmdVisa);
            Controls.Add(lblVal);
            Controls.Add(lblVisa);
            Name = "Form1";
            Text = "Mitt första Windows Form program";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVisa;
        private Label lblVal;
        private Button cmdVisa;
        private Button cmdDolj;
        private Button cmdStang;
        private Button cmdBeslut;
        private TextBox txtText;
        private TextBox txtVal;
        private ComboBox cmbDesert;
    }
}