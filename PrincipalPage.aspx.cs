using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proiect_BDM
{
    public partial class PrincipalPage : System.Web.UI.Page
    {
        OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SIR DE CONEXIUNE
            label_mesaj.Text = "";

            string cons = "User ID=STUD_CATINAA; Password=STUDENT; Data Source=(DESCRIPTION=" +

            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=37.120.249.41)(PORT=1521)))" +

            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcls)));";

            con = new OracleConnection(cons); //instantiez conexiunea

            List<Tablouri> listaTablouri = new List<Tablouri>();
            string interogareAfisare = "SELECT id, nume_artist, denumire, tema, pret  from tablouri";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(interogareAfisare, con);

                // Foloseste OracleDataAdapter pentru a obtine datele
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataSet dataset = new DataSet(); //container care stocheaza datele
                adapter.Fill(dataset);

                if (dataset.Tables.Count > 0)
                {
                    DataTable dataTable = dataset.Tables[0];

                    foreach (DataRow row in dataTable.Rows) //se extrag valorile din coloanele randului curent
                    {
                        int id = Convert.ToInt32(row["id"]);
                        string numeArtist = row["nume_artist"].ToString();
                        string denumire = row["denumire"].ToString();
                        string tema = row["tema"].ToString();
                        int pret = Convert.ToInt32(row["pret"]);

                        OracleCommand cmd1 = new OracleCommand("cautare_tb", con);//numele procedurii 
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd1.Parameters.Add("vid", OracleDbType.Int32);
                        cmd1.Parameters.Add("flux", OracleDbType.Blob);

                        //directia pentru parametrul de iesire
                        cmd1.Parameters[0].Direction = System.Data.ParameterDirection.Input;
                        cmd1.Parameters[1].Direction = System.Data.ParameterDirection.Output;

                        cmd1.Parameters[0].Value = id;
                        cmd1.ExecuteScalar(); //cand vreau sa returneze un singur element

                        Byte[] blob = new Byte[((OracleBlob)cmd1.Parameters[1].Value).Length];


                        ((OracleBlob)cmd1.Parameters[1].Value).Read(blob, 0, blob.Length); //citeste variabila


                        Tablouri tablou = new Tablouri(id, numeArtist, denumire,tema, pret, blob);
                        listaTablouri.Add(tablou);
                    }
                }

               
                dataList.DataSource = listaTablouri;
                dataList.DataBind();
            }
            catch (OracleException ex)
            {
                label_mesaj.Text = "Eroare: " + ex.Message;
            }
            finally
            {
                con.Close();
            }


        }

    }
}