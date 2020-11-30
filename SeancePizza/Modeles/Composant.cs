using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeancePizza.Modeles
{
    class Composant
    {
        #region Attributs
        public static List<Composant> CollClasseComposant = new List<Composant>();
        private int _id;
        private int _quantite;
        private double _prix;


        #endregion
        #region Constructeurs
        public Composant(int id, int quantite, double prix)
        {
            _id = id;
            _quantite = quantite;
            _prix = prix;
            Composant.CollClasseComposant.Add(this);
        }

        #endregion
        #region Getters Setters
        public int Id { get => _id; set => _id = value; }
        public int Quantite { get => _quantite; set => _quantite = value; }
        public double Prix { get => _prix; set => _prix = value; }

        #endregion
        #region Methodes
        #endregion
    }
}
