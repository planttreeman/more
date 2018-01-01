using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class User_Default : System.Web.UI.Page
{
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdrGv;//定义记录集
    SqlDataReader sdr;//定义记录集
    //int iRoomID;//定义用户ID
    //int iUserID;//定义用户ID
    //string vcRoomClass;
    //int iRoomZT ;
    //int numRoomPrice;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowGv();

    }

    //显示已订购房间
    protected void ShowGv()
    {
        //ggd.DataSource = null;

        ////通过Session查找用户ID
        //sql = string.Format("SELECT iUserID FROM tb_UserInfo WHERE vcUserName = '{0}'", Session["UserName"].ToString());
        //sdr = cDL.QueryOperation(sql);
        //sdr.Read();
        //iUserID = sdr.GetInt32(0);

        //sql查询语句
        sql = string.Format("select * from tb_myRoomInfo where  vcUserName = '{0}' and iRoomZT='已预订入住' ", Session["UserName"].ToString());
        //数据已经存到sdrYi记录集里
        sdrGv = cDL.QueryOperation(sql);

        //绑定数据源
        ggd.DataSource = sdrGv;

        //数据加载
        ggd.DataBind();


    }

    //显示历史房间定单
    protected void ShowHisGv()
    {
        //ggd.DataSource = null;

        ////通过Session查找用户ID
        //sql = string.Format("SELECT iUserID FROM tb_UserInfo WHERE vcUserName = '{0}'", Session["UserName"].ToString());
        //sdr = cDL.QueryOperation(sql);
        //sdr.Read();
        //iUserID = sdr.GetInt32(0);

        //sql查询语句
        sql = string.Format("select * from tb_myRoomInfo where  vcUserName = '{0}' and iRoomZT='已退房' ", Session["UserName"].ToString());
        //数据已经存到sdrYi记录集里
        sdrGv = cDL.QueryOperation(sql);

        //绑定数据源
        ggd.DataSource = sdrGv;

        //数据加载
        ggd.DataBind();


    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {
        ShowHisGv();
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        ShowAllGv();
    }

    //显示all房间定单
    protected void ShowAllGv()
    {
        //ggd.DataSource = null;

        ////通过Session查找用户ID
        //sql = string.Format("SELECT iUserID FROM tb_UserInfo WHERE vcUserName = '{0}'", Session["UserName"].ToString());
        //sdr = cDL.QueryOperation(sql);
        //sdr.Read();
        //iUserID = sdr.GetInt32(0);

        //sql查询语句
        sql = string.Format("select * from tb_myRoomInfo where  vcUserName = '{0}'", Session["UserName"].ToString());
        //数据已经存到sdrYi记录集里
        sdrGv = cDL.QueryOperation(sql);

        //绑定数据源
        ggd.DataSource = sdrGv;

        //数据加载
        ggd.DataBind();


    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ShowGv();
    }
}