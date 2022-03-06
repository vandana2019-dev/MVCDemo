using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GeneralClassLibrary47Framework
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Employee> employees = new List<Employee>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spGetAllEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Gender = reader["Gender"].ToString();
                        employee.City = reader["City"].ToString();

                        if (!(reader["DateOfBirth"] is DBNull)) // If it is not null , then convert it
                        {
                            employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                        }

                        employees.Add(employee);

                    }
                    return employees;
                }
            }
        }

        public void AddEmployee(Employee employee)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee3", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@DateofBirth", employee.DateOfBirth);

                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateEmployee(Employee employee)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee3", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                cmd.Parameters.AddWithValue("@Id", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@DateofBirth", employee.DateOfBirth);

                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteEmployee(int id)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee3", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

            }
        }
    }

}
