using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Alachisoft.NCache.Client;
using Alachisoft.NCache.Runtime.Exceptions;
using System.Configuration;

namespace DAL
{
    public class ProductDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindDB"].ConnectionString);
        public List<Products> AddProducts()
        {
            List<Products> ProductList = new List<Products>();
            con.Open();
            var cmd = new SqlCommand("select ProductID,ProductName from Products", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Products Temp = new Products();
                    Temp.ProductID = rd.GetInt32(rd.GetOrdinal("ProductID"));
                    Temp.ProductName = rd.GetString(rd.GetOrdinal("ProductName"));
                    ProductList.Add(Temp);
                }
                con.Close();
                rd.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            //AddtoCache();

            return ProductList;
        }

        public List<Employees> AddEmployees()
        {
            con.Open();
            List<Employees> EmployeeList = new List<Employees>();
            var cmd1 = new SqlCommand("select EmployeeId from Employees", con);
            try
            {
                SqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    Employees Temp = new Employees();
                    Temp.EmployeeID = rd1.GetInt32(rd1.GetOrdinal("EmployeeId"));
                    EmployeeList.Add(Temp);
                }
                con.Close();
                rd1.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return EmployeeList;
        }
    }
}
