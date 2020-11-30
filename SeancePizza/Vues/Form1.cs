using SeancePizza.Modeles;
using SeancePizza.Vues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeancePizza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ChargerComboBox();
        }
        private void ChargerComboBox()
        {
            ///Process
            /// 1 - les clients sont dans la collclass
            /// 2 - balayer la collclass
            /// 3 - integrer dans le combo le nouvel item
            /// 
            foreach(Client unClient in Client.CollClasseClient)
            {
                comboBox1.Items.Add(unClient.Nom);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// Process
            /// 1 - Recuperer le contenu du combobox
            /// 2 - Recuperer l'adresse de l'objet correspondant au text
            /// 3 - Envoyer dans les textbox les datas
            /// 4 - Afficher dans le DGV les commandes deja passées
            /// 
            

            textBox1.Text = this.GetClient(comboBox1.Text).Id.ToString();
            textBox2.Text = this.GetClient(comboBox1.Text).Nom;

            this.SetDGVCommandesPassees(this.GetClient(comboBox1.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// 1 - effacer les informations contenues dans les box
            /// 2 - cacher les 3 boutons
            /// 3 - deployer le bouton valider la creation
            /// 4 - creer l'objet client
            /// 5 - mettre à jour le combobox
            /// 6 - cacher e bouton valider la creation
            /// 7 - afficher les 3 boutons
            textBox1.Text = "";
            textBox2.Text = "";

            button1.Hide();
            button2.Hide();
            button3.Hide();

            button5.Visible = true;

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Client(textBox2.Text);

            comboBox1.Items.Clear();
            this.ChargerComboBox();

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

            button5.Hide();
        }

        private void SetDGVCommandesPassees(Client param)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            

            foreach (Commande uneCommande in param.LesCommandes)
            {
                dt.Rows.Add(uneCommande.Id, uneCommande.LaDate);
            }

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Application.Run(new Form2(new Commande(DateTime.Now, this.GetClient(comboBox1.Text))));
        }

        public Client GetClient(string param)
        {
            Client clientData = null;

            foreach (Client unClient in Client.CollClasseClient)
            {
                if (unClient.Nom.Equals(param))
                {
                    clientData = unClient;
                    break;
                }
            }
            return clientData;
        }
    }
}
