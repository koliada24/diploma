namespace UserProfiles.API.Database.Entities;

public class StudentsGroup
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Guid> StudentIds { get; set; } = [];
    public Guid CreatedBy { get; set; }
}