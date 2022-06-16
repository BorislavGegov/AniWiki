using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class SpeciesForm : Form
    {
        private DBManager<Species, int> dBManager;
        private Species selectedSpecies;

        public SpeciesForm()
        {
            InitializeComponent();

            dBManager = new DBManager<Species, int>(DBContextManager.CreateSpeciesContext(DBContextManager.CreateContext()));

            LoadUsers();
        }

        private void SpeciesForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSpecies != null)
                {
                    MessageBox.Show("You can't create a duplicated species!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string name = txtBox_name.Text;
                    string type = txtBox_type.Text;
                    int lifespan = (int)numeric_lifespan.Value;


                    Species species = new Species(name, type, lifespan);

                    dBManager.Create(species);
                    MessageBox.Show("Species created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("Name, Type and Lifespan are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Species species = new Species(selectedSpecies.ID, txtBox_name.Text, txtBox_type.Text, (int)numeric_lifespan.Value);

                dBManager.Update(species);

                MessageBox.Show("Species updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("Name, Type and Lifespan are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedSpecies != null)
            {
                dBManager.Delete(selectedSpecies.ID);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("You must select a species!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            dataGridView_species.DataSource = dBManager.ReadAll();
        }

        private void ClearData()
        {
            txtBox_name.Text = string.Empty;
            txtBox_type.Text = string.Empty;
            numeric_lifespan.Value = 0;
        }

        private bool ValidateData()
        {
            if (txtBox_name.Text != string.Empty && txtBox_type.Text != string.Empty && numeric_lifespan.Value == 0)
            {
                return true;
            }

            return false;
        }

        private void dataGridView_species_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView_species.Rows[e.RowIndex];

            selectedSpecies = row.DataBoundItem as Species;

            txtBox_name.Text = selectedSpecies.Name;
            txtBox_type.Text = selectedSpecies.Type;
            numeric_lifespan.Value = selectedSpecies.Lifespan;
        }
    }
}
