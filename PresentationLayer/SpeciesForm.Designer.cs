
namespace PresentationLayer
{
    partial class SpeciesForm
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
            this.txtBox_name = new System.Windows.Forms.TextBox();
            this.txtBox_type = new System.Windows.Forms.TextBox();
            this.numeric_lifespan = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.dataGridView_species = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lifespan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_species)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(147, 49);
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(181, 27);
            this.txtBox_name.TabIndex = 0;
            // 
            // txtBox_type
            // 
            this.txtBox_type.Location = new System.Drawing.Point(147, 140);
            this.txtBox_type.Name = "txtBox_type";
            this.txtBox_type.Size = new System.Drawing.Size(181, 27);
            this.txtBox_type.TabIndex = 1;
            // 
            // numeric_lifespan
            // 
            this.numeric_lifespan.Location = new System.Drawing.Point(147, 227);
            this.numeric_lifespan.Name = "numeric_lifespan";
            this.numeric_lifespan.Size = new System.Drawing.Size(181, 27);
            this.numeric_lifespan.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lifespan";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(195, 380);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(133, 58);
            this.btn_exit.TabIndex = 13;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(40, 380);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(133, 58);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(195, 296);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(133, 58);
            this.btn_update.TabIndex = 11;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(40, 296);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(131, 58);
            this.btn_create.TabIndex = 10;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // dataGridView_species
            // 
            this.dataGridView_species.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_species.Location = new System.Drawing.Point(383, 34);
            this.dataGridView_species.Name = "dataGridView_species";
            this.dataGridView_species.RowHeadersWidth = 51;
            this.dataGridView_species.RowTemplate.Height = 29;
            this.dataGridView_species.Size = new System.Drawing.Size(405, 395);
            this.dataGridView_species.TabIndex = 14;
            // 
            // SpeciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_species);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_lifespan);
            this.Controls.Add(this.txtBox_type);
            this.Controls.Add(this.txtBox_name);
            this.Name = "SpeciesForm";
            this.Text = "SpeciesForm";
            this.Load += new System.EventHandler(this.SpeciesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_lifespan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_species)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_name;
        private System.Windows.Forms.TextBox txtBox_type;
        private System.Windows.Forms.NumericUpDown numeric_lifespan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.DataGridView dataGridView_species;
    }
}