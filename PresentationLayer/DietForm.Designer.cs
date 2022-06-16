
namespace PresentationLayer
{
    partial class DietForm
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
            this.txtBox_order = new System.Windows.Forms.TextBox();
            this.txtBox_complexity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.dataGridView_diet = new System.Windows.Forms.DataGridView();
            this.numeric_volume = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_diet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_volume)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_order
            // 
            this.txtBox_order.Location = new System.Drawing.Point(164, 28);
            this.txtBox_order.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_order.Name = "txtBox_order";
            this.txtBox_order.Size = new System.Drawing.Size(116, 23);
            this.txtBox_order.TabIndex = 0;
            this.txtBox_order.TextChanged += new System.EventHandler(this.txtBox_order_TextChanged);
            // 
            // txtBox_complexity
            // 
            this.txtBox_complexity.Location = new System.Drawing.Point(164, 126);
            this.txtBox_complexity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_complexity.Multiline = true;
            this.txtBox_complexity.Name = "txtBox_complexity";
            this.txtBox_complexity.Size = new System.Drawing.Size(116, 44);
            this.txtBox_complexity.TabIndex = 2;
            this.txtBox_complexity.TextChanged += new System.EventHandler(this.txtBox_complexity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Complexity";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(37, 208);
            this.btn_create.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(121, 46);
            this.btn_create.TabIndex = 6;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(188, 208);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(120, 46);
            this.btn_update.TabIndex = 7;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(37, 269);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(121, 48);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(188, 269);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(120, 48);
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // dataGridView_diet
            // 
            this.dataGridView_diet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_diet.Location = new System.Drawing.Point(352, 30);
            this.dataGridView_diet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_diet.Name = "dataGridView_diet";
            this.dataGridView_diet.RowHeadersWidth = 51;
            this.dataGridView_diet.RowTemplate.Height = 29;
            this.dataGridView_diet.Size = new System.Drawing.Size(338, 287);
            this.dataGridView_diet.TabIndex = 10;
            this.dataGridView_diet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_diet_CellClick);
            // 
            // numeric_volume
            // 
            this.numeric_volume.Location = new System.Drawing.Point(164, 80);
            this.numeric_volume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numeric_volume.Name = "numeric_volume";
            this.numeric_volume.Size = new System.Drawing.Size(116, 23);
            this.numeric_volume.TabIndex = 11;
            // 
            // DietForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.numeric_volume);
            this.Controls.Add(this.dataGridView_diet);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_complexity);
            this.Controls.Add(this.txtBox_order);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DietForm";
            this.Text = "DietForm";
            this.Load += new System.EventHandler(this.DietForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_diet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_order;
        private System.Windows.Forms.TextBox txtBox_complexity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DataGridView dataGridView_diet;
        private System.Windows.Forms.NumericUpDown numeric_volume;
    }
}