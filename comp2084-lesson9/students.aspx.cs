using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Adding the reference to use the EF for database.
using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Calling the Get Students Fuction to populate the Grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //Using the Entity Framework to connect and get the list of Students.
            using (DefaultConnection db = new DefaultConnection())
            {
                var students = from stu in db.Students
                               select stu;

                //Binding the Stu query results to the grid.
                grdStudents.DataSource = students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Setting the new page index and repopulating the grid.
            grdStudents.PageIndex = e.NewPageIndex;
            GetStudents();
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //indentifying the StudentID to be deleted from the row the user selected.
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            //Connecting to the Database. 
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stu = (from s in db.Students
                                   where s.StudentID == StudentID
                                   select s).FirstOrDefault();

                //Deleting.
                db.Students.Remove(stu);
                db.SaveChanges();

                //Refreshing Grid.
                GetStudents();
            }
        }
            
    }
}