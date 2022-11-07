using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using System.Data.Services.Client;

namespace WebRole1
{
    public partial class StudentTable : System.Web.UI.Page
    {
        private CloudStorageAccount account = null;
        private StudentContext context = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            context = new StudentContext(account.TableEndpoint, account.Credentials);
            StudentGV.DataSource = context.StudentData;
            StudentGV.DataBind();

            int i = 0;

            foreach (TableCell cell in StudentGV.HeaderRow.Cells)
            {
                if (cell.Text == "PartitionKey") { Session["pkindex"] = i; }
                if (cell.Text == "RowKey") { Session["rkindex"] = i; }
                i++;
            }

            btnChange.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var statusMessage = String.Empty;
            try
            {
                var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                var context = new StudentContext(account.TableEndpoint, account.Credentials);
                context.Add(new Student
                {
                    PartitionKey = "Students",
                    RowKey = this.Num.Text,
                    Number = Convert.ToInt32(Num.Text),
                    SurName = Fam.Text,
                    FirstName = Im.Text,
                    LastName = Ot.Text,
                    Faculty = Fak.Text,
                    FormEducation = Forma.Text
                });
            }
            catch (DataServiceRequestException ex)
            {
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>" + ex.Message;
            }
            Lb_Status.Text = statusMessage;

            StudentGV.DataBind();
        }

        protected void StudentGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView g = (GridView)sender;
            try
            {
                Student c = (from student in context.CreateQuery<Student>("Students")
                             where student.PartitionKey == g.Rows[e.RowIndex].
                                Cells[Convert.ToInt32(Session["pkindex"].ToString())].Text
                             && student.RowKey == g.Rows[e.RowIndex].Cells[Convert.ToInt32
                               (Session["rkindex"].ToString())].Text
                             select student).FirstOrDefault();

                context.Delete(c);
            }
            catch (DataServiceRequestException ex)
            {
                Lb_Status.Text = ex.Message;
            }
            g.DataBind();
        }

        protected void StudentGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView g = (GridView)sender;
            int index = g.SelectedIndex;

            Student c = (from student in context.CreateQuery<Student>("Students")
                         where student.PartitionKey == g.Rows[index].
                             Cells[Convert.ToInt32(Session["pkindex"].ToString())].Text
                         && student.RowKey == g.Rows[index].
                             Cells[Convert.ToInt32(Session["rkindex"].ToString())].Text
                         select student).FirstOrDefault();
            Num.Text = Convert.ToString(c.Number);
            Fam.Text = c.SurName;
            Im.Text = c.FirstName;
            Ot.Text = c.LastName;
            Fak.Text = c.Faculty;
            Forma.Text = c.FormEducation;

            Session["index"] = index;

            btnChange.Visible = true;
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Session["index"].ToString());
            try
            {
                Student c = (from contact in context.CreateQuery<Student>("Students")
                             where contact.PartitionKey == StudentGV.Rows[index].
                                  Cells[Convert.ToInt32(Session["pkindex"].ToString())].Text
                             && contact.RowKey == StudentGV.Rows[index].
                                  Cells[Convert.ToInt32(Session["rkindex"].ToString())].Text
                             select contact).FirstOrDefault();

                c.Number = Convert.ToInt32(Num.Text);
                c.SurName = Fam.Text;
                c.FirstName = Im.Text;
                c.LastName = Ot.Text;
                c.Faculty = Fak.Text;
                c.FormEducation = Forma.Text;

                context.Update(c);
            }
            catch (DataServiceRequestException a)
            {
                Lb_Status.Text = a.Message;
            }
            StudentGV.DataBind();
        }


    }
}