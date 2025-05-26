namespace CleanArchitecture.Domain.Entities
{
    public class Exercise : BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public int ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public string ProblemUrl { get; set; } = string.Empty;
        public string CorrectionUrl { get; set; } = string.Empty;
        private Exercise(){}
        private Exercise(string title, int chapterId, string problemUrl, string correctionUrl)
        {
            Title = title;
            ChapterId = chapterId;
            ProblemUrl = problemUrl;
            CorrectionUrl = correctionUrl;
        }

        public static Exercise Create(string title, int chapterId, string problemUrl, string correctionUrl)
        {
            return new (title, chapterId, problemUrl, correctionUrl);
        }
    }
}