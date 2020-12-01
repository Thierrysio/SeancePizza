using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeancePizza.Modeles
{
    public class Pizza
    {
        #region Attributs
        public static List<Pizza> CollClassePizza = new List<Pizza>();
        private int _id;
        private string _nom;
        private double _prix;
        private List<Composant> _lesComposants;

        #endregion
        #region Constructeurs
        public Pizza(
            string nom, double prix)
        {
            _id = this.NouvelIndex(); ;
            _nom = nom;
            _prix = prix;
            Pizza.CollClassePizza.Add(this);
            _lesComposants = new List<Composant>();
        }

        #endregion
        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public List<Composant> LesComposants { get => _lesComposants; set => _lesComposants = value; }

        #endregion
        #region Methodes
        private int NouvelIndex()
        {
            return Pizza.CollClassePizza.Count + 1;
        }
        #endregion
    }
}
