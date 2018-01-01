using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class User_pageChangePWD : System.Web.UI.Page
{
    int iUserRole;//用户角色
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdr;//定义记录集
    
    //窗体加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断Session是否有值
        if (Session["UserName"] == null)
        {
            //跳转回登录页面
            Response.Redirect("~/Login/pageLogin.aspx");
        }
        else
        {
            //加载原密码
            sql = string.Format("SELECT vcUserPWD FROM tb_UserInfo WHERE vcUserName = '{0}'", Session["UserName"].ToString());
            sdr = cDL.QueryOperation(sql);

            sdr.Read();

            txtPWDY.Text = sdr.GetString(0);


            //光标定位在新密码框
            txtPWDX1.Focus();
        }
    }

    //修改密码
    protected void btnConfirg_Click(object sender, EventArgs e)
    {
        if (txtPWDX1.Text.ToString() == txtPWDX2.Text.ToString())
        {
            
            //修改密码
            sql = string.Format("update tb_UserInfo SET vcUserPWD = '{0}' WHERE vcUserName = '{1}'",txtPWDX1.Text.ToString(),Session["UserName"].ToString());
            cDL.ExeNonQuery(sql);

            //跳转回登录页面
            Response.Redirect("~/Login/pageLogin.aspx");
        }
        else
        {
            //清空密码框
            txtPWDX1.Text = "";
            txtPWDX2.Text = "";
            
            //光标定位在新密码框
            txtPWDX1.Focus();
        }
    }
}