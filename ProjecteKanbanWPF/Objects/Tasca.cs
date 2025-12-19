using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjecteKanbanWPF.Objects
{
    public class Tasca : INotifyPropertyChanged
    {
        private int _id;
        private string _nom = "Nova tasca";
        private string _descripcio = "Sense descripció.";
        private string _etiquetes = string.Empty;
        private DateTime? _dataInici;
        private DateTime? _dataFi;
        private string _prioritat = "Baixa";
        private int _estat;

        public string Nom
        {
            get => _nom;
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Descripcio
        {
            get => _descripcio;
            set
            {
                if (_descripcio != value)
                {
                    _descripcio = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Etiquetes
        {
            get => _etiquetes;
            set
            {
                if (_etiquetes != value)
                {
                    _etiquetes = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? DataInici
        {
            get => _dataInici;
            set
            {
                if (_dataInici != value)
                {
                    _dataInici = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? DataFi
        {
            get => _dataFi;
            set
            {
                if (_dataFi != value)
                {
                    _dataFi = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Prioritat
        {
            get => _prioritat;
            set
            {
                if (_prioritat != value)
                {
                    _prioritat = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Estat
        {
            get => _estat;
            set
            {
                if (_estat != value)
                {
                    _estat = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}