namespace CleanArchitecture.Domain.Entities
{
    public class Subject : BaseAuditableEntity
    {
        public string Name { get; set; } = String.Empty;
        public int LevelId { get; set; }
        public Level? Level { get; set; }
        public string Icon { get; set; } = String.Empty;
        public ICollection<Chapter>? Chapters { get; set; } 

        public Subject() { }
        private Subject(string name,int levelId, string icon , ICollection<Chapter>? chapters)
        {
            Name = name;
            LevelId = levelId;
            Icon = icon;
            Chapters = chapters ?? new List<Chapter>();
        }

        public static Subject Create(string name,int levelId, string icon , ICollection<Chapter>? chapters)
        {
            return new (name,levelId ,  icon , chapters);
        }
    }
}