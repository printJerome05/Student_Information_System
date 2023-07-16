using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student_Information_System
{
    class Class1
    {
        // connection to the mysql xamp database
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=infosys_student_db");

        // fucntion to get the connection
        public MySqlConnection GetConnection
        {
            get
            {
                return conn;
            }
        }

        // fucntion to open the connection
        public void openConnection()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }


        // fucntion to close the connection
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

    }
}
