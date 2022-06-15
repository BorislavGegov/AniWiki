
namespace PresentationLayer
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
            this.btn_species = new System.Windows.Forms.Button();
            this.btn_habitat = new System.Windows.Forms.Button();
            this.btn_diet = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_species
            // 
            this.btn_species.Location = new System.Drawing.Point(213, 87);
            this.btn_species.Name = "btn_species";
            this.btn_species.Size = new System.Drawing.Size(150, 104);
            this.btn_species.TabIndex = 0;
            this.btn_species.Text = "Species";
            this.btn_species.UseVisualStyleBackColor = true;
            this.btn_species.Click += new System.EventHandler(this.btn_species_Click);
            // 
            // btn_habitat
            // 
            this.btn_habitat.Location = new System.Drawing.Point(213, 286);
            this.btn_habitat.Name = "btn_habitat";
            this.btn_habitat.Size = new System.Drawing.Size(150, 104);
            this.btn_habitat.TabIndex = 1;
            this.btn_habitat.Text = "Habitat";
            this.btn_habitat.UseVisualStyleBackColor = true;
            this.btn_habitat.Click += new System.EventHandler(this.btn_habitat_Click);
            // 
            // btn_diet
            // 
            this.btn_diet.Location = new System.Drawing.Point(452, 87);
            this.btn_diet.Name = "btn_diet";
            this.btn_diet.Size = new System.Drawing.Size(150, 104);
            this.btn_diet.TabIndex = 2;
            this.btn_diet.Text = "Diet";
            this.btn_diet.UseVisualStyleBackColor = true;
            this.btn_diet.Click += new System.EventHandler(this.btn_diet_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(452, 286);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(150, 104);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_diet);
            this.Controls.Add(this.btn_habitat);
            this.Controls.Add(this.btn_species);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_species;
        private System.Windows.Forms.Button btn_habitat;
        private System.Windows.Forms.Button btn_diet;
        private System.Windows.Forms.Button btn_exit;
    }
}