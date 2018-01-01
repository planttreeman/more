using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class pageLogin : System.Web.UI.Page
{
    int iUserRole;//用户角色
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdr;//定义记录集
    
    //窗体加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //判断Session是否有值
        if (Session["UserName"] != null)
        {
            txtUserName.Text = Session["UserName"].ToString();
            txtPWD.Focus();
        }
        else
        {
            txtUserName.Focus();//光标定位
        }
    }

    //登录事件
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //定义查询语句
        sql = string.Format("SELECT * FROM tb_UserInfo WHERE vcUserName = '{0}'",txtUserName.Text.ToString());
        
        //返回记录集
        sdr = cDL.QueryOperation(sql);

        if (sdr.Read())
        {
            //定义查询语句
            sql = string.Format("SELECT * FROM tb_UserInfo WHERE vcUserName = '{0}' and vcUserPWD='{1}'", txtUserName.Text.ToString(),txtPWD.Text.ToString());

            //返回记录集
            sdr = cDL.QueryOperation(sql);

            if (sdr.Read())
            {
                iUserRole = Convert.ToInt16(sdr["iUserRole"].ToString());//读取用户角色
                if (iUserRole == 1)
                {
                    //获取Session
                    Session["UserName"] = txtUserName.Text.ToString();
                    Response.Redirect("~/Manage/pageManagerMenu.aspx");
                }
                else if (iUserRole == 2)
                {
                    //获取Session
                    Session["UserName"] = txtUserName.Text.ToString();
                    Response.Redirect("~/User/pageUserMenu.aspx");
                }
            }
            else
            {
                Response.Write("密码错误，请重新输入密码");
                txtPWD.Text = "";
                txtPWD.Focus();            
            }
        }
        else
        {
            Response.Write("用户名错误，请到注册页面");
            txtUserName.Text = "";
            txtPWD.Text = "";
            txtUserName.Focus();
        }
    }

    //取消事件
    protected void btnEsc_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPWD.Text = "";
        txtUserName.Focus();
    }
    protected void lkbtn_pageReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/pageReg.aspx");
    }
}

