using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient; 
using Alachisoft.NCache.Client;
using Alachisoft.NCache.Runtime.Exceptions;
using Models;
using DAL;

namespace NorthWindApplication
{
    public partial class HomePage : Page
    { 
        ServiceReference1.OrderDetails[] OrderArray;
        ServiceReference1.Customer Cust = new ServiceReference1.Customer();
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Cust = client.FirstCustomer();
            if (!this.IsPostBack)
            {
                HiddenField.Value = "0";
                _ShowData(Cust);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TEXT_ID.Text = string.Empty;
            TEXT_ID.DataBind();
            TEXT_NAME.Text = string.Empty;
            TEXT_NAME.DataBind();
            TEXT_NAME_2.Text = string.Empty;
            TEXT_NAME_2.DataBind();
            TEXT_TITLE.Text = string.Empty;
            TEXT_TITLE.DataBind();
            TEXT_ADDRESS.Text = string.Empty;
            TEXT_ADDRESS.DataBind();
            TextBox1.Text = string.Empty;
            TextBox1.DataBind();
            Button10.Visible = true;
            GridView1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            if (client.Edit(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Updated !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            if (client.Delete(TEXT_ID.Text))
            {
                Response.Write("<script>alert('Data Deleted !!')</script>");
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var CX_ID = TEXT_ID.Text.Trim();
            Response.Redirect("OrderPlacement.aspx?CX_ID=" + CX_ID);
        }


        protected void _ShowData(ServiceReference1.Customer Cust)
        {
            TEXT_ID.Text = Cust.CustomerId;
            TEXT_NAME.Text = Cust.CompanyName;
            TEXT_NAME_2.Text = Cust.CustomerName;
            TEXT_TITLE.Text = Cust.CustomerTitle;
            TEXT_ADDRESS.Text = Cust.Address;
            _ShowOrders();
        }

        protected void _ShowOrders()
        {
            OrderArray = client.OrdersData(Cust);
            if (OrderArray.Length != 0)
            {
                TextBox1.Text = "Displaying Orders";
                GridView1.Visible = true;
                GridView1.DataSource = OrderArray;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
                TextBox1.Text = "No Orders Found";
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            _ShowOrders();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            GridView1.PageIndex=0;
            Cust = client.FirstCustomer();
            _ShowData(Cust);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            GridView1.PageIndex = 0;
            Cust = client.LastCustomer();
            _ShowData(Cust);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            /*Button10.Visible = false;
            int Iterator = Convert.ToInt32(HiddenField.Value.TrimStart());
            Iterator++;
            if (Iterator < CustomerList.Count)
            {
                _ShowData(Iterator);
            }
            else
            {
                Iterator = 0;
                _ShowData(Iterator);
            }
            HiddenField.Value = Convert.ToString(Iterator);*/
            Button10.Visible = false;
            string ID = TEXT_ID.Text.ToString();
            GridView1.PageIndex = 0;
            Cust = client.NextCustomer(ID);
            _ShowData(Cust);

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            /*Button10.Visible = false;
            int iterator = Convert.ToInt32(HiddenField.Value.TrimStart());
            iterator--;
            if (iterator > -1)
            {
                _ShowData(iterator);
            }
            else
            {
                iterator = CustomerList.Count - 1;
                _ShowData(iterator);
            }
            HiddenField.Value = Convert.ToString(iterator);*/
            Button10.Visible = false;
            string ID = TEXT_ID.Text.ToString();
            GridView1.PageIndex=0;
            Cust = client.PrevCustomer(ID);
            _ShowData(Cust);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (client.Add(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Inserted !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }
    }
}