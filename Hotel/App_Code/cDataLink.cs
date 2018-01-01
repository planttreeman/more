using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
///cDataLink 的摘要说明
/// </summary>
public class cDataLink
{
	public cDataLink()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //数据库连接字符串
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SmartConnectionString"].ToString());

    //定义记录集
    SqlDataReader sdr;

    //数据库连接
    public SqlConnection getConn()
    {
        return con;
    }

    //数据库返回
    public SqlConnection returnConn()
    {
        return con;
    }

    //打开数据库连接
    public void openConn()
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
    }

    //关闭数据库连接
    public void closeConn()
    {
        if (con.State != System.Data.ConnectionState.Closed)
            con.Close();
    }

    //查询函数
    public SqlDataReader QueryOperation(string StrQueryCommand)
    {
        openConn();
        
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = StrQueryCommand;

        if (sdr != null)
            sdr.Close();

        sdr = cmd.ExecuteReader();

        return sdr;
    }

    //执行函数
    public bool ExeNonQuery(string StrCmd)
    {
        //sdr.Close();
        
        openConn();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = StrCmd;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    //执行函数
    public bool ExeNonQueryProc(string cmdName, SqlParameter[] ps)
    {
        openConn();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = cmdName;

        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        foreach (SqlParameter p in ps)
        {
            cmd.Parameters.Add(p);
        }

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    //执行函数
    public DataTable QueryOperationProc(string cmdName, SqlParameter[] ps)
    {
        openConn();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = cmdName;

        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        if (ps != null)
        {
            foreach (SqlParameter p in ps)
            {
                cmd.Parameters.Add(p);
            }
        }

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        closeConn();

        return dt;
    }

    //执行函数
    public DataTable QueryProc(string cmdStr, SqlParameter[] ps)
    {

        openConn();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = cmdStr;

        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        if (ps != null)
        {
            foreach (SqlParameter p in ps)
            {
                cmd.Parameters.Add(p);
            }
        }

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        closeConn();

        return dt;
    }

}