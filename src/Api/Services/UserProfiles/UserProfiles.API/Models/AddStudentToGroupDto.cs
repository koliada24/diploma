using System.ComponentModel.DataAnnotations;

namespace UserProfiles.API.Models;

public class AddStudentToGroupDto
{
    [Required(ErrorMessage = "GroupId is required")]
    public Guid GroupId { get; set; }
    
    [Required(ErrorMessage = "StudentId is required")]
    public Guid StudentId { get; set; }
}