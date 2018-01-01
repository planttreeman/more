using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Manage_pageRoomManage : System.Web.UI.Page
{
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdrGv;//定义记录集 
    protected void Page_Load(object sender, EventArgs e)
    {
        txtRoomNumber.Focus();
        ShowGv();
    }
    //add room
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //sql插入语句
        sql = string.Format("insert into tb_RoomInfo values({0},'{1}',{2},'{3}','8888')", Convert.ToInt32(txtRoomNumber.Text.ToString()), txtRoomClass.Text.ToString(), Convert.ToInt32(txtRoomPrice.Text.ToString()), txtRoomZT.Text.ToString());
       
        //数据库执行
        cDL.ExeNonQuery(sql);

        txtRoomNumber.Text = "";
        txtRoomClass.Text = "";
        txtRoomPrice.Text = "";
        txtRoomZT.Text = "";

        txtRoomNumber.Focus();

        ShowGv();
    }
    protected void ShowGv()
    {
        gvWare.DataSource = null;

        //sql查询语句
        sql = "SELECT * from tb_RoomInfo";

        //数据已经存到sdrYi记录集里
        sdrGv = cDL.QueryOperation(sql);

        //绑定数据源
        gvWare.DataSource = sdrGv;

        //数据加载
        gvWare.DataBind();
    }



    protected void gvWare_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt16(gvWare.DataKeys[e.RowIndex].Value.ToString());

        sql = string.Format("delete from  tb_RoomInfo where iRoomID={0}", id);

        //数据库执行
        cDL.ExeNonQuery(sql);

        ShowGv();
    }
   
}