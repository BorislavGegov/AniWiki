
namespace PresentationLayer
{
    partial class HabitatForm
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
            this.txtBox_food = new System.Windows.Forms.TextBox();
            this.txtBox_water = new System.Windows.Forms.TextBox();
            this.txtBox_light = new System.Windows.Forms.TextBox();
            this.numeric_area = new System.Windows.Forms.NumericUpDown();
            this.numeric_temperature = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.dataGridView_habitat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_temperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_habitat)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(164, 30);
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(138, 27);
            this.txtBox_name.TabIndex = 0;
            // 
            // txtBox_food
            // 
            this.txtBox_food.Location = new System.Drawing.Point(164, 188);
            this.txtBox_food.Name = "txtBox_food";
            this.txtBox_food.Size = new System.Drawing.Size(138, 27);
            this.txtBox_food.TabIndex = 1;
            // 
            // txtBox_water
            // 
            this.txtBox_water.Location = new System.Drawing.Point(164, 241);
            this.txtBox_water.Name = "txtBox_water";
            this.txtBox_water.Size = new System.Drawing.Size(138, 27);
            this.txtBox_water.TabIndex = 2;
            // 
            // txtBox_light
            // 
            this.txtBox_light.Location = new System.Drawing.Point(164, 295);
            this.txtBox_light.Name = "txtBox_light";
            this.txtBox_light.Size = new System.Drawing.Size(138, 27);
            this.txtBox_light.TabIndex = 3;
            // 
            // numeric_area
            // 
            this.numeric_area.Location = new System.Drawing.Point(164, 138);
            this.numeric_area.Name = "numeric_area";
            this.numeric_area.Size = new System.Drawing.Size(138, 27);
            this.numeric_area.TabIndex = 4;
            // 
            // numeric_temperature
            // 
            this.numeric_temperature.Location = new System.Drawing.Point(164, 83);
            this.numeric_temperature.Name = "numeric_temperature";
            this.numeric_temperature.Size = new System.Drawing.Size(138, 27);
            this.numeric_temperature.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Food";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Water";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Light";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(54, 357);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(109, 40);
            this.btn_create.TabIndex = 12;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(181, 357);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(110, 40);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(55, 403);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(109, 40);
            this.btn_update.TabIndex = 14;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(181, 403);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(109, 40);
            this.btn_exit.TabIndex = 15;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // dataGridView_habitat
            // 
            this.dataGridView_habitat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_habitat.Location = new System.Drawing.Point(347, 33);
            this.dataGridView_habitat.Name = "dataGridView_habitat";
            this.dataGridView_habitat.RowHeadersWidth = 51;
            this.dataGridView_habitat.RowTemplate.Height = 29;
            this.dataGridView_habitat.Size = new System.Drawing.Size(441, 405);
            this.dataGridView_habitat.TabIndex = 16;
            // 
            // HabitatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_habitat);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_temperature);
            this.Controls.Add(this.numeric_area);
            this.Controls.Add(this.txtBox_light);
            this.Controls.Add(this.txtBox_water);
            this.Controls.Add(this.txtBox_food);
            this.Controls.Add(this.txtBox_name);
            this.Name = "HabitatForm";
            this.Text = "HabitatForm";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_temperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_habitat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_name;
        private System.Windows.Forms.TextBox txtBox_food;
        private System.Windows.Forms.TextBox txtBox_water;
        private System.Windows.Forms.TextBox txtBox_light;
        private System.Windows.Forms.NumericUpDown numeric_area;
        private System.Windows.Forms.NumericUpDown numeric_temperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DataGridView dataGridView_habitat;
    }
}