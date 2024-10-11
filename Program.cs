using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    { 
        var employees = GetEmployees();
        var departments = GetDepartments();


        foreach (var employee in from emp in employees
                                 join dep in departments
                                 on emp.DepartmentId equals dep.Id
                                 select new
                                 {
                                     Firstname = emp.FirstName,
                                     Lastname = emp.LastName,
                                     DepartmentName = dep.Longname
                                 })
        {
            System.Console.WriteLine($"Firstname: {employee.Firstname}");
             System.Console.WriteLine($"Laststname: {employee.Lastname}");
            System.Console.WriteLine($"Department: {employee.DepartmentName}");
            System.Console.WriteLine();
        }
    }

public static List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "TestAA",
            LastName = "test",
            IsManager = false,
            Salary = 20000,
            DepartmentId = 1
        };

        employees.Add(employee);

        employee = new Employee
        {
            Id = 2,
            FirstName = "TestBB",
            LastName = "test",
            IsManager = false,
            Salary = 25000,
            DepartmentId = 2
        };

        employees.Add(employee);

        employee = new Employee
        {
            Id =3,
            FirstName = "TestCC",
            LastName = "test",
            IsManager = true,
            Salary = 30000,
            DepartmentId = 1
        };

        employees.Add(employee);

        employee = new Employee
        {
            Id = 4,
            FirstName = "TestDD",
            LastName = "test",
            IsManager = false,
            Salary = 35000,
            DepartmentId = 1
        };

        employees.Add(employee);

        return employees;
    }

    public static List<Department> GetDepartments()
    {
        var departments = new List<Department>();

        Department department = new Department
        {
            Id = 1,
            Shortname = "HR",
            Longname = "Human Resource"
        };

        departments.Add(department);

        department = new Department
        {
            Id = 2,
            Shortname = "IT",
            Longname = "Information Technology"
        };

        departments.Add(department);


        return departments;
    }
    public class Department
    {
        public int Id { get; set; }
        public string? Shortname { get; set; }
        public string? Longname { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsManager { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}