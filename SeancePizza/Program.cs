using SeancePizza.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeancePizza
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Jeu d'essai
            Client C1 = new Client( "Riri");
            Client C2 = new Client( "Fifi");
            Client C3 = new Client( "Loulou");

            Commande CO1 = new Commande(DateTime.Now,C1);
            Commande CO2 = new Commande(DateTime.Now, C1);
            Commande CO3 = new Commande(DateTime.Now, C1);
            Commande CO4 = new Commande(DateTime.Now, C3);



            Pizza P1 = new Pizza("Calzone", 8.9);
            Pizza P2 = new Pizza("Reine", 7.9);
            Pizza P3 = new Pizza("4 fromages", 9.9);
            Pizza P4 = new Pizza("margharita", 10.9);
            Pizza P5 = new Pizza("Peperoni", 11.9);

            CO1.LesPizzas.Add(P1, 1);
            CO1.LesPizzas.Add(P3, 1);

            CO2.LesPizzas.Add(P2, 1);
            CO2.LesPizzas.Add(P4, 2);
            CO2.LesPizzas.Add(P5, 1);

            CO3.LesPizzas.Add(P1, 3);

            CO4.LesPizzas.Add(P2, 1);
            CO4.LesPizzas.Add(P3, 2);
            CO4.LesPizzas.Add(P4, 1);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
