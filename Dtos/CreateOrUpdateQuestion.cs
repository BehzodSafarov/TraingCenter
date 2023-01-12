using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.Dtos;

public class CreateOrUpdateQuestion
{
    [Required]
    public Level Level { get; set; }
    [Required]
    public string? Title { get; set; }
  
    [Required]
    public string? AOption { get; set; }
    [Required]
    public string? BOption { get; set; }
    [Required]
    public string? COption { get; set; }
    [Required]
    public string? DOption { get; set; }
    [Required]
    public string? RightOption { get; set; }
}