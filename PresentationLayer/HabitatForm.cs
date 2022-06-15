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
    public partial class HabitatForm : Form
    {
        private DBManager<Habitat, int> dBManager;
        private Habitat selectedHabitat;

        public HabitatForm()
        {
            InitializeComponent();

            dBManager = new DBManager<Habitat, int>(DBContextManager.CreateHabitatContext(DBContextManager.CreateContext()));

            LoadUsers();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedHabitat != null)
                {
                    MessageBox.Show("You can't create duplicated habitat!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string name = txtBox_name.Text;
                    int temperature = (int)numeric_temperature.Value;
                    int area = (int)numeric_area.Value;
                    string food = txtBox_food.Text;
                    string water = txtBox_water.Text;
                    string light = txtBox_light.Text;



                    Habitat habitat = new Habitat(name, temperature, area, food, water, light);

                    dBManager.Create(habitat);
                    MessageBox.Show("Habitat created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("Name, Temperature, Area, Food, Water and Light are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Habitat habitat = new Habitat(selectedHabitat.ID, txtBox_name.Text, (int)numeric_temperature.Value, (int)numeric_area.Value, txtBox_food.Text, txtBox_water.Text, txtBox_light.Text);

                dBManager.Update(habitat);

                MessageBox.Show("Habitat updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("Name, Temperature, Area, Food, Water and Light are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedHabitat != null)
            {
                dBManager.Delete(selectedHabitat.ID);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("You must select habitat!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUsers()
        {
            dataGridView_habitat.DataSource = dBManager.ReadAll();
        }

        private void ClearData()
        {
            txtBox_name.Text = string.Empty;
            numeric_temperature.Value = 0;
            numeric_area.Value = 0;
            txtBox_food.Text = string.Empty;
            txtBox_water.Text = string.Empty;
            txtBox_light.Text = string.Empty;
        }

        private bool ValidateData()
        {
            if (txtBox_name.Text != string.Empty && numeric_temperature.Value == 0 && numeric_area.Value == 0 && txtBox_food.Text != string.Empty && txtBox_water.Text != string.Empty && txtBox_light.Text != string.Empty)
            {
                return true;
            }

            return false;
        }

        private void dataGridView_habitat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView_habitat.Rows[e.RowIndex];

            selectedHabitat = row.DataBoundItem as Habitat;

            txtBox_name.Text = selectedHabitat.Name;
            numeric_temperature.Value = selectedHabitat.Temperature;
            numeric_area.Value = selectedHabitat.Area;
            txtBox_food.Text = selectedHabitat.Food;
            txtBox_water.Text = selectedHabitat.Water;
            txtBox_light.Text = selectedHabitat.Light;
        }
    }
}
