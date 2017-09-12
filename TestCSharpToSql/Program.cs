using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CSharpToSql;

namespace TestCSharpToSql {
	class Program {

		void Run() {
			string connStr = @"Server=DSI-Workstation\SQLEXPRESS;Database=DotNetDatabase;Trusted_Connection=yes";
			SqlConnection connection = new SqlConnection(connStr);
			connection.Open();
			if(connection.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("SQL Connection did not open");
				return;
			}
			Console.WriteLine("SQL connection opened successfully");
			var sql = "select * from Student";
			SqlCommand cmd = new SqlCommand(sql, connection);
			SqlDataReader reader = cmd.ExecuteReader();
			List<Student> students = new List<Student>();
			while(reader.Read()) {
				var id = reader.GetInt32(reader.GetOrdinal("Id"));
				var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
				var lastName = reader.GetString(reader.GetOrdinal("LastName"));
				var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
				var address = reader.GetString(reader.GetOrdinal("Address"));

				// set major id to null value before reading the database value.
				var majorId = 0;
				// check the value in the database
				// if it is NOT NULL
				if(!reader.GetValue(reader.GetOrdinal("MajorId")).Equals(DBNull.Value)) {
					// then do this
					majorId = reader.GetInt32(reader.GetOrdinal("MajorId"));
				}

				Console.WriteLine($"{id}, {firstName} {lastName}, born of {birthday}");
				Student student = new Student();
				student.Id = id;
				student.FirstName = firstName;
				student.LastName = lastName;
				student.Birthday = birthday;
				student.Address = address;
				student.MajorId = majorId;
				students.Add(student);
			}
			reader.Close();
			connection.Close();
		}

		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
