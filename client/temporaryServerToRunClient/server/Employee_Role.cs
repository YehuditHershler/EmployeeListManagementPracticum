namespace webApi
{
    public class Employee_Role
    {
        public static int toId = 5;
        public int Id {  get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime RoleStartDate { get; set; }
    }
}
