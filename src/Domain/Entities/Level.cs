namespace CleanArchitecture.Domain.Entities
{
    public class Level : BaseAuditableEntity
    {
        public string Name { get; set; } = String.Empty;
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        private Level(){}
        private Level(string name , ICollection<Subject>? subjects)
        {
            Name = name;
            Subjects = subjects ?? new List<Subject>();
        }

        public static Level Create(string name , ICollection<Subject>? subjects = null)
        {
            return new (name, subjects);
        }

        public static Level Update(Level level, string name, ICollection<Subject>? subjects = null)
        {
            level.Name = name;
            level.Subjects = subjects ?? new List<Subject>();
            return level;
        } 
    
    }
}
