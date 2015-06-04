using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ChAssignment3_Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("{0} {1} {2} {3}",
                       " To get car info enter 1:" + Environment.NewLine,
                       "To Insert new car enter 2:" + Environment.NewLine,
                       "To Update car enter 3:" + Environment.NewLine ,
                       "To delete car enter 4:"));
            string input = Console.ReadLine();

            if(input == "1")
            {
                Console.WriteLine("Please enter the car Id");
                string id = Console.ReadLine();
                int carId = Int32.Parse(id);
                List<Car> car = GetCar(carId);
                FindCarByCarId(car, carId);
                Console.Read();
            }

            if (input == "2")
            {
                Console.WriteLine("Please input the car Name,Model,Year,and Color follow each value by comma");
                string newCarInfo = Console.ReadLine();
                InsertCar(newCarInfo);

            }

            if (input == "3")
            {
                Console.WriteLine("Please input the car Name,Model,Year,Id and Color follow each value by comma");
            }

            if (input == "4")
            {
                Console.WriteLine("Please enter the car Id you wish to delete");
                string id = Console.ReadLine();
                int carId = Int32.Parse(id);
                DeleteCar(carId);
            }
        }


        public static void FindCarByCarId(List<Car> carList, int carId)
        {
            foreach (Car car in carList)
            {
                if (car.Id == carId)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3}",
                        car.Name,
                        car.Model,
                        car.Year,
                        car.Color));
                }
            }
        }


        public int InsertCar(Car car)
        {

            List<Car> carList = new List<Car>();
            Car theCar = new Car();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Usp_InsertCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = theCar.Name;
            command.Parameters.AddWithValue("@Model", SqlDbType.VarChar).Value = theCar.Model;
            command.Parameters.AddWithValue("@Year", SqlDbType.VarChar).Value = theCar.Year;
            command.Parameters.AddWithValue("@Color", SqlDbType.VarChar).Value = theCar.Color;

            connection.Open();
            return theCar.Id;

        }

        public void UpdateCar(Car car)
        {
            SqlDataReader reader = CreateCommand("Usp_DeleteCar" + car, GetConnectionString());
        }

        public static void DeleteCar(int Id)
        {
            List<Car> car = new List<Car>();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Usp_DeleteCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id;

            connection.Open();
            command.ExecuteNonQuery();
        }

        public static List<Car> GetCar(int Id)
        {
            List<Car> car = new List<Car>();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Usp_GetCar", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Car theCar = new Car();

                        theCar.Id = Convert.ToInt16(reader["Id"]);
                        theCar.Name = reader["Name"].ToString();
                        theCar.Model = reader["Model"].ToString();
                        theCar.Year = reader["Year"].ToString();
                        theCar.Color = reader["Color"].ToString();


                        car.Add(theCar);
                    }

                }

                else
                {
                    Console.WriteLine("No rows found.");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return car;
        }

        static private string GetConnectionString()
        {
            return "Data Source=(local); Initial Catalog=Cars;" + "Integrated Security=true;";
        }


        private static SqlDataReader CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
        }
    }
}
