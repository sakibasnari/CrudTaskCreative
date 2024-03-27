using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CrudTaskCreative
{
    public partial class crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("getProductBySearch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", userName.Text.Trim());
                    cmd.Parameters.AddWithValue("@CategoryName", category.Text.Trim());
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    products.DataSource = dt;
                    products.DataBind();
                }
            }
        }

        protected void products_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            products.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void products_RowEditing(object sender, GridViewEditEventArgs e)
        {
            products.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void products_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = products.Rows[e.RowIndex];
            int productId = Convert.ToInt32(products.DataKeys[e.RowIndex].Value);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            string productDescription = (row.FindControl("txtProductDescription") as TextBox).Text;
            UpdateProduct(productId, productName, productDescription);
            products.EditIndex = -1;
            BindGridView();
        }

        protected void UpdateProduct(int ProductId, string ProductName, string ProductDescription)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EditProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("@ProductName", ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        protected void products_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
                products.EditIndex = -1;             
                BindGridView();
           
        }
        protected void products_rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(products.DataKeys[e.RowIndex].Value);
            DeleteProduct(productId);
            BindGridView();
        }

        protected void DeleteProduct(int ProductId)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
