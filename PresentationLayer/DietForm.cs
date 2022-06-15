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
    public partial class DietForm : Form
    {
        private DBManager<Diet, int> dBManager;
        private Diet selectedDiet;

        public DietForm()
        {
            InitializeComponent();

            dBManager = new DBManager<Diet, int>(DBContextManager.CreateDietContext(DBContextManager.CreateContext()));

            LoadUsers();
        }

        private void DietForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBox_order_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox_volume_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox_complexity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDiet != null)
                {
                    MessageBox.Show("You can't create duplicated diet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateData())
                {
                    string order = txtBox_order.Text;
                    int volume = (int)numeric_volume.Value;
                    string complexity = txtBox_complexity.Text;


                    Diet diet = new Diet(order, volume, complexity);

                    dBManager.Create(diet);
                    MessageBox.Show("Diet created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();

                    ClearData();
                }
                else
                {
                    MessageBox.Show("Order, Voume and Complexety are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Diet diet = new Diet(selectedDiet.ID, txtBox_order.Text, (int)numeric_volume.Value, txtBox_complexity.Text);

                dBManager.Update(diet);

                MessageBox.Show("Diet updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("Order, Voume and Complexety are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (selectedDiet != null)
            {
                dBManager.Delete(selectedDiet.ID);

                LoadUsers();

                ClearData();
            }
            else
            {
                MessageBox.Show("You must select user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUsers()
        {
            dataGridView_diet.DataSource = dBManager.ReadAll();
        }

        private void ClearData()
        {
            txtBox_order.Text = string.Empty;
            numeric_volume.Value = 0;
            txtBox_complexity.Text = string.Empty;
        }

        private bool ValidateData()
        {
            if (txtBox_order.Text != string.Empty && numeric_volume.Value == 0 && txtBox_complexity.Text != string.Empty)
            {
                return true;
            }

            return false;
        }

        private void dataGridView_diet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView_diet.Rows[e.RowIndex];

            selectedDiet = row.DataBoundItem as Diet;

            txtBox_order.Text = selectedDiet.Order;
            numeric_volume.Value = selectedDiet.Volume;
            txtBox_complexity.Text = selectedDiet.Complexity;
        }
    }
}
