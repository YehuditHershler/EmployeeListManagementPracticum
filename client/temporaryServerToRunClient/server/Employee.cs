using webApi;
using System.Data;

public class Employee
{
    public static int toId = 12;
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? TZ { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    //public List<Role> Roles { get; set; }
    public bool Status { get; set; }
}

public enum Gender
{
    Male,
    Female
}

