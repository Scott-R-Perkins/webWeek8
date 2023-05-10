namespace webWeek8.Models;

public class Course{
    
    public int courseId {get; set;}

    public string? name {get; set;}

    public Tutor? tutorId {get; set;}

    public Student? studentId {get; set;}
}