using Microsoft.Data.SqlClient;

namespace StudentsController
    {
    public class StudentController
        {

        public string ConnectionString { get; set; }
        public SqlConnection SqlConnection { get; set; }

        public bool ChangeStudent(Student student)
            {
            var sql = "UPDATE Student SET"
                + $" Firstname = '{student.FirstName}'," +
                $" Lastname = '{student.LastName}', " +
                $" Statecode = '{student.StateCode}', " +
                $" SAT = {student.SAT}, " +
                $" GPA = {student.GPA}," +
                $" MajorId = {student.MajorId} " +
                $" where ID = {student.Id};";

            var cmd = new SqlCommand(sql, SqlConnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
                {
                throw new Exception("your thingy broke, more than 1  attempted to be added");
                }
            return true;
            }

        public bool AddStudent(Student student)
            {
            //check that the connection is established
            var sql =  "Insert Student " 
                +" (Firstname, Lastname, Statecode, SAT, GPA, MajorId) "
                +" Values"
                +$"('{student.FirstName}', '{student.LastName}','{student.StateCode}', " +
                $"{student.SAT}, {student.GPA}, {student.MajorId})";

            var cmd  = new SqlCommand(sql, SqlConnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1)
                {
                throw new Exception("your thingy broke, more than 1  attempted to be added");
                }
            return true;
            }


        public void OpenConnection()
            {
            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
            if (SqlConnection.State != System.Data.ConnectionState.Open)
                {
                throw new Exception("Connection did not open!");
                }
            }

        public void CloseConnection()
            {
            SqlConnection.Close();
            }
        
        public StudentController(string ServerInstance, string Database)
            {
            ConnectionString = $"server={ServerInstance};"
                + $"database = {Database};"
                + "TrustServerCertificate=True;"
                + "trusted_connection=true;";
            }

        
        }
    }