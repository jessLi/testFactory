using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace test.DAL
{

    public class SqlServerHelper
    {
        private static SqlConnection _con = null;
        private static SqlCommand cmd;
        private static SqlDataAdapter da;
        private static SqlDataReader dr;
        private static DataSet ds;
        private static SqlTransaction trans;
        private static string connstring = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ToString();

        public static SqlConnection Con
        {
            get
            {
                if (SqlServerHelper._con == null)
                {
                    SqlServerHelper._con = new SqlConnection();
                }
                if (SqlServerHelper._con.ConnectionString == "")
                {
                    SqlServerHelper._con.ConnectionString = SqlServerHelper.connstring;
                }
                return SqlServerHelper._con;
            }
            set
            {
                SqlServerHelper._con = value;
            }
        }


        #region //基本操作
        /// <summary>
        /// 返回数据集，可包含多个表， （要关闭连接）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, params SqlParameter[] param)
        {
            using (SqlServerHelper.Con)
            {
                da = new SqlDataAdapter();
                cmd = new SqlCommand(sql, Con);
                da.SelectCommand = cmd;
                if (param != null)
                    da.SelectCommand.Parameters.AddRange(param);

                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 读取行的只进流 （用户关闭连接）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            using (SqlServerHelper.Con)
            {
                cmd = new SqlCommand(sql, Con);
                try
                {
                    Con.Open();
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return dr;
                }
                catch (SqlException e)
                {
                    dr.Close();
                    throw e;
                }
            }
        }

        /// <summary>
        /// 如果是对数据记录进行操作，返回影响的记录条数；如果创建一个表，创建成功后返回-1；
        ///对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于所有其他类型的语句，返回值为 -1。如果发生回滚，返回值也为 -1。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            int c;
            using (SqlServerHelper.Con)
            {
                try
                {
                    cmd = new SqlCommand(sql, Con);
                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    Con.Open();
                    c = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    Con.Close();
                }
            }
            return c;
        }

        /// <summary>
        /// 返回查询结果的第一行第一列；或检索聚合值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            object c;
            using (SqlServerHelper.Con)
            {
                try
                {
                    cmd = new SqlCommand(sql, Con);
                    Con.Open();
                    c = cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return c;
        }
        #endregion


    }

}
