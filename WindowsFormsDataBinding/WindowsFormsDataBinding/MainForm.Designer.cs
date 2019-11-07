namespace WindowsFormsDataBinding
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
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.labelStock = new System.Windows.Forms.Label();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(12, 47);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.RowTemplate.Height = 24;
            this.carInventoryGridView.Size = new System.Drawing.Size(776, 296);
            this.carInventoryGridView.TabIndex = 0;
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(13, 13);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(194, 17);
            this.labelStock.TabIndex = 1;
            this.labelStock.Text = "Here is what we have in stock";
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(6, 47);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(195, 22);
            this.txtCarToRemove.TabIndex = 2;
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(221, 47);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(139, 23);
            this.btnRemoveCar.TabIndex = 3;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCarToRemove);
            this.groupBox1.Controls.Add(this.btnRemoveCar);
            this.groupBox1.Location = new System.Drawing.Point(12, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Id of Car to Delete";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMakeToView);
            this.groupBox2.Controls.Add(this.btnDisplayMakes);
            this.groupBox2.Location = new System.Drawing.Point(419, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 101);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Make to View";
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(6, 47);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(195, 22);
            this.txtMakeToView.TabIndex = 2;
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(221, 47);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(139, 23);
            this.btnDisplayMakes.TabIndex = 3;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(12, 468);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(369, 23);
            this.btnChangeMakes.TabIndex = 4;
            this.btnChangeMakes.Text = "Change!";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(806, 47);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.RowTemplate.Height = 24;
            this.dataGridYugosView.Size = new System.Drawing.Size(552, 296);
            this.dataGridYugosView.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(803, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Here is what we have in Yugos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.btnChangeMakes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "MainForm";
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.Button btnChangeMakes;
        private System.Windows.Forms.DataGridView dataGridYugosView;
        private System.Windows.Forms.Label label1;
    }
}

