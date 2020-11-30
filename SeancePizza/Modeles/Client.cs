using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeancePizza.Modeles
{
    public class Client
    {
        #region Attributs
        public static List<Client> CollClasseClient = new List<Client>();
        private int _id;
        private string _nom;
        private List<Commande> _lesCommandes;

        #endregion
        #region Constructeurs
        public Client( string nom)
        {
            _id = this.NouvelIndex();
            _nom = nom;
            Client.CollClasseClient.Add(this);
            _lesCommandes = new List<Commande>();

        }

        #endregion
        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public List<Commande> LesCommandes { get => _lesCommandes; set => _lesCommandes = value; }

        #endregion
        #region Methodes
        private int NouvelIndex()
        {
            return Client.CollClasseClient.Count + 1;
        }
        public void AjoutCommande(Commande param)
        {
            this.LesCommandes.Add(param);
        }
        #endregion
    }
}
