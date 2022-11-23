using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Models;

namespace WebServiceApplicationCRUD
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        CustomerDal Cust_Obj = new CustomerDal();
        OrderDal Order_Obj = new OrderDal();
        ProductDal Product_Obj = new ProductDal();

        [WebMethod]
        public Customer FirstCustomer()
        {
            var Cust = new Customer();
            Cust = Cust_Obj.FirstCustomer();
            return Cust;
        }
        [WebMethod]
        public Customer LastCustomer()
        {
            var Cust = new Customer();
            Cust = Cust_Obj.LastCustomer();
            return Cust;
        }
        [WebMethod]
        public Customer NextCustomer(string ID)
        {
            var Cust = new Customer();
            Cust = Cust_Obj.NextCustomer(ID);
            return Cust;
        }
        [WebMethod]
        public Customer PrevCustomer(string ID)
        {
            var Cust = new Customer();
            Cust = Cust_Obj.PrevCustomer(ID);
            return Cust;
        }

        [WebMethod]
        public bool Add(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Cust_Obj.AddCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool Edit(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Cust_Obj.EditCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool Delete(string ID)
        {
            if (Cust_Obj.DeleteCust(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*[WebMethod]
        public List<Customer> CustomerData()
        {
            List<Customer> CustomerList = new List<Customer>();
            CustomerList = Cust_Obj.GetCustomer();
            return CustomerList;
        }*/

        [WebMethod]
        public List<OrderDetails> OrdersData(Customer Cust)
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders = Order_Obj.DisplayOrder(Cust.CustomerId);
            return orders;
        }

        [WebMethod]

        public bool PlaceOrder(string CustomerID, int EmployeeID, string ProductName, int Quantity)
        {
            if (Order_Obj.PlaceOrder(CustomerID, EmployeeID, ProductName, Quantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public List<Products> AddProducts()
        {
            List<Products> ProductList = new List<Products>();
            ProductList = Product_Obj.AddProducts();
            return ProductList;
        }

        [WebMethod]
        public List<Employees> AddEmployees()
        {
            List<Employees> EmployeeList = new List<Employees>();
            EmployeeList = Product_Obj.AddEmployees();
            return EmployeeList;
        }
    }
}
