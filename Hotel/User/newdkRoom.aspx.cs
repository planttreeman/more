using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class User_dkRoom : System.Web.UI.Page
{
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdrGv;//定义记录集 
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowGv();
    }
    protected void ShowGv()
    {

        ggd.DataSource = null;

        //sql查询语句
        sql = "SELECT * from tb_RoomInfo where iRoomZT='闲置'";

        //数据已经存到sdrYi记录集里
        sdrGv = cDL.QueryOperation(sql);

        //绑定数据源
        ggd.DataSource = sdrGv;

        //数据加载
        ggd.DataBind();
    }
}