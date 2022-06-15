using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_species_Click(object sender, EventArgs e)
        {
            SpeciesForm speciesForm = new SpeciesForm();
            speciesForm.Show();
        }

        private void btn_habitat_Click(object sender, EventArgs e)
        {
            HabitatForm habitatForm = new HabitatForm();
            habitatForm.Show();
        }

        private void btn_diet_Click(object sender, EventArgs e)
        {
            DietForm dietForm = new DietForm();
            dietForm.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
