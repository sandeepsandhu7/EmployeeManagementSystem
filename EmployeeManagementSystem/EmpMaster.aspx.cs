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
    public partial class EmpMaster : System.Web.UI.Page
    {
        EmployeeInter employeeInterface = new EmployeeBussiness();//Bussiness class instance
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindDepartmentList();
                bindJobList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update method
        {
            EmployeeModel myModel = new EmployeeModel();
            myModel.tblJobID = Convert.ToInt32(JobID.Text);
            myModel.tblDepartment = Convert.ToInt32(DepartmentID.Text);
            myModel.Name = Name.Text;
            myModel.PhoneNumber = PhoneNumber.Text;
            myModel.Salary = Convert.ToDecimal(Salary.Text);
            myModel.Email = Email.Text;
            myModel.HireDate = Convert.ToDateTime(HireDate.Text);
            if (HiddenField1.Value != "")
                myModel.ID = Convert.ToInt32(HiddenField1.Value);
            myModel = employeeInterface.AddUpdateEmp(myModel);
            if (myModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("EmpMaster.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //this method for the functionality of gridview
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //myModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DTConversion lsttodt = new DTConversion();
                var lst = employeeInterface.GetEmpByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    JobID.Text = dt.Rows[0]["tblJobID"].ToString();
                    DepartmentID.Text = dt.Rows[0]["tblDepartment"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    PhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    HireDate.Text = dt.Rows[0]["HireDate"].ToString();
                    Salary.Text = dt.Rows[0]["Salary"].ToString();
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
                bool result = employeeInterface.DeleteEmp(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//This is for binding the grid view
        {
            DTConversion lsttodt = new DTConversion();//Data conersion for converting the list into datatable
            var lst = employeeInterface.GetEmp();
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
        protected void bindJobList()//This method for binding the job dropdown list
        {
            DTConversion lsttodt = new DTConversion();
            JobInter service = new JobBussiness();
            var lst = service.GetJobs().Select(x => new { x.Job, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                JobID.DataSource = dt;
                JobID.DataTextField = "Job";
                JobID.DataValueField = "ID";
                JobID.DataBind();

            }
            else
            {
                JobID.DataBind();
            }
        }
        protected void bindDepartmentList()//This method for binding the department dropdown list
        {
            DTConversion lsttodt = new DTConversion();
            DepttInter service = new DepttBussiness();
            var lst = service.GetDeptts().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                DepartmentID.DataSource = dt;
                DepartmentID.DataTextField = "Name";
                DepartmentID.DataValueField = "ID";
                DepartmentID.DataBind();

            }
            else
            {
                DepartmentID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)//Reset method
        {
            Response.Redirect("EmpMaster.aspx");
        }
    }
}