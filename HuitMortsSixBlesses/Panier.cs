using HuitMortsSixBlesses.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    /// <summary>
    /// Représente un panier composé de lignes
    /// </summary>
    public abstract class Panier : IEnumerable<Ligne>
    {
        /// <summary>
        /// Pour stocker les <see cref="Ligne"/>s en interne
        /// </summary>
        public List<Ligne> lesLignes;

        /// <summary>
        /// ID du Panier dans la BDD
        /// </summary>

        public int ID { get; set; }

        //indexeur
        /// <summary>
        /// Retourne la <see cref="Ligne"/> à l'index donné
        /// </summary>
        /// <param name="index">index de la <see cref="Ligne"/> voulu</param>
        /// <returns>un <see cref="Ligne"/></returns>
        public Ligne this[int index]
        {
            get { return lesLignes[index]; }
            private set { lesLignes[index] = value; }
        }

        //pour aller avec et permettre de faire un for
        /// <summary>
        /// Retourne le nombre de points du polygone
        /// Utile pour faire un for avec l'indexeur !
        /// </summary>
        public int Count
        {
            get { return lesLignes.Count; }
        }

        /// <summary>
        /// Constructeur de Panier
        /// 1 <see cref="Ligne"/>s minimum obligatoire
        /// </summary>
        /// <param name="a">1er <see cref="Ligne"/></param>
        /// <param name="autresLignes">D'autres <see cref="Ligne"/>s éventuelles</param>
        public Panier(List<Ligne> mesLignes)
        {
            lesLignes.AddRange(mesLignes);

            foreach (var item in lesLignes)
            {
                if (item==null)
                {
                    throw new PanierException("Une des lignes est null :(", TypesDePaniers.Panier);
                }
            }
        }

        public Panier(int id, List<Ligne> mesLignes)
            :this(mesLignes)
        {
            ID = id;
        }


        public void ArrangerPanier(List<Ligne> maListedeLignes)//Je veux que chaque ligne regarde si elle a des doublons dans son panier
        {
       
            for (int i = 0; i < maListedeLignes.Count; i++)
            {
                for (int j = 0; j < maListedeLignes.Count; j++)
                {
                    maListedeLignes[j].EviterDoublon(maListedeLignes[i]);
                    
                }
            }
            
        }
        


        /// <summary>
        /// Pour pouvoir faire un foreach sur le polygone
        /// imposé par l'implémentation de l'interface <see cref="IEnumerable{Ligne}"/>
        /// </summary>
        /// <returns>Une énumération de <see cref="Ligne"/>s</returns>
        public IEnumerator<Ligne> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }
        /// <summary>
        /// Vielle syntaxe imposée par l'interface <see cref="IEnumerable{Ligne}"/>
        /// On retourne simplement la méthode <see cref="GetEnumerator"/> développée au dessus
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        public override string ToString() => $"[{string.Join(";", this)}]";
    }
}
