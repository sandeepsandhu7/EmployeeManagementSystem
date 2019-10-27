using BussinessLayer.Bussiness;
using BussinessLayer.Interfaces;
using BussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem
{
    public partial class EmpJob : System.Web.UI.Page
    {
        JobInter jobInterface = new JobBussiness();//Bussiness class instance
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update method
        {
            JobModel myModel = new JobModel();
            myModel.Job = JobName.Text;
            myModel.MinSalary = Convert.ToDecimal(MinSalary.Text);
            myModel.MaxSalary = Convert.ToDecimal(MaxSalary.Text);

            if (HiddenField1.Value != "")
                myModel.ID = Convert.ToInt32(HiddenField1.Value);
            myModel = jobInterface.AddUpdateJobs(myModel);
            if (myModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("EmpJob.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //This is row command method for grid view functionality
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DTConversion lsttodt = new DTConversion();
                var lst = jobInterface.GetJobByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    JobName.Text = dt.Rows[0]["Job"].ToString();
                    MinSalary.Text = dt.Rows[0]["MinSalary"].ToString();
                    MaxSalary.Text = dt.Rows[0]["MaxSalary"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }

            }
            else
            {
                DataTable dt = new DataTable();
                bool result = jobInterface.DeleteJobs(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//Bind grid method
        {
            DTConversion lsttodt = new DTConversion();
            var lst = jobInterface.GetJobs();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }

        protected void Reset_Click(object sender, EventArgs e)//Reset method
        {
            Response.Redirect("EmpJob.aspx");
        }
    }
}