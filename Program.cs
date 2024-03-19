using System;
using System.Data.SqlClient;

class EmployeeDatabase
{
    public static void Main(string[] args)
    {
        EmployeeDatabase db = new EmployeeDatabase();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        Boolean flag = true;
        int choice = 0;
        String employee_id = null;
        String employee_name = null;
        String employee_dept = null;
        int employee_salary = 0;
        string query = null;
        try
        {
            conn = new SqlConnection("data source =. ; database=Employee; integrated security=SSPI");
            try
            {
                query = "create table EmployeeDB(emp_id varchar(10) not null, emp_name varchar(50), emp_dept varchar(50), emp_salary int)";
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }catch(Exception)
            {
                Console.WriteLine("Table is already Created");
            }
            
            while (flag)
            {
                menu();
                conn = new SqlConnection("data source =. ; database=Employee; integrated security=SSPI");
                choice =Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Enter Employee ID: ");
                    employee_id= Console.ReadLine();
                    Console.WriteLine("Enter Employee Name: ");
                    employee_name = Console.ReadLine();
                    Console.WriteLine("Enter Employee Department: ");
                    employee_dept = Console.ReadLine();
                    Console.WriteLine("Enter Employee Salary: ");
                    employee_salary = Convert.ToInt32(Console.ReadLine());
                    query = "insert into EmployeeDB(emp_id, emp_name, emp_dept, emp_salary) values('" + employee_id + "','" + employee_name + "','" + employee_dept + "','" + employee_salary +"')";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQueryAsync();
                    Console.WriteLine("====== Added Data to EmployeeDB =====");
                    Console.WriteLine("=====================================");
                }
                else if(choice == 2)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Enter Employee ID: ");
                    employee_id = Console.ReadLine();

                    Console.WriteLine("=====================================");
                    Console.WriteLine("====== 1. Update Name ===============");
                    Console.WriteLine("====== 2. Update Department  ========");
                    Console.WriteLine("====== 3. Update Salary  ============");
                    Console.WriteLine("=====================================");

                    int employee_update=Convert.ToInt32(Console.ReadLine());

                    if (employee_update == 1)
                    {
                        Console.WriteLine("Enter Employee Name: ");
                        employee_name = Console.ReadLine();
                        query = "update EmployeeDB set emp_name='" + employee_name+ "' where emp_id='" + employee_id + "'";
                    } 
                    else if (employee_update == 2)
                    {
                        Console.WriteLine("Enter Employee Department: ");
                        employee_dept = Console.ReadLine();
                        query = "update EmployeeDB set emp_dept='" + employee_dept + " where emp_id='" + employee_id + "'";
                    }
                    else if (employee_update == 3)
                    {
                        Console.WriteLine("Enter Employee Salary: ");
                        employee_name = Console.ReadLine();
                        query = "update EmployeeDB set emp_salary='" + employee_salary + " where emp_id=" + employee_id + "'";
                    }
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("=====================================");
                    Console.WriteLine("====== Updated Data to EmployeeDB ===");
                    Console.WriteLine("=====================================");
                }
                else if(choice == 3) 
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Enter Employee ID: ");
                    employee_id = Console.ReadLine();
                    query = "delete from EmployeeDB where emp_id='"+ employee_id+"'";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("===== Deleted Data to EmployeeDB ====");
                    Console.WriteLine("=====================================");
                }
                else if (choice == 4)
                {
                    query = "select * from EmployeeDB";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("=====================================");
                    Console.WriteLine("============ EmployeeDB =============");
                    Console.WriteLine("=====================================\n");
                    while (reader.Read())
                    {
                        Console.WriteLine("Employee ID: " + reader.GetString(0));
                        Console.WriteLine("Employee Name: " + reader.GetString(1));
                        Console.WriteLine("Employee Department: " + reader.GetString(2));
                        Console.WriteLine("Employee Salary: " + reader.GetInt32(3));
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("===== Data Printed - EmployeeDB =====");
                    Console.WriteLine("=====================================");
                }
                else if (choice == 5)
                {
                    flag= false;
                }
                Console.WriteLine("\n\n");

            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
        finally
        {
            conn.Close();
        }   
    }
    public static void menu()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("========= EmployeeDB ================");
        Console.WriteLine("=====================================");
        Console.WriteLine("====== 1. Add new Data ==============");
        Console.WriteLine("====== 2. Update Data  ==============");
        Console.WriteLine("====== 3. Delete Data  ==============");
        Console.WriteLine("====== 4. Show Data    ==============");
        Console.WriteLine("====== 5. Exit         ==============");
        Console.WriteLine("=====================================");
        Console.WriteLine("Choice => ");
    }
}