using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using TEST_ADO_MVC.Models;

namespace TEST_ADO_MVC.DAL
{
    //DAL- DATA ACCESS LAYER. Это слой доступа к данным в БД.
    //Здесь происходит подключение к БД и вытягивание из неё данных, далее данные передаются в контроллер.
    public class Timesheets_DAL
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        public static IConfiguration Configuration { get; set; }
        private string GetConnectionString()
        {
            //Метод который берёт строку подключения к БД из файла appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefalutConnection");
        }

        public List<Timesheets> GetAll()//Метод получения всех записей из таблицы в БД.
        {
            List<Timesheets>timesheetsList = new List<Timesheets>();
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Get_TH_new]";//Хранимая процедура из БД, отвечающая за получение всех строк данных из основной таблицы.
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Timesheets timesheets = new Timesheets();
                    timesheets.id = Convert.ToInt32(reader["id"]);
                    timesheets.employee = Convert.ToInt32(reader["employee"]);
                    timesheets.reason = Convert.ToInt32(reader["reason"]);
                    timesheets.start_date = Convert.ToDateTime(reader["start_date"]).Date;
                    timesheets.duration = Convert.ToInt32(reader["duration"]);
                    timesheets.discounted = Convert.ToBoolean(reader["discounted"]);
                    timesheets.description = reader["description"].ToString();
                    timesheets.name_employee = reader["fullnmae"].ToString();
                    timesheetsList.Add(timesheets);

                }
                connection.Close();
            }
            return timesheetsList;
        }

        public List<Employee> GetEmployees()//Метод получения списка сотрудников.
        {
            List<Employee> employeesList = new List<Employee>();
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Get_Emp]";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.id = Convert.ToInt32(reader["id"]);
                    employee.last_name = reader["last_name"].ToString();
                    employee.first_name = reader["first_name"].ToString();
                    employeesList.Add(employee);
                }
                connection.Close();
            }
            return employeesList;
        }

        public bool Insert(Timesheets model)//Метод вставки данных в основную таблицу БД.
        {
            int loc_s = 0;
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Insert_TH]";
                command.Parameters.AddWithValue("@id", model.id);
                command.Parameters.AddWithValue("@employee", model.employee);
                command.Parameters.AddWithValue("@reason", model.reason);
                command.Parameters.AddWithValue("@start_date", model.start_date);
                command.Parameters.AddWithValue("@duration", model.duration);
                command.Parameters.AddWithValue("@discounted", model.discounted);
                command.Parameters.AddWithValue("@description", model.description);
                connection.Open();
                loc_s = command.ExecuteNonQuery();
                connection.Close();
            }
            return loc_s > 0 ? true : false;
        }


        public Timesheets GetbyId(int id)//Метод получения одной строки по определённому id.
        {
            Timesheets timesheets = new Timesheets();
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Get_TH_by_Id]";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    timesheets.id = Convert.ToInt32(reader["id"]);
                    timesheets.employee = Convert.ToInt32(reader["employee"]);
                    timesheets.reason = Convert.ToInt32(reader["reason"]);
                    timesheets.start_date = Convert.ToDateTime(reader["start_date"]).Date;
                    timesheets.duration = Convert.ToInt32(reader["duration"]);
                    timesheets.discounted = Convert.ToBoolean(reader["discounted"]);
                    timesheets.description = reader["description"].ToString();

                }
                connection.Close();
            }
            return timesheets;
        }

        public bool Update(Timesheets model)//Метод изменения данных в выбранной записи.
        {
            int loc_s = 0;
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Update_TH]";
                command.Parameters.AddWithValue("@id", model.id);
                command.Parameters.AddWithValue("@employee", model.employee);
                command.Parameters.AddWithValue("@reason", model.reason);
                command.Parameters.AddWithValue("@start_date", model.start_date);
                command.Parameters.AddWithValue("@duration", model.duration);
                command.Parameters.AddWithValue("@discounted", model.discounted);
                command.Parameters.AddWithValue("@description", model.description);
                connection.Open();
                loc_s = command.ExecuteNonQuery();
                connection.Close();
            }
            return loc_s > 0 ? true : false;
        }

        public bool Delete(int id)//Метод удаления данных определённой записи из БД.
        {
            int loc_s = 0;
            using (connection = new SqlConnection(GetConnectionString()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Delete_TH]";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                loc_s = command.ExecuteNonQuery();
                connection.Close();
            }
            return loc_s > 0 ? true : false;
        }
    }
}
