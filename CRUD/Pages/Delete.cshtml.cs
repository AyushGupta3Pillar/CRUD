using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Sql;
using System.Data.SqlClient;
using CRUD.Models;
using DAL;
using CRUD_WITH_EF;

namespace CRUD.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public EmpClass DisplayRecord { get; set; }
        public void OnGet(int id)
        {
            EmpClass ec = new EmpClass();
            string connection = "Data Source=ndi-lap-122;Initial Catalog=Emp;Integrated Security=True";
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

        public IActionResult OnPostAsync(int id)
        {
            /*string connection = "Data Source=ndi-lap-122;Initial Catalog=Emp;Integrated Security=True";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                string UpdateQuery = " Delete from NewEmployee where Empid =" + id;
                using (SqlCommand sqlcomm = new SqlCommand(UpdateQuery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                }
            }*/

            AdODataAccess adODataAccess = new AdODataAccess();
            adODataAccess.deleteEmployee(id);

            /*DeleteModel deleteModel = new DeleteModel();
            deleteModel.OnGet(id);
            deleteModel.OnPostAsync(id);*/

            return RedirectToPage("Index");

        }
    }
}
