using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proiect_BDM
{
    public partial class Cautare : System.Web.UI.Page
    {
        OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SIR DE CONEXIUNE
            Label1.Text = "";

            string cons = "User ID=STUD_CATINAA; Password=STUDENT; Data Source=(DESCRIPTION=" +

            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=37.120.249.41)(PORT=1521)))" +

            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcls)));";

            con = new OracleConnection(cons); //instantiez conexiunea
        }

        protected void btn_cautare_Click(object sender, EventArgs e)
        {
            if (tb_nume.Text != "") { 
            try
            {
                con.Open(); //deschidem conexiunea

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
            }

            OracleCommand cmd = new OracleCommand("cautare_tb", con);//numele procedurii 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("vid", OracleDbType.Int32);
            cmd.Parameters.Add("flux", OracleDbType.Blob);

            //directia pentru parametrul de iesire
            cmd.Parameters[0].Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters[1].Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters[0].Value = Convert.ToInt32(tb_nume.Text);

            try
            {
                cmd.ExecuteScalar(); //cand vreau sa returneze un singur element

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
            }

            //UN VECTOR DE bytes pentru lungimea imaginii
            byte[] blob = new byte[((OracleBlob)cmd.Parameters[1].Value).Length];

            try
            {
                ((OracleBlob)cmd.Parameters[1].Value).Read(blob, 0, blob.Length); //citeste variabila

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            con.Close();

            Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(blob);
        }else{
            Label1.Text = "Trebuie sa introduci id-ul tabloului!";
        }
        }

        protected void btn_generare_sem_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            try
            {
                con.Open();
            }
            catch (OracleException ex)
            {
                Label2.Text = "Eroare " + ex.Message;
            }

            OracleCommand cmd1 = new OracleCommand("generareSemnaturi", con);//numele procedurii 
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                Label2.Text = "Eroare " + ex.Message;
            }
            Label2.Text = "Semnatura generata";

            con.Close();

        }

        protected void btn_regasire_Click(object sender, EventArgs e)
        {


            Label2.Text = "";
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(@"C:\Users\Ada\Desktop\Master BDSA\Baze de date multimedia\Proiect\" + FileUpload2.FileName);
                Label2.Text = "Fisierul incarcat se numeste: " + FileUpload2.FileName;
                using (var img = System.IO.File.OpenRead(@"C:\Users\Ada\Desktop\Master BDSA\Baze de date multimedia\Proiect\" + FileUpload2.FileName))
                {
                    var imageBytes = new byte[img.Length];
                    img.Read(imageBytes, 0, imageBytes.Length);

                    try
                    {
                        con.Open();
                    }
                    catch (OracleException ex)
                    {
                        Label2.Text = "Eroare " + ex.Message;
                    }

                    OracleCommand cmd = new OracleCommand("regasire_tablou", con);//numele procedurii 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("fis", OracleDbType.Blob);
                    cmd.Parameters.Add("cCuloare", OracleDbType.Decimal);
                    cmd.Parameters.Add("cTextura", OracleDbType.Decimal);
                    cmd.Parameters.Add("cForma", OracleDbType.Decimal);
                    cmd.Parameters.Add("cLocatie", OracleDbType.Decimal);
                    cmd.Parameters.Add("idRez", OracleDbType.Int32);

                    //directia pentru parametrul de iesire
                    for (int i = 0; i < 5; i++)
                    {
                        cmd.Parameters[i].Direction = System.Data.ParameterDirection.Input;

                    }
                    cmd.Parameters[5].Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters[0].Value = imageBytes;
                    cmd.Parameters[1].Value = Convert.ToDecimal(tb_culoare.Text);
                    cmd.Parameters[2].Value = Convert.ToDecimal(tb_textura.Text);
                    cmd.Parameters[3].Value = Convert.ToDecimal(tb_forma.Text);
                    cmd.Parameters[4].Value = Convert.ToDecimal(tb_locatie.Text);

                    try
                    {
                        cmd.ExecuteScalar(); //AM DOAR O valoare de iesire, ca sa returnez mai multe tupluri e cu cursor
                    }
                    catch (OracleException ex)
                    {
                        Label2.Text = "Eroare " + ex.Message;
                    }

                    tb_rez.Text = cmd.Parameters[5].Value.ToString();

                    con.Close();


                }
            }

        }

        protected void btn_cautare_tema_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            List<Tablouri> listaTablouri = new List<Tablouri>();
            string temaVariabila = DropDownList1.Text;
            string interogareAfisare = "SELECT id, nume_artist, denumire, tema, pret  from tablouri where tema='" + temaVariabila + "'";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(interogareAfisare, con);

                // Folosește OracleDataAdapter pentru a obține datele
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                if (dataset.Tables.Count > 0)
                {
                    DataTable dataTable = dataset.Tables[0];

                    foreach (DataRow row in dataTable.Rows)
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


                        Tablouri tablou = new Tablouri(id, numeArtist, denumire, tema, pret, blob);
                        listaTablouri.Add(tablou);
                    }
                }


                dataList.DataSource = listaTablouri;
                dataList.DataBind();
            }
            catch (OracleException ex)
            {
                Label2.Text = "Eroare: " + ex.Message;
            }
            finally
            {
                con.Close();
            }


        }

        protected void tb_nume_TextChanged(object sender, EventArgs e)
        {

        }
    }
}