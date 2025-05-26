namespace CleanArchitecture.Domain.Entities
{
    public class Chapter : BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public int subjectId { get; set; }
        public Subject? Subject { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
        private Chapter(){}
        private Chapter(string title, int subjectId , ICollection<Exercise>? exercises)
        {
            Title = title;
            this.subjectId = subjectId;
            Exercises = exercises ?? new List<Exercise>();
        }

        public static Chapter Create(string title, int subjectId , ICollection<Exercise>? exercises)
        {
            return new (title, subjectId , exercises);
        }

    }
}