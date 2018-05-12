﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace masterBlog
{
    public partial class adminBlog : System.Web.UI.Page
    {
        sqlbaglanti bag = new sqlbaglanti();   
        string blogID = "";
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            blogID = Request.QueryString["blogID"];
            islem = Request.QueryString["islem"];
            if (islem == "sil")
            {
                SqlCommand cmdsil = new SqlCommand("delete from blog where blogID='" + blogID + "'  ", bag.baglan());
                cmdsil.ExecuteNonQuery();
            }

            if (Page.IsPostBack == false)
            {
                blogekle.Visible = true;
                blogguncelle.Visible = true;
            }

            SqlCommand cmdgetir = new SqlCommand("Select * from blog", bag.baglan());
            SqlDataReader drgetir = cmdgetir.ExecuteReader();

            DataList1.DataSource = drgetir;
            DataList1.DataBind();
        }

        protected void arti_Click(object sender, EventArgs e)
        {
            blogekle.Visible = true;
        }

        protected void eksi_Click(object sender, EventArgs e)
        {
            blogekle.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string uzanti = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string yol = Server.MapPath("~/blogresim/");
                    FileUpload1.SaveAs(yol + blogID + uzanti);
                    SqlCommand cmdekle = new SqlCommand("insert into blog(blogBaslik,blogIcerik,blogOzet,blogResim) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + FileUpload1.FileName + "')", bag.baglan());
                    cmdekle.ExecuteNonQuery();

                    Response.Redirect("adminBlog.aspx");
                }
            }
            else
            {
                Label1.Text = "Resim Ekle !!!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            blogguncelle.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            blogguncelle.Visible = false;
        }
    }
}