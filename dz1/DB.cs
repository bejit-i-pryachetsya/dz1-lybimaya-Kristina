using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1
{
    internal class DB
    {
        NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=Dz1;Username=postgres;Password=12345");
        
         public DataTable WiewContacts()
        {

  
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string sql = ($"SELECT * FROM contacts;");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(dt);
            
            return dt;

           



        }

         public void SetContact(string login, string password)
        {
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = ($"Insert into contacts Values ('{login}','{password}');");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(dt);
            conn.Close();
        }

        public void DeleteContactN(string x)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = ($"delete from contacts where name = '{x}';");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(dt);
            conn.Close();
        }
        public void DeleteContactP(string x)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = ($"delete from contacts where phone_number = '{x}';");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(dt);
            conn.Close();
        }

        public void DeleteContact(string x)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = ($"delete from contacts where name = '{x}' or phone_number = '{x}';");
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(dt);
            conn.Close();
        }
    }
}
