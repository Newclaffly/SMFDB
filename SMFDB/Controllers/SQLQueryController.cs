using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SMFDB.Controllers
{
    public class SQLQueryController : Controller
    {
        private readonly IConfiguration config; // conection DB
        //common
        public SQLQueryController(IConfiguration config)
        {
            this.config = config;
        }
        public JsonResult ConvertJson(DataTable dt)
        {
            //Convert Dataset to Json
            List<Dictionary<string, object>> _json = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                _json.Add(row);
            }
            return Json(_json);
        }

        //*** Get: Query ปกติ ***//
        public JsonResult _query(string query)
        {
            DataTable dt = new DataTable();
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            using (SqlConnection cnn = new SqlConnection(dbcon))
            {
                cnn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, cnn);
                sqlDa.Fill(dt);
                cnn.Close();
            }
            var _json = ConvertJson(dt);
            return _json;
        }
        public int _query_row_count(string query)
        {
            DataTable dt = new DataTable();
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            using (SqlConnection cnn = new SqlConnection(dbcon))
            {
                cnn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, cnn);
                sqlDa.Fill(dt);
                cnn.Close();
            }
            int _data = dt.Rows.Count;
            return _data;
        }

        //** Get:Query Scarlar Int **//
        public int _query_scalar(string query)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            var result = (Int32)cmd.ExecuteScalar();
            cnn.Close();
            return result;
        }
        public Double _query_scalar_double(string query)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            var result = (Double)cmd.ExecuteScalar();
            cnn.Close();
            return result;
        }

        //** Post: Query **//
        public String _query_post(string query)
        {
            var result = "";
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cnn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            cnn.Close();

            return result;
        }

        //*** Get: Store ปกติ ***//
        public JsonResult _sp(string query)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataset);

            cnn.Close();
            dt = dataset.Tables[0];
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            cnn.Close();
            return Json(rows);
        }

        //*** Get: Store แบบมี param 1 ***//
        public JsonResult _sp_param1(string query, string param1)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataset);
            cnn.Close();
            dt = dataset.Tables[0];
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            cnn.Close();
            return Json(rows);
        }
        //*** Get: Store แบบมี param 2 ***//
        public JsonResult _sp_param2(string query, string param1, string param2)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataset);
            cnn.Close();
            dt = dataset.Tables[0];
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            cnn.Close();
            return Json(rows);
        }
        //*** Get: Store แบบมี param 3 ***//
        public JsonResult _sp_param3(string query, string param1, string param2, string param3)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.Parameters.AddWithValue("@param2", param2);
            cmd.Parameters.AddWithValue("@param3", param3);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataset);
            cnn.Close();
            dt = dataset.Tables[0];
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            cnn.Close();
            return Json(rows);
        }

        //*** Get: Store แบบมี out put ***//
        public JsonResult _sp_param_out(string query, string param1)
        {
            string dbcon = config.GetConnectionString("PORTFOLIOContext");
            SqlConnection cnn = new SqlConnection(dbcon);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(query, cnn); //Query String
            cmd.Parameters.AddWithValue("@param1", param1);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataset);
            cnn.Close();
            dt = dataset.Tables[0];
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                rows.Add(row);
            }
            cnn.Close();
            return Json(rows);
        }


        //*** Post: Store แบบมี param 1 ***//

        public String _post_param1(string query, string param1)
        {
            var result = "";
            try
            {
                string dbcon = config.GetConnectionString("PORTFOLIOContext");
                SqlConnection cnn = new SqlConnection(dbcon);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn); //Query String
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cnn.Close();
                result = "OK";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;
        }
        //*** Post: Store แบบมี param 2 ***//
        public String _post_param2(string query, string param1, string param2)
        {
            var result = "";
            try
            {
                string dbcon = config.GetConnectionString("PORTFOLIOContext");
                SqlConnection cnn = new SqlConnection(dbcon);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn); //Query String
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cnn.Close();
                result = "OK";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;
        }
        //*** Post: Store แบบมี param 3 ***//
        public String _post_param3(string query, string param1, string param2, string param3)
        {
            var result = "";
            try
            {
                string dbcon = config.GetConnectionString("PORTFOLIOContext");
                SqlConnection cnn = new SqlConnection(dbcon);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn); //Query String
                cmd.Parameters.AddWithValue("@param1", param1);
                cmd.Parameters.AddWithValue("@param2", param2);
                cmd.Parameters.AddWithValue("@param3", param3);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cnn.Close();
                result = "OK";
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;
        }

    }
}
