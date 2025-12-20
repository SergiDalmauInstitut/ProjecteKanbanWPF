using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjecteKanbanWPF.Objects
{
    public class Tasca : INotifyPropertyChanged
    {
        private long _id;
        private string _name = "Nova tasca";
        private string _description = "Sense descripció.";
        private DateTime _startDate = DateTime.Now;
        private DateTime? _endDate;
        private string _priority = "Baixa";
        private long _idProject;
        private long _idResponsible;
        private long _state;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged();
                }
            }
        }

        public long State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                }
            }
        }

        public long Id
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

        public long IdProject
        {
            get => _idProject;
            set
            {
                if (_idProject != value)
                {
                    _idProject = value;
                    OnPropertyChanged();
                }
            }
        }

        public long IdResponsible
        {
            get => _idResponsible;
            set
            {
                if (_idResponsible != value)
                {
                    _idResponsible = value;
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