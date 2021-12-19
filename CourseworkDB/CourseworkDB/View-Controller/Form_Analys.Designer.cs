
namespace CourseworkDB
{
    partial class Form_Analys
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxShops = new System.Windows.Forms.ComboBox();
            this.button_Analysis = new System.Windows.Forms.Button();
            this.richTextBoxGood = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCategory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shop: ";
            // 
            // comboBoxShops
            // 
            this.comboBoxShops.FormattingEnabled = true;
            this.comboBoxShops.Location = new System.Drawing.Point(68, 10);
            this.comboBoxShops.Name = "comboBoxShops";
            this.comboBoxShops.Size = new System.Drawing.Size(300, 24);
            this.comboBoxShops.TabIndex = 1;
            // 
            // button_Analysis
            // 
            this.button_Analysis.Location = new System.Drawing.Point(409, 7);
            this.button_Analysis.Name = "button_Analysis";
            this.button_Analysis.Size = new System.Drawing.Size(75, 29);
            this.button_Analysis.TabIndex = 2;
            this.button_Analysis.Text = "Analysis";
            this.button_Analysis.UseVisualStyleBackColor = true;
            this.button_Analysis.Click += new System.EventHandler(this.button_Analysis_Click);
            // 
            // richTextBoxGood
            // 
            this.richTextBoxGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxGood.Location = new System.Drawing.Point(12, 40);
            this.richTextBoxGood.Name = "richTextBoxGood";
            this.richTextBoxGood.Size = new System.Drawing.Size(252, 186);
            this.richTextBoxGood.TabIndex = 3;
            this.richTextBoxGood.Text = "The most popular GOOD in this shop is:";
            this.richTextBoxGood.Visible = false;
            // 
            // richTextBoxCategory
            // 
            this.richTextBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCategory.Location = new System.Drawing.Point(270, 40);
            this.richTextBoxCategory.Name = "richTextBoxCategory";
            this.richTextBoxCategory.Size = new System.Drawing.Size(252, 186);
            this.richTextBoxCategory.TabIndex = 4;
            this.richTextBoxCategory.Text = "The most popular CATEGORY in this shop is:";
            this.richTextBoxCategory.Visible = false;
            // 
            // Form_Analys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxCategory);
            this.Controls.Add(this.richTextBoxGood);
            this.Controls.Add(this.button_Analysis);
            this.Controls.Add(this.comboBoxShops);
            this.Controls.Add(this.label1);
            this.Name = "Form_Analys";
            this.Text = "Form_Analys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxShops;
        private System.Windows.Forms.Button button_Analysis;
        private System.Windows.Forms.RichTextBox richTextBoxGood;
        private System.Windows.Forms.RichTextBox richTextBoxCategory;
    }
}