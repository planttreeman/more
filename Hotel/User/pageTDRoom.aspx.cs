﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class User_pageTDRoom : System.Web.UI.Page
{
    cDataLink cDL = new cDataLink();//定义公共类
    string sql;//查询字符串
    SqlDataReader sdr;//定义记录集
    int iRoomID;//定义用户ID
    int iUserID;//定义用户ID
    string vcRoomClass;
    string iRoomZT;
    int numRoomPrice;
    DateTime dateEnd;
    string date;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //sql查询语句
            sql = string.Format("select * from tb_RoomInfo where iRoomID={0}", Convert.ToInt16(Request.QueryString["iRoomID"].ToString()));

            //数据已经存到sdr记录集里
            sdr = cDL.QueryOperation(sql);

            //绑定数据源
            fvWareDetail.DataSource = sdr;

            //数据加载
            fvWareDetail.DataBind();
        }
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/pageLogin.aspx");
        }
        else
        {
            txtUserID.Text = Session["UserName"].ToString();
        }
        txtDateStart.Text= DateTime.Now.ToString();
        date = txtDateStart.Text;
    }

    protected void BtnCheckOut_Click(object sender, EventArgs e)
    {
        //sql查询语句
        sql = string.Format("select * from tb_RoomInfo where iRoomID={0}", Convert.ToInt32(Request.QueryString["iRoomID"].ToString()));
        //数据已经存到sdr记录集里
        sdr = cDL.QueryOperation(sql);
        sdr.Read();
        iRoomID = sdr.GetInt32(0);
        vcRoomClass = sdr.GetString(1);
        numRoomPrice = sdr.GetInt32(2);
        //iRoomZT = sdr.GetInt32(3);

        sql = string.Format("SELECT iUserID FROM tb_UserInfo WHERE vcUserName = '{0}'", Session["UserName"].ToString());
        sdr = cDL.QueryOperation(sql);
        sdr.Read();
        iUserID = sdr.GetInt32(0);

        iRoomZT = "已退房";
        //把当前退房信息加入到数据库中
        sql = string.Format("INSERT INTO tb_TDRoomInfo (iRoomID, iUserID,vcRoomClass,numRoomPrice,iRoomZT,dateEnd) VALUES ({0},{1},'{2}',{3},'{4}','{5}')", iRoomID, iUserID, vcRoomClass, numRoomPrice, iRoomZT,"+date+");
        cDL.ExeNonQuery(sql);
        cDL.closeConn();
       
        sql = string.Format("update tb_myRoomInfo SET iRoomZT='{0}' where iRoomID = {1}", iRoomZT, iRoomID);
        cDL.ExeNonQuery(sql);
        iRoomZT = "闲置";
        //修改当前房间状态在newdkRoom.aspx
        sql = string.Format("update tb_RoomInfo SET iRoomZT='{0}' WHERE iRoomID = {1}", iRoomZT, iRoomID);
        cDL.ExeNonQuery(sql);


        //跳转到我的房间页面
        Response.Redirect("~/User/pageUserMenu.aspx");
    }
}