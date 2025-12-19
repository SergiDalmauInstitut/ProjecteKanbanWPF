using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjecteKanbanWPF.Objects
{
    public class Projecte : INotifyPropertyChanged
    {
        private long _id;
        private long _idOwner;
        private string _description = string.Empty;
        private string _name = "Nou projecte";
        private DateTime _lastUpdate = DateTime.Now;
        private DateTime _creationDate = DateTime.Now;
        private List<string> _statesList = ["To do", "Doing", "Revising", "Done"];
        private List<Usuari> _usersList = [];
        private List<Tasca> _taskList = [];

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

        public long IdOwner
        {
            get => _idOwner;
            set
            {
                if (_idOwner != value)
                {
                    _idOwner = value;
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

        public DateTime LastUpdate
        {
            get => _lastUpdate;
            set
            {
                if (_lastUpdate != value)
                {
                    _lastUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                if (_creationDate != value)
                {
                    _creationDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> StatesList
        {
            get => _statesList;
            set
            {
                if (_statesList != value)
                {
                    _statesList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Usuari> UsersList
        {
            get => _usersList;
            set
            {
                if (_usersList != value)
                {
                    _usersList = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Tasca> TaskList
        {
            get => _taskList;
            set
            {
                if (_taskList != value)
                {
                    _taskList = value;
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