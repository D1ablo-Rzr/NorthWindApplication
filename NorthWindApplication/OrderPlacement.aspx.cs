using System;
using System.Web.UI;

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
                    ProductList(0);
                    EmployeeList(0);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(Session["ProductID"]);
            decimal UnitPrice = Convert.ToDecimal(Session["UnitPrice"]);
            int EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
            int Quantity = Convert.ToInt32(TextBox1.Text);
            string CustomerID = TextBox2.Text;
            if (client.PlaceOrder(CustomerID, EmployeeID, ProductID, Quantity,UnitPrice))
            {
                Response.Write("<script>alert('Order Placed !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void ProductList(int ProdID)
        {
            
            ProductArray = client.AddProducts(ProdID);
            if (ProductArray.Length != 0)
            {
                GridView1.DataSource = ProductArray;
                GridView1.DataBind();
                int size = ProductArray.Length - 1;
                Session["GlobProd"] = ProductArray[size].ProductID;
            }
            else
            {
                Session["GlobProd"] = 0;
                ProductList(0);
            }
        }

        protected void EmployeeList(int EmpID)
        {

            EmployeeArray = client.AddEmployees(EmpID);
            GridView2.DataSource = EmployeeArray;
            GridView2.DataBind();
            EmployeeArray = client.AddEmployees(EmpID);
            if (EmployeeArray.Length != 0)
            {
                GridView2.DataSource = EmployeeArray;
                GridView2.DataBind();
                int size = EmployeeArray.Length - 1;
                Session["GlobEmp"] = EmployeeArray[size].EmployeeID;
            }
            else
            {
                Session["GlobEmp"] = 0;
                EmployeeList(0);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int GlobProd = Convert.ToInt32(Session["GlobProd"]);
            ProductList(GlobProd);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ProductID"] = GridView1.SelectedRow.Cells[1].Text;
            Session["UnitPrice"] = GridView1.SelectedRow.Cells[3].Text;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int GlobEmp = Convert.ToInt32(Session["GlobEmp"]);
            EmployeeList(GlobEmp);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["EmployeeID"] = GridView2.SelectedRow.Cells[1].Text;
        }
    }
}