namespace V2_Dag3_Ovn2
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
            cmdBeslut = new Button();
            lblVal = new Label();
            txtVal = new TextBox();
            cmbDesserts = new ComboBox();
            cmdValtDessert = new Button();
            SuspendLayout();
            // 
            // cmdBeslut
            // 
            cmdBeslut.Location = new Point(87, 88);
            cmdBeslut.Name = "cmdBeslut";
            cmdBeslut.Size = new Size(165, 23);
            cmdBeslut.TabIndex = 0;
            cmdBeslut.Text = "Validera Ja, Kanske, Nej";
            cmdBeslut.UseVisualStyleBackColor = true;
            cmdBeslut.Click += cmdBeslut_Click;
            // 
            // lblVal
            // 
            lblVal.AutoSize = true;
            lblVal.Location = new Point(87, 51);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(210, 15);
            lblVal.TabIndex = 1;
            lblVal.Text = "Gillar du C# ? Svara Ja, Nej eller Kanske";
            // 
            // txtVal
            // 
            txtVal.Location = new Point(395, 107);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(100, 23);
            txtVal.TabIndex = 2;
            // 
            // cmbDesserts
            // 
            cmbDesserts.FormattingEnabled = true;
            cmbDesserts.Location = new Point(222, 267);
            cmbDesserts.Name = "cmbDesserts";
            cmbDesserts.Size = new Size(121, 23);
            cmbDesserts.TabIndex = 3;
            cmbDesserts.SelectedIndexChanged += cmbDesserts_SelectedIndexChanged;
            // 
            // cmdValtDessert
            // 
            cmdValtDessert.Location = new Point(513, 255);
            cmdValtDessert.Name = "cmdValtDessert";
            cmdValtDessert.Size = new Size(75, 23);
            cmdValtDessert.TabIndex = 4;
            cmdValtDessert.Text = "Ändra färg";
            cmdValtDessert.UseVisualStyleBackColor = true;
            cmdValtDessert.Click += cmdValtDessert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(cmdValtDessert);
            Controls.Add(cmbDesserts);
            Controls.Add(txtVal);
            Controls.Add(lblVal);
            Controls.Add(cmdBeslut);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdBeslut;
        private Label lblVal;
        private TextBox txtVal;
        private ComboBox cmbDesserts;
        private Button cmdValtDessert;
    }
}
