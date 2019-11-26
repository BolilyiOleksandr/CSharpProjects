namespace LinqToXmlWinApp
{
    partial class MainForm
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
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtPetName = new System.Windows.Forms.TextBox();
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMakeToLookUp = new System.Windows.Forms.TextBox();
            this.btnLookUpColors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(15, 49);
            this.txtInventory.Multiline = true;
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInventory.Size = new System.Drawing.Size(386, 259);
            this.txtInventory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Inventory";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(586, 49);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(202, 22);
            this.txtMake.TabIndex = 2;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(586, 88);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(202, 22);
            this.txtColor.TabIndex = 3;
            // 
            // txtPetName
            // 
            this.txtPetName.Location = new System.Drawing.Point(586, 134);
            this.txtPetName.Name = "txtPetName";
            this.txtPetName.Size = new System.Drawing.Size(202, 22);
            this.txtPetName.TabIndex = 4;
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Location = new System.Drawing.Point(666, 178);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(122, 23);
            this.btnAddNewItem.TabIndex = 5;
            this.btnAddNewItem.Text = "Add";
            this.btnAddNewItem.UseVisualStyleBackColor = true;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add Inventory Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pet Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Make";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Make to Look up";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(453, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Look up Colors for Make";
            // 
            // txtMakeToLookUp
            // 
            this.txtMakeToLookUp.Location = new System.Drawing.Point(586, 246);
            this.txtMakeToLookUp.Name = "txtMakeToLookUp";
            this.txtMakeToLookUp.Size = new System.Drawing.Size(202, 22);
            this.txtMakeToLookUp.TabIndex = 10;
            // 
            // btnLookUpColors
            // 
            this.btnLookUpColors.Location = new System.Drawing.Point(586, 285);
            this.btnLookUpColors.Name = "btnLookUpColors";
            this.btnLookUpColors.Size = new System.Drawing.Size(202, 23);
            this.btnLookUpColors.TabIndex = 13;
            this.btnLookUpColors.Text = "Look up Colors";
            this.btnLookUpColors.UseVisualStyleBackColor = true;
            this.btnLookUpColors.Click += new System.EventHandler(this.btnLookUpColors_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLookUpColors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMakeToLookUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewItem);
            this.Controls.Add(this.txtPetName);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInventory);
            this.Name = "MainForm";
            this.Text = "Fun with LINQ to XML";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtPetName;
        private System.Windows.Forms.Button btnAddNewItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMakeToLookUp;
        private System.Windows.Forms.Button btnLookUpColors;
    }
}

