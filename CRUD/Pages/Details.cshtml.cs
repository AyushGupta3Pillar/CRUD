using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Sql;
using System.Data.SqlClient;

using CRUD.Models;
using DAL;

namespace CRUD.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public EmpClass DisplayRecord { get; set; }
        public void OnGet(int id)
        {
            /*EmpClass ec = new EmpClass();
            string connection = "Data Source=ndi-lap-122;Initial Catalog=Emp;Integrated Security=True";
            string sqlquery = "select * from NewEmployee where Empid = '"+id+"'";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                using(SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    using(SqlDataReader sdr = sqlcomm.ExecuteReader())
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
            }*/

            AdODataAccess adODataAccess = new AdODataAccess();
            adODataAccess.showEmployee(id);
            
        }
    }
}
