using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class StudentTeacher
{
 public string Id { get; set; } = Guid.NewGuid().ToString();

 public int StudentId {get; set;}
 public virtual Student? Student {get; set;}

 public int TeacherId {get; set;}
 public virtual Teacher? Teacher {get; set;}
}