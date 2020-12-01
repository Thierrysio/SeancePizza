using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeancePizza.Modeles
{
    public class Composant
    {
        #region Attributs
        public static List<Composant> CollClasseComposant = new List<Composant>();
        private int _id;
        private string _nom;
        private int _quantite;
        private double _prix;

        

        #endregion
        #region Constructeurs
        public Composant(string nom, int quantite, double prix)
        {
            _id = this.NouvelIndex();
            _nom = nom;
            _quantite = quantite;
            _prix = prix;
            Composant.CollClasseComposant.Add(this);
            Nom = nom;
        }

        #endregion
        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public int Quantite { get => _quantite; set => _quantite = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public string Nom { get => _nom; set => _nom = value; }

        #endregion
        #region Methodes
        private int NouvelIndex()
        {
            return Composant.CollClasseComposant.Count + 1;
        }
        #endregion

    }
}
