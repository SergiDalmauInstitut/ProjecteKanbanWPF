namespace ProjecteKanbanWPF.Objects
{
    internal class Projecte
    {
        public long Id { get; set; }
        public long IdOwner { get; set; }
        public string Name { get; set; } = "Nou projecte";
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<string> StatesList { get; set; } = [ "To do", "Doing", "Revising", "Done" ];
        public List<Usuari> UsersList { get; set; } = [];
        public List<Tasca> TaskList { get; set; } = [];
    }
}