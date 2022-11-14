using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Sql;
using System.Data.SqlClient;

using CRUD.Models;
using DAL;

namespace CRUD.Pages
{
	public class IndexModel : PageModel
	{
		//private readonly ILogger<IndexModel> _logger;

		//public IndexModel(ILogger<IndexModel> logger)
		//{
		//	_logger = logger;
		//}

		public IEnumerable<EmpClass> Getrecords { get; set; }

		public void OnGet()
		{
			Getrecords = DisplayRecords();
		}

		public static List<EmpClass> DisplayRecords()
		{
			List<EmpClass> ListObj = new List<EmpClass>();

			string connection = "Data Source=ndi-lap-122;Initial Catalog=Emp;Integrated Security=True";
			using (SqlConnection sqlcon = new SqlConnection(connection))
			{
				using (SqlCommand sqlcomm = new SqlCommand("select * from NewEmployee", sqlcon))
				{
					sqlcon.Open();
					using (SqlDataReader sdr = sqlcomm.ExecuteReader())
					{
						while (sdr.Read())
						{
							EmpClass ec = new EmpClass();
							ec.Empid = Convert.ToInt32(sdr["Empid"]);
							ec.Empname = Convert.ToString(sdr["Empname"]);
							ec.Email = Convert.ToString(sdr["Email"]);
							ec.Age = Convert.ToInt32(sdr["Age"]);
							ec.Salary = Convert.ToInt32(sdr["Salary"]);

							ListObj.Add(ec);
						}
					}

					return ListObj;
				}
			}

		}

		public IActionResult OnPostAsync(EmpClass ecinsert)
		{
			AdODataAccess ado = new AdODataAccess();
			ado.addEmployee(ecinsert);

			return RedirectToPage("Index");
		}
	}
}