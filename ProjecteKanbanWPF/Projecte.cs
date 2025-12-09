using ProjecteKanbanWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanbanWPF
{
    internal class Projecte
    {
        private int _id;
        private string _nom;
        private List<Tasca> _tasques;
        private List<Usuari> _usuaris;
        private List<string> _estats;


        public Projecte(string nom)
        {
            _nom = nom;
            _tasques = new List<Tasca>();
            _estats = new List<string> { "Per començar", "En curs", "Finalitzat" };
        }

        public void afegirTasca(Tasca tasca)
        {
            _tasques.Add(tasca);
        }

        public void modificarTasca(Tasca tascaOriginal, Tasca novaTasca)
        {
            _tasques.Remove(tascaOriginal);
            _tasques.Add(novaTasca);
        }

        public List<string> getEstats()
        {
            return _estats;
        }

        public string getNom() {  return _nom; }

        public void esborrarTasca(Tasca tasca)
        {
            _tasques.Remove(tasca);
        }
    }
}
