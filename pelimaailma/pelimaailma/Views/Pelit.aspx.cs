using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pelimaailma.Views
{
    public partial class Pelit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 PeliId;
            PeliId = (Int32)GridView1.SelectedValue;
            this.Session["peliid"] = PeliId;
            Response.Redirect("Tilaus/Peli.aspx");
        }
    }
}