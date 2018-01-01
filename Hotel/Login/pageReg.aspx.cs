using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class pageReg : System.Web.UI.Page
{
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdr;//定义记录集
    int iUserSex;//定义性别变量
    SqlDataReader sdrP;//定义记录集
    SqlDataReader sdrC;//定义记录集
    SqlDataReader sdrCo;//定义记录集
    string sAdress;//定义地址字符串

    //窗体加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //加载省市ddl
            //sql = "SELECT * FROM tb_AreaInfo WHERE iAreaClass = 1";
            //sdrP = cDL.QueryOperation(sql);
            //ddlAreaP.DataSource = sdrP;
            //ddlAreaP.DataBind();

            txtUserName.Focus();//光标定位
        }
    }

    //注册事件
    protected void btnReg_Click(object sender, EventArgs e)
    {
        //定义查询语句
        sql = string.Format("SELECT * FROM tb_UserInfo WHERE vcUserName = '{0}'", txtUserName.Text.ToString());

        //返回记录集
        sdr = cDL.QueryOperation(sql);

        if (sdr.Read())//有数据
        {
            Response.Write("用户名已存在，请重新输入");
            txtUserName.Text = "";
            txtPWD.Text = "";
            txtUserPhone.Text = "";
            txtUserIDCard.Text = "";
            txtUserName.Focus();//光标定位
        }
        else//没有数据
        {
            //读取性别
            if (rbUserSex1.Checked)
                iUserSex = 1;
            if (rbUserSex2.Checked)
                iUserSex = 2;

            //Response.Write(calBirthday.SelectedDate.Date.ToString());
            
            //定义执行语句
           //sAdress = ddlAreaP.SelectedItem.Text.ToString() + '省' + ddlAreaC.SelectedItem.Text.ToString() + '市' + ddlAreaCo.SelectedItem.Text.ToString() + '市' + txtUserIDCard.Text.ToString();
            sql = string.Format("insert into tb_UserInfo (vcUserName,vcUserPWD,vcUserPhone,iUserSex,vcUserIDCard,iUserRole,vcMemo) values('{0}','{1}','{2}',{3},'{4}',2,'8888')", txtUserName.Text.ToString(), txtPWD.Text.ToString(), txtUserPhone.Text.ToString(), iUserSex, txtUserIDCard.Text.ToString());
        
           //执行
           if(cDL.ExeNonQuery(sql))
           {
               Response.Write("注册成功!");
               //获取Session
               Session["UserName"] = txtUserName.Text.ToString();
               Response.Redirect("~/Login/pageLogin.aspx");
           }
           else
           {
               Response.Write("注册shibai!");
           }
        }
    }

    ////省市下拉框改变事件
    //protected void ddlAreaP_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //加载地市ddl
    //    sql =string.Format("SELECT * FROM tb_AreaInfo WHERE iAreaClass = 2 AND pre_iAreaID = {0}",Convert.ToInt16(ddlAreaP.SelectedValue.ToString()));
    //    sdrC = cDL.QueryOperation(sql);
    //    ddlAreaC.DataSource = sdrC;
    //    ddlAreaC.DataBind();
    //}

    ////地市下拉框改变事件
    //protected void ddlAreaC_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //加载县市ddl
    //    sql = string.Format("SELECT * FROM tb_AreaInfo WHERE iAreaClass = 3 AND pre_iAreaID = {0}", Convert.ToInt16(ddlAreaC.SelectedValue.ToString()));
    //    sdrCo = cDL.QueryOperation(sql);
    //    ddlAreaCo.DataSource = sdrCo;
    //    ddlAreaCo.DataBind();
    //}
}