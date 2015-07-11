using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//reference database model to use to connect to the sql server.
using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if Loading for the first time, check for a url
            if (!IsPostBack)
            {
                //if the url has an ID, look up the selected recored.
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudents();
                }
            }
        }

        protected void GetStudents()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                //Store the id from the URL in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                //look up the Student.
                Student stu = (from s in db.Students
                               where s.StudentID == StudentID
                               select s).FirstOrDefault();

                //pre-populate the form fields
                txtLastName.Text = stu.LastName;
                txtFirstMidName.Text = stu.FirstMidName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connecting to the database.
            using (DefaultConnection db = new DefaultConnection())
            {
                //create a new student in the memory.
                Student stu = new Student();

                Int32 StudentID = 0;

                //Check for a URL
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    //Get the ID from the URL.
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //look up the Student
                    stu = (from s in db.Students
                           where s.StudentID == StudentID
                           select s).FirstOrDefault();
                }

                //fill the properties of the new student.
                stu.LastName = txtLastName.Text;
                stu.FirstMidName = txtFirstMidName.Text;

                //Add if there is no ID in the URL.
                if (StudentID == 0)
                {
                    db.Students.Add(stu);
                }

                //Save the new student.
                db.SaveChanges();

                //Redirect the user to the Students list page.
                Response.Redirect("students.aspx");
            
            }
        }
    }
}