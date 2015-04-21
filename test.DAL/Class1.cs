using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.DAL
{
    public class Class1
    {

        //#region 方法


        //#region 执行返回一行一列的数据库操作


        ///// <summary>


        ///// 执行返回一行一列的数据库操作


        ///// </summary>


        ///// <param name="commandText">Oracle语句或存储过程名</param>


        ///// <param name="commandType">Oracle命令类型</param>


        ///// <param name="param">Oracle命令参数数组</param>


        ///// <returns>第一行第一列的记录</returns>


        //public static int ExecuteScalar(string commandText, CommandType commandType, params OracleParameter[] param)
        //{


        //    int count = 0;


        //    using (OracleHelper.Con)
        //    {


        //        using (OracleCommand cmd = new OracleCommand(commandText, OracleHelper.Con))
        //        {


        //            try
        //            {


        //                cmd.CommandType = commandType;


        //                cmd.Parameters.AddRange(param);


        //                OracleHelper.Con.Open();


        //                count = Convert.ToInt32(cmd.ExecuteScalar());


        //            }


        //            catch (Exception ex)
        //            {


        //                count = 0;


        //            }


        //        }




        //    }


        //    return count;


        //}


        //#endregion




        //#region 执行不查询的数据库操作


        ///// <summary>


        ///// 执行不查询的数据库操作


        ///// </summary>


        ///// <param name="commandText">Oracle语句或存储过程名</param>


        ///// <param name="commandType">Oracle命令类型</param>


        ///// <param name="param">Oracle命令参数数组</param>


        ///// <returns>受影响的行数</returns>


        //public static int ExecuteNonQuery(string commandText, CommandType commandType, params OracleParameter[] param)
        //{


        //    int result = 0;


        //    using (OracleHelper.Con)
        //    {


        //        using (OracleCommand cmd = new OracleCommand(commandText, OracleHelper.Con))
        //        {


        //            try
        //            {


        //                cmd.CommandType = commandType;


        //                cmd.Parameters.AddRange(param);


        //                OracleHelper.Con.Open();


        //                result = cmd.ExecuteNonQuery();


        //            }


        //            catch (Exception ex)
        //            {


        //                result = 0;


        //            }


        //        }




        //    }


        //    return result;


        //}


        //#endregion




        //#region 执行返回一条记录的泛型对象


        ///// <summary>


        ///// 执行返回一条记录的泛型对象


        ///// </summary>


        ///// <typeparam name="T">泛型类型</typeparam>


        ///// <param name="reader">只进只读对象</param>


        ///// <returns>泛型对象</returns>


        //private static T ExecuteDataReader<T>(IDataReader reader)
        //{


        //    T obj = default(T);


        //    try
        //    {


        //        Type type = typeof(T);


        //        obj = (T)Activator.CreateInstance(type);//从当前程序集里面通过反射的方式创建指定类型的对象 


        //        //obj = (T)Assembly.Load(OracleHelper._assemblyName).CreateInstance(OracleHelper._assemblyName + "." + type.Name);//从另一个程序集里面通过反射的方式创建指定类型的对象 


        //        PropertyInfo[] propertyInfos = type.GetProperties();//获取指定类型里面的所有属性


        //        foreach (PropertyInfo propertyInfo in propertyInfos)
        //        {


        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {


        //                string fieldName = reader.GetName(i);


        //                if (fieldName.ToLower() == propertyInfo.Name.ToLower())
        //                {


        //                    object val = reader[propertyInfo.Name];//读取表中某一条记录里面的某一列信息


        //                    if (val != null && val != DBNull.Value)


        //                        propertyInfo.SetValue(obj, val, null);//给对象的某一个属性赋值


        //                    break;


        //                }


        //            }


        //        }


        //    }


        //    catch (Exception ex)
        //    {


        //    }


        //    return obj;


        //}


        //#endregion




        //#region 执行返回一条记录的泛型对象


        ///// <summary>


        ///// 执行返回一条记录的泛型对象


        ///// </summary>


        ///// <typeparam name="T">泛型类型</typeparam>


        ///// <param name="commandText">Oracle语句或存储过程名</param>


        ///// <param name="commandType">Oracle命令类型</param>


        ///// <param name="param">Oracle命令参数数组</param>


        ///// <returns>实体对象</returns>


        //public static T ExecuteEntity<T>(string commandText, CommandType commandType, params OracleParameter[] param)
        //{


        //    T obj = default(T);


        //    using (OracleHelper.Con)
        //    {


        //        using (OracleCommand cmd = new OracleCommand(commandText, OracleHelper.Con))
        //        {


        //            cmd.CommandType = commandType;


        //            cmd.Parameters.AddRange(param);


        //            OracleHelper.Con.Open();


        //            OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        //            while (reader.Read())
        //            {


        //                obj = OracleHelper.ExecuteDataReader<T>(reader);


        //            }


        //        }


        //    }


        //    return obj;


        //}


        //#endregion




        //#region 执行返回多条记录的泛型集合对象


        ///// <summary>


        ///// 执行返回多条记录的泛型集合对象


        ///// </summary>


        ///// <typeparam name="T">泛型类型</typeparam>


        ///// <param name="commandText">Oracle语句或存储过程名</param>


        ///// <param name="commandType">Oracle命令类型</param>


        ///// <param name="param">Oracle命令参数数组</param>


        ///// <returns>泛型集合对象</returns>


        //public static List<T> ExecuteList<T>(string commandText, CommandType commandType, params OracleParameter[] param)
        //{


        //    List<T> list = new List<T>();


        //    using (OracleHelper.Con)
        //    {


        //        using (OracleCommand cmd = new OracleCommand(commandText, OracleHelper.Con))
        //        {


        //            try
        //            {


        //                cmd.CommandType = commandType;


        //                cmd.Parameters.AddRange(param);


        //                OracleHelper.Con.Open();


        //                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        //                while (reader.Read())
        //                {




        //                    T obj = OracleHelper.ExecuteDataReader<T>(reader);


        //                    list.Add(obj);


        //                }


        //            }


        //            catch (Exception ex)
        //            {


        //                list = null;


        //            }


        //        }


        //    }


        //    return list;


        //}
        //#endregion

        //#endregion

    }
}