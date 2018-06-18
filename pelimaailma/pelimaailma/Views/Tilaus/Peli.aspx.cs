using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using pelimaailma.Models;


namespace pelimaailma.Views
{
    public partial class Peli : System.Web.UI.Page
    {
        Int32 PeliId;
        Int32 Lkm;
        String current_username;

        protected void Page_Load(object sender, EventArgs e)
        {

            PeliId = (Int32)this.Session["peliid"];

            current_username = Context.User.Identity.Name;

            TilausTietokanta til = new TilausTietokanta();

            string connStr = WebConfigurationManager.ConnectionStrings["PelimaailmaConnectionString"]
               .ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sqlQuery = "SELECT PeliId, Nimi, Vuosi, Alusta, Hinta FROM Pelit WHERE PeliId = @PeliId";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, conn);
            sqlCmd.Parameters.AddWithValue("@PeliId", PeliId);

            try
            {
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                FormView1.DataSource = reader;
                FormView1.DataBind();
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(
             "Error: Unable to connect to the database!");
            }
            finally
            {
                conn.Close();
            }
        }
        protected void ButtonTilaa_Click(object sender, EventArgs e)
        {
            Lkm = Int32.Parse(TextBoxLukumaara.Text);

            Models.TilausTietokanta til = new Models.TilausTietokanta();
            int TilausId = til.TeeTilaus(current_username, PeliId, Lkm);

            if (TilausId > 0 && Lkm != 0)
            {
                Boolean onnistuiko = til.LisaaTilausRivi(TilausId, PeliId, Lkm);

                if (onnistuiko)
                {
                    LabelOnnistuikoTilaus.Text = "Kiitos tilauksestanne!";
                    LabelOnnistuikoTilaus.Visible = true;
                    Server.Transfer("Tilaus.aspx");
                }
                else
                {
                    LabelOnnistuikoTilaus.Text = "Tilauksen tallennus ei onnistunut. Yritä uudelleen!";
                    LabelOnnistuikoTilaus.Visible = true;
                }
            }
            else
            {
                LabelOnnistuikoTilaus.Text = "Tilauksen tallennus ei onnistunut. Yritä uudelleen!";
                LabelOnnistuikoTilaus.Visible = true;
            }


        }

        protected void TextBoxLukumaara_TextChanged(object sender, EventArgs e)
        {
        }
    }
}