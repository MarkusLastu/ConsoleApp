namespace V2_Dag3_Ovn2_BioKassa
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

        private ComboBox GetCmb_Drinks1()
        {
            return cmb_Drinks;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_TotPrice = new Button();
            btn_ClearAll = new Button();
            cmb_Products = new ComboBox();
            cmb_Films = new ComboBox();
            cmb_Tickets = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmb_Drinks = new ComboBox();
            label4 = new Label();
            tb_TotalPrice = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btn_TotPrice
            // 
            btn_TotPrice.Location = new Point(41, 51);
            btn_TotPrice.Name = "btn_TotPrice";
            btn_TotPrice.Size = new Size(110, 66);
            btn_TotPrice.TabIndex = 0;
            btn_TotPrice.Text = "Show Price";
            btn_TotPrice.UseVisualStyleBackColor = true;
            // 
            // btn_ClearAll
            // 
            btn_ClearAll.Location = new Point(41, 123);
            btn_ClearAll.Name = "btn_ClearAll";
            btn_ClearAll.Size = new Size(110, 65);
            btn_ClearAll.TabIndex = 1;
            btn_ClearAll.Text = "Clear all";
            btn_ClearAll.UseVisualStyleBackColor = true;
            // 
            // cmb_Products
            // 
            cmb_Products.FormattingEnabled = true;
            cmb_Products.Location = new Point(240, 69);
            cmb_Products.Name = "cmb_Products";
            cmb_Products.Size = new Size(126, 23);
            cmb_Products.TabIndex = 2;
            // 
            // cmb_Films
            // 
            cmb_Films.FormattingEnabled = true;
            cmb_Films.Location = new Point(590, 69);
            cmb_Films.Name = "cmb_Films";
            cmb_Films.Size = new Size(121, 23);
            cmb_Films.TabIndex = 3;
            // 
            // cmb_Tickets
            // 
            cmb_Tickets.FormattingEnabled = true;
            cmb_Tickets.Location = new Point(759, 69);
            cmb_Tickets.Name = "cmb_Tickets";
            cmb_Tickets.Size = new Size(121, 23);
            cmb_Tickets.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 51);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 5;
            label1.Text = "Snacks";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(469, 51);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 6;
            label2.Text = "Drinks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(634, 51);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "Films";
            // 
            // cmb_Drinks
            // 
            cmb_Drinks.FormattingEnabled = true;
            cmb_Drinks.Location = new Point(419, 69);
            cmb_Drinks.Name = "cmb_Drinks";
            cmb_Drinks.Size = new Size(121, 23);
            cmb_Drinks.TabIndex = 8;
            cmb_Drinks.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(803, 51);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Tickets";
            // 
            // tb_TotalPrice
            // 
            tb_TotalPrice.Location = new Point(480, 423);
            tb_TotalPrice.Name = "tb_TotalPrice";
            tb_TotalPrice.Size = new Size(100, 23);
            tb_TotalPrice.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(515, 405);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 11;
            label5.Text = "label5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 586);
            Controls.Add(label5);
            Controls.Add(tb_TotalPrice);
            Controls.Add(label4);
            Controls.Add(cmb_Drinks);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmb_Tickets);
            Controls.Add(cmb_Films);
            Controls.Add(cmb_Products);
            Controls.Add(btn_ClearAll);
            Controls.Add(btn_TotPrice);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_TotPrice;
        private Button btn_ClearAll;
        private ComboBox cmb_Products;
        private ComboBox cmb_Films;
        private ComboBox cmb_Tickets;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmb_Drinks;
        private Label label4;
        private TextBox tb_TotalPrice;
        private Label label5;
    }
}
