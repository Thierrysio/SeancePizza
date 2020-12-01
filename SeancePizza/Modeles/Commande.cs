using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeancePizza.Modeles
{
    public class Commande
    {
        #region Attributs
        public static List<Commande> CollClasseCommande = new List<Commande>();
        private int _id;
        private DateTime _laDate;
        private Client _leClient;
        private Dictionary<Pizza, int> _lesPizzas;

       
        #endregion
        #region Constructeurs
        public Commande( DateTime laDate, Client leClient)
        {
            _id = this.NouvelIndex(); ;
            _laDate = laDate;
            _leClient = leClient;
            Commande.CollClasseCommande.Add(this);
            _lesPizzas = new Dictionary<Pizza, int>();
            _leClient.AjoutCommande(this);
        }
        #endregion
        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime LaDate { get => _laDate; set => _laDate = value; }
        public Client LeClient { get => _leClient; set => _leClient = value; }
        public Dictionary<Pizza, int> LesPizzas { get => _lesPizzas; set => _lesPizzas = value; }

        #endregion
        #region Methodes
        private int NouvelIndex()
        {
            return Commande.CollClasseCommande.Count + 1;
        }
        #endregion
    }
}
