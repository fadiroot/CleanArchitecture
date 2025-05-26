namespace CleanArchitecture.Domain.Entities;

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

    public static Level Create(string name , ICollection<Subject>? subjects)
    {
        return new (name, subjects);
    }
    
}
