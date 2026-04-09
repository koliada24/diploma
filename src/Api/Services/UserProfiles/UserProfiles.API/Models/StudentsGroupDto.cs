namespace UserProfiles.API.Models;

public class StudentsGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Guid> StudentIds { get; set; } = [];
    public Guid CreatedBy { get; set; }
}