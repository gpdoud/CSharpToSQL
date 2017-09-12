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
			var sql = "select firstname, lastname, birthday, id from Student";
			SqlCommand cmd = new SqlCommand(sql, connection);
			SqlDataReader reader = cmd.ExecuteReader();
			while(reader.Read()) {
				var id = reader.GetInt32(reader.GetOrdinal("Id"));
				var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
				var lastName = reader.GetString(reader.GetOrdinal("LastName"));
				var birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
				Console.WriteLine($"{id}, {firstName} {lastName}, born of {birthday}");
			}
			reader.Close();
			connection.Close();
		}

		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
