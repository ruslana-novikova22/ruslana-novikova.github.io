using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2.Modules
{
    internal class Kadries
    {
        internal class KadryRepository : IRepository<Kadry>
        {
            protected SqlConnection _connection;
            public KadryRepository(SqlConnection connection)
            {
                _connection = connection;
            }
            public List<Kadry> GetAll()
            {
                var kadries = new List<Kadry>();
                string query = "SELECT * FROM Kadry";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kadry k = new Kadry();

                            k.Id = Convert.ToInt32((reader["Id"]));
                            k.Surname = Convert.ToString(reader["Surname"]);
                            k.Department = Convert.ToString(reader["Department"]);
                            k.Job = Convert.ToString(reader["Job"]);
                            k.Gender = Convert.ToString(reader["Gender"]);
                            k.Experience = Convert.ToInt32((reader["Experience"]));
                            k.Salary = Convert.ToDecimal(reader["Salary"]);
                            kadries.Add(k);
                        }
                    }
                }
                return kadries;
            }

            public List<Kadry> GetById(string id)
            {
                var kadries = new List<Kadry>();
                string query = $"SELECT * FROM Kadry WHERE Id = {id}";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kadry k = new Kadry();

                            k.Surname = Convert.ToString(reader["Surname"]);
                            k.Job = Convert.ToString(reader["Job"]);
                            k.Experience = Convert.ToInt32((reader["Experience"]));
                            k.Salary = Convert.ToDecimal(reader["Salary"]);
                            kadries.Add(k);
                        }
                    }
                }
                return kadries;
            }

            public decimal GetAverageSalaryForWomen(string department)
            {
                decimal averageSalary = 0;
                string query = $"SELECT AVG(salary) AS serednya_zarobitna_plata FROM Kadry WHERE department = '{department}' AND gender = 'жінка';";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        averageSalary = Convert.ToDecimal(result);
                    }
                }

                return averageSalary;
            }

        }
    }
}
