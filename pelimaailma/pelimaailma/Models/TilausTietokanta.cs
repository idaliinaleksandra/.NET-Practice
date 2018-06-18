using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace pelimaailma.Models
{
    public class TilausTietokanta
    {
        public TilausTietokanta()
        {
        }

        public int TeeTilaus(
          string AsiakasId, int PeliId, int Lkm)
        {
            Int32 TilausId = -1;

            string connStr = WebConfigurationManager.ConnectionStrings["PelimaailmaConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sqlCmd2 = "INSERT INTO TILAUS (PVM) VALUES(GETDATE()); ";
            string sqlCmd3 = "SELECT @@IDENTITY AS [@@IDENTITY];";

            SqlTransaction tran1 = null;
            SqlCommand cmd2 = new SqlCommand(sqlCmd2, conn);
            SqlCommand cmd3 = new SqlCommand(sqlCmd3, conn);

            try
            {
                conn.Open();

                tran1 = conn.BeginTransaction();
                cmd2.Transaction = tran1;
                cmd3.Transaction = tran1;

                int onnistuiko = cmd2.ExecuteNonQuery();
                SqlDataReader reader = cmd3.ExecuteReader();



                while (reader.Read())
                {
                    TilausId = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                tran1.Commit();
                return TilausId;

            }
            catch (SqlException ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean LisaaTilausRivi(int TilausId, int PeliId, int Lkm)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PelimaailmaConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sqlCmd1 = "UPDATE VARASTO SET VAPAALKM = VAPAALKM - @Lkm, VARATTULKM = VARATTULKM + @Lkm WHERE PeliId = @PeliId; ";
            string sqlCmd2 = "INSERT INTO TILAUSRIVI (TILAUSID, PELIID, LUKUMAARA) VALUES(@TilausID, @PeliId, @Lukumaara); ";

            SqlCommand cmd1 = new SqlCommand(sqlCmd1, conn);
            SqlCommand cmd2 = new SqlCommand(sqlCmd2, conn);

            cmd1.Parameters.AddWithValue("@PeliId", PeliId);
            cmd1.Parameters.AddWithValue("@Lkm", Lkm);

            cmd2.Parameters.AddWithValue("@TilausId", TilausId);
            cmd2.Parameters.AddWithValue("@PeliId", PeliId);
            cmd2.Parameters.AddWithValue("@Lukumaara", Lkm);

            SqlTransaction tran1 = null;

            try
            {
                conn.Open();

                tran1 = conn.BeginTransaction();
                cmd1.Transaction = tran1;
                cmd2.Transaction = tran1;

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                tran1.Commit();

                return true;
            }
            catch (SqlException ex)
            {
                tran1.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


        public Boolean OnkoRekisteroitynyt(string aktiivi_tunnus)
        {
            string strConn = WebConfigurationManager.ConnectionStrings["PelimaailmaConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);

            string sqlCmd = "SELECT ASIAKASID FROM ASIAKAS WHERE AsiakasId = @AsiakasId; ";
            SqlCommand cmd1 = new SqlCommand(sqlCmd, conn);
            cmd1.Parameters.AddWithValue("@AsiakasId", aktiivi_tunnus);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                    return true;
                else
                    return false;

            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error: Unable to connect to the database!");
            }
            finally
            {
                conn.Close();
            }
        }



        public string CastToSqlServerDateTime(DateTime Pvm)
        {
            string vvvv = Pvm.Year.ToString();
            string mm = Pvm.Month.ToString();
            string dd = Pvm.Day.ToString();
            return "" + vvvv + "-" + mm + "-" + dd;
        }

    }
}