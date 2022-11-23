using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthWindApplication
{
    public partial class OrderPlacement : Page
    {
        ServiceReference1.Employees[] EmployeeArray;
        ServiceReference1.Products[] ProductArray;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["CX_ID"] != "")
                {
                    string cx_id = Request.QueryString["CX_ID"];
                    TextBox2.Text = cx_id;
                    ProductList();
                    EmployeeList();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProductName = Convert.ToString(DropDownList1.SelectedItem.Text);
            int EmployeeID = Convert.ToInt32(DropDownList2.SelectedItem.Text);
            int Quantity = Convert.ToInt32(TextBox1.Text);
            string CustomerID = TextBox2.Text;
            if (client.PlaceOrder(CustomerID, EmployeeID, ProductName, Quantity))
            {
                Response.Write("<script>alert('Order Placed !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void ProductList()
        {
            
            ProductArray = client.AddProducts();
            DropDownList1.DataSource = ProductArray;
            DropDownList1.DataTextField = "ProductName";
            DropDownList1.DataValueField = "ProductID";
            DropDownList1.DataBind();
        }

        protected void EmployeeList()
        {

            EmployeeArray = client.AddEmployees();
            DropDownList2.DataSource = EmployeeArray;
            DropDownList2.DataTextField = "EmployeeID";
            DropDownList2.DataValueField = "EmployeeID";
            DropDownList2.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}