
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_species
            // 
            this.btn_species.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_species.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_species.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_species.Location = new System.Drawing.Point(248, 106);
            this.btn_species.Name = "btn_species";
            this.btn_species.Size = new System.Drawing.Size(134, 104);
            this.btn_species.TabIndex = 0;
            this.btn_species.Text = "Species";
            this.btn_species.UseVisualStyleBackColor = false;
            this.btn_species.Click += new System.EventHandler(this.btn_species_Click);
            // 
            // btn_habitat
            // 
            this.btn_habitat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_habitat.Location = new System.Drawing.Point(434, 106);
            this.btn_habitat.Name = "btn_habitat";
            this.btn_habitat.Size = new System.Drawing.Size(134, 104);
            this.btn_habitat.TabIndex = 1;
            this.btn_habitat.Text = "Habitat";
            this.btn_habitat.UseVisualStyleBackColor = false;
            this.btn_habitat.Click += new System.EventHandler(this.btn_habitat_Click);
            // 
            // btn_diet
            // 
            this.btn_diet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_diet.Location = new System.Drawing.Point(341, 249);
            this.btn_diet.Name = "btn_diet";
            this.btn_diet.Size = new System.Drawing.Size(134, 104);
            this.btn_diet.TabIndex = 2;
            this.btn_diet.Text = "Diet";
            this.btn_diet.UseVisualStyleBackColor = false;
            this.btn_diet.Click += new System.EventHandler(this.btn_diet_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(341, 441);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(134, 33);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(341, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "AniWiki";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_diet);
            this.Controls.Add(this.btn_habitat);
            this.Controls.Add(this.btn_species);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_species;
        private System.Windows.Forms.Button btn_habitat;
        private System.Windows.Forms.Button btn_diet;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
    }
}