using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Selu383.SP26.Api.Models;

public class Location
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public int TableCount { get; set; } = int.MaxValue;
}