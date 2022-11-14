using System.Data.SqlClient;


namespace DAL
{

    public class AdODataAccess
    {
        EmpClass emp = new EmpClass();
        /*public EmpClass Displayrecord { get; set; }*/
        public EmpClass DisplayRecord { get; private set; }

        public const string connection = "Data Source=ndi-lap-122;Initial Catalog=Emp;Integrated Security=True";
        public void addEmployee(EmpClass emp)
        {
       
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                string Insertdata = "Insert into NewEmployee Values('" +emp.Empname + "','" + emp.Email + "','" + emp.Age + "','" + emp.Salary + "')";
                using (SqlCommand sqlcomm = new SqlCommand(Insertdata, sqlcon))
                {
                    sqlcon.Open();
                    sqlcomm.ExecuteNonQuery();
                }

            }
        }

        public void editEmployee(int id)
        {
            
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                string UpdateQuery = "Update NewEmployee set Email = '" + emp.Email.ToString() + "' , Empname = '" + emp.Empname.ToString() + "' , age = '" + emp.Age + "' , salary = '" + emp.Salary + "' where Empid =" + id;
                using (SqlCommand sqlcomm = new SqlCommand(UpdateQuery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                }
            }
        }

        /*public void editEmployee(int id)
        {
            throw new NotImplementedException();
        }*/

        public void deleteEmployee(int id)
        {
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                string UpdateQuery = " Delete from NewEmployee where Empid =" + id;
                using (SqlCommand sqlcomm = new SqlCommand(UpdateQuery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                }
            }
        }

        public void showEmployee(int id)
        {
            EmpClass ec = new EmpClass();
            string sqlquery = "select * from NewEmployee where Empid = '" + id + "'";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlcomm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ec.Empid = Convert.ToInt32(sdr["Empid"]);
                            ec.Empname = Convert.ToString(sdr["Empname"]);
                            ec.Email = Convert.ToString(sdr["Email"]);
                            ec.Age = Convert.ToInt32(sdr["Age"]);
                            ec.Salary = Convert.ToInt32(sdr["Salary"]);
                        }
                    }
                    DisplayRecord = ec;
                }
            }
        }
    }
}
    
