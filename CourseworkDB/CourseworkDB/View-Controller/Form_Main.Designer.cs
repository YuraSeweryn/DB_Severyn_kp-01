
namespace CourseworkDB
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
            this.buttonClearData = new System.Windows.Forms.Button();
            this.button_Random = new System.Windows.Forms.Button();
            this.button_Goods = new System.Windows.Forms.Button();
            this.button_Prices = new System.Windows.Forms.Button();
            this.button_Shops = new System.Windows.Forms.Button();
            this.button_Categories = new System.Windows.Forms.Button();
            this.button_Availability = new System.Windows.Forms.Button();
            this.groupBoxEntities = new System.Windows.Forms.GroupBox();
            this.buttonVilualisation = new System.Windows.Forms.Button();
            this.button_Analysis = new System.Windows.Forms.Button();
            this.groupBoxEntities.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClearData
            // 
            this.buttonClearData.Location = new System.Drawing.Point(681, 11);
            this.buttonClearData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearData.Name = "buttonClearData";
            this.buttonClearData.Size = new System.Drawing.Size(107, 29);
            this.buttonClearData.TabIndex = 0;
            this.buttonClearData.Text = "Clear Data";
            this.buttonClearData.UseVisualStyleBackColor = true;
            this.buttonClearData.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // button_Random
            // 
            this.button_Random.Location = new System.Drawing.Point(681, 44);
            this.button_Random.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Random.Name = "button_Random";
            this.button_Random.Size = new System.Drawing.Size(107, 56);
            this.button_Random.TabIndex = 1;
            this.button_Random.Text = "Random Fill";
            this.button_Random.UseVisualStyleBackColor = true;
            this.button_Random.Click += new System.EventHandler(this.button_Random_Click);
            // 
            // button_Goods
            // 
            this.button_Goods.Location = new System.Drawing.Point(12, 52);
            this.button_Goods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Goods.Name = "button_Goods";
            this.button_Goods.Size = new System.Drawing.Size(100, 29);
            this.button_Goods.TabIndex = 2;
            this.button_Goods.Text = "Goods";
            this.button_Goods.UseVisualStyleBackColor = true;
            this.button_Goods.Click += new System.EventHandler(this.button_Goods_Click);
            // 
            // button_Prices
            // 
            this.button_Prices.Location = new System.Drawing.Point(67, 118);
            this.button_Prices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Prices.Name = "button_Prices";
            this.button_Prices.Size = new System.Drawing.Size(100, 29);
            this.button_Prices.TabIndex = 3;
            this.button_Prices.Text = "Prices";
            this.button_Prices.UseVisualStyleBackColor = true;
            this.button_Prices.Click += new System.EventHandler(this.button_Prices_Click);
            // 
            // button_Shops
            // 
            this.button_Shops.Location = new System.Drawing.Point(118, 52);
            this.button_Shops.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Shops.Name = "button_Shops";
            this.button_Shops.Size = new System.Drawing.Size(100, 29);
            this.button_Shops.TabIndex = 4;
            this.button_Shops.Text = "Shops";
            this.button_Shops.UseVisualStyleBackColor = true;
            this.button_Shops.Click += new System.EventHandler(this.button_Shops_Click);
            // 
            // button_Categories
            // 
            this.button_Categories.Location = new System.Drawing.Point(67, 19);
            this.button_Categories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Categories.Name = "button_Categories";
            this.button_Categories.Size = new System.Drawing.Size(100, 29);
            this.button_Categories.TabIndex = 5;
            this.button_Categories.Text = "Categories";
            this.button_Categories.UseVisualStyleBackColor = true;
            this.button_Categories.Click += new System.EventHandler(this.button_Categories_Click);
            // 
            // button_Availability
            // 
            this.button_Availability.Location = new System.Drawing.Point(67, 85);
            this.button_Availability.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Availability.Name = "button_Availability";
            this.button_Availability.Size = new System.Drawing.Size(100, 29);
            this.button_Availability.TabIndex = 6;
            this.button_Availability.Text = "Availability";
            this.button_Availability.UseVisualStyleBackColor = true;
            this.button_Availability.Click += new System.EventHandler(this.button_Availability_Click);
            // 
            // groupBoxEntities
            // 
            this.groupBoxEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBoxEntities.Controls.Add(this.button_Categories);
            this.groupBoxEntities.Controls.Add(this.button_Prices);
            this.groupBoxEntities.Controls.Add(this.button_Goods);
            this.groupBoxEntities.Controls.Add(this.button_Shops);
            this.groupBoxEntities.Controls.Add(this.button_Availability);
            this.groupBoxEntities.Location = new System.Drawing.Point(12, 11);
            this.groupBoxEntities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEntities.Name = "groupBoxEntities";
            this.groupBoxEntities.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxEntities.Size = new System.Drawing.Size(230, 156);
            this.groupBoxEntities.TabIndex = 7;
            this.groupBoxEntities.TabStop = false;
            this.groupBoxEntities.Text = "Entities windows";
            // 
            // buttonVilualisation
            // 
            this.buttonVilualisation.Location = new System.Drawing.Point(681, 104);
            this.buttonVilualisation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVilualisation.Name = "buttonVilualisation";
            this.buttonVilualisation.Size = new System.Drawing.Size(107, 29);
            this.buttonVilualisation.TabIndex = 8;
            this.buttonVilualisation.Text = "Visualisation";
            this.buttonVilualisation.UseVisualStyleBackColor = true;
            this.buttonVilualisation.Click += new System.EventHandler(this.buttonVilualisation_Click);
            // 
            // button_Analysis
            // 
            this.button_Analysis.Location = new System.Drawing.Point(681, 138);
            this.button_Analysis.Name = "button_Analysis";
            this.button_Analysis.Size = new System.Drawing.Size(107, 29);
            this.button_Analysis.TabIndex = 9;
            this.button_Analysis.Text = "Data Analysis";
            this.button_Analysis.UseVisualStyleBackColor = true;
            this.button_Analysis.Click += new System.EventHandler(this.button_Analysis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.button_Analysis);
            this.Controls.Add(this.buttonVilualisation);
            this.Controls.Add(this.groupBoxEntities);
            this.Controls.Add(this.button_Random);
            this.Controls.Add(this.buttonClearData);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Course";
            this.groupBoxEntities.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClearData;
        private System.Windows.Forms.Button button_Random;
        private System.Windows.Forms.Button button_Goods;
        private System.Windows.Forms.Button button_Prices;
        private System.Windows.Forms.Button button_Shops;
        private System.Windows.Forms.Button button_Categories;
        private System.Windows.Forms.Button button_Availability;
        private System.Windows.Forms.GroupBox groupBoxEntities;
        private System.Windows.Forms.Button buttonVilualisation;
        private System.Windows.Forms.Button button_Analysis;
    }
}

