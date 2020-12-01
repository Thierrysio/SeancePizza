using SeancePizza.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeancePizza.Vues
{
    public partial class Form2 : Form
    {
        private  Commande laCommande;
        public Form2(Commande param)
        {
            InitializeComponent();
            laCommande = param;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Commande n° " + laCommande.Id.ToString();
            this.PizzaDGV();
        }

        private void PizzaDGV()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("Prix", typeof(double));

            foreach (Pizza unePizza in Pizza.CollClassePizza)
            {
                dt.Rows.Add(unePizza.Id, unePizza.Nom, unePizza.Prix);
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow ligne = dataGridView1.Rows[e.RowIndex];

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("quantite", typeof(int));

            foreach (Composant unComposant in this.GetPizza(ligne.Cells[0].Value.ToString()).LesComposants)
            {
                dt.Rows.Add(unComposant.Id, unComposant.Nom, unComposant.Quantite);
            }

            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow ligne = dataGridView1.Rows[e.RowIndex];

            if(laCommande.LesPizzas.ContainsKey(this.GetPizza(ligne.Cells[0].Value.ToString())))
            {
                laCommande.LesPizzas[this.GetPizza(ligne.Cells[0].Value.ToString())] += 1;

            }
            else 
            {
                laCommande.LesPizzas.Add(this.GetPizza(ligne.Cells[0].Value.ToString()), 1);
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("Quantité", typeof(int));
            dt.Columns.Add("Prix", typeof(double));
            dt.Columns.Add("Montant", typeof(string));
            double r = 0;
            foreach (KeyValuePair<Pizza, int> unePizza in laCommande.LesPizzas)
            {
                dt.Rows.Add(unePizza.Key.Id, unePizza.Key.Nom, unePizza.Value, unePizza.Key.Prix, string.Format("{0:N2} Euro", (unePizza.Key.Prix* unePizza.Value)));
                r += unePizza.Key.Prix * unePizza.Value;
            }
            label4.Text = string.Format("Le montant de la commande  est de {0:N2} Euro", (r));
            dataGridView3.DataSource = dt;

        }
        public Pizza GetPizza(string param)
        {
            Pizza pizzaData = null;

            foreach (Pizza unePizza in Pizza.CollClassePizza)
            {
                if (unePizza.Id.Equals(Convert.ToInt32( param)))
                {
                    pizzaData = unePizza;
                    break;
                }
            }
            return pizzaData;
        }
    }
}
