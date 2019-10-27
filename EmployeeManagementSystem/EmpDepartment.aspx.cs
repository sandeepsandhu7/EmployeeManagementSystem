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
    public partial class EmpDepartment : System.Web.UI.Page
    {
        DepttInter departmentInterface = new DepttBussiness();//This is bussiness class instance
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)//Add update method
        {
            DepttModel myModel = new DepttModel();
            myModel.Name = Name.Text;

            if (HiddenField1.Value != "")
                myModel.ID = Convert.ToInt32(HiddenField1.Value);
            myModel = departmentInterface.AddUpdateDeptt(myModel);
            if (myModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("EmpDepartment.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //This is rowcommand method using for grid view
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DTConversion lsttodt = new DTConversion();
                var lst = departmentInterface.GetDepttByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
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
                bool result = departmentInterface.DeleteDeptt(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()//Bind grid method
        {
            DTConversion lsttodt = new DTConversion();//Dataconversion instance
            var lst = departmentInterface.GetDeptts();
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
            Response.Redirect("EmpDepartment.aspx");
        }
    }
}