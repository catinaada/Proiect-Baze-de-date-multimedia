using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proiect_BDM
{
    public partial class Inserare : System.Web.UI.Page
    {
        OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SIR DE CONEXIUNE

            string cons = "User ID=STUD_CATINAA; Password=STUDENT; Data Source=(DESCRIPTION=" +

            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=37.120.249.41)(PORT=1521)))" +

            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcls)));";

            con = new OracleConnection(cons); //instantiez conexiunea

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            label_mesaj.Text = "";

            if (tb_id.Text != "" && tb_den_tablou.Text != "" && tb_nume_artist.Text != "" && tb_pret.Text != "")
            {
                if (FileUpload1.HasFile)
                {

                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    string[] toateExtensiile = { ".jpg", ".png", "jpeg" };

                    if (toateExtensiile.Contains(fileExtension))
                    {

                        FileUpload1.SaveAs(@"C:\Users\Ada\Desktop\Master BDSA\Baze de date multimedia\Proiect\" + FileUpload1.FileName);
                        label_mesaj.Text = "Fisierul incarcat se numeste: " + FileUpload1.FileName;
                        using (var img = System.IO.File.OpenRead(@"C:\Users\Ada\Desktop\Master BDSA\Baze de date multimedia\Proiect\" + FileUpload1.FileName))
                        {
                            var imageBytes = new byte[img.Length]; //lungimea imaginii
                            img.Read(imageBytes, 0, (int)imageBytes.Length); //citesc imaginea de la inceput,pana la sfarsit
                            label_mesaj.Text = "Tablou adaugat ";

                            //apelam procedura
                            try
                            {
                                con.Open(); //deschidem conexiunea

                            }
                            catch (OracleException ex)
                            {
                                label_mesaj.Text = "Eroare " + ex.Message;
                            }

                            OracleCommand cmd = new OracleCommand("inserareFisier", con);//numele procedurii 
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            cmd.Parameters.Add("vid", OracleDbType.Int32);
                            cmd.Parameters.Add("vnume", OracleDbType.Varchar2, 30);
                            cmd.Parameters.Add("vdenumire", OracleDbType.Varchar2, 255);
                            cmd.Parameters.Add("vtema", OracleDbType.Varchar2, 15);
                            cmd.Parameters.Add("vpret", OracleDbType.Int32);
                            cmd.Parameters.Add("fis", OracleDbType.Blob);

                            //directia parametrilor, de intrare/iesire, am de intrare si merge implicit

                            cmd.Parameters[0].Value = Convert.ToInt32(tb_id.Text);
                            cmd.Parameters[1].Value = tb_nume_artist.Text;
                            cmd.Parameters[2].Value = tb_den_tablou.Text;
                            cmd.Parameters[3].Value = DropDownList1.Text;
                            cmd.Parameters[4].Value = Convert.ToInt32(tb_pret.Text);
                            cmd.Parameters[5].Value = imageBytes;
                            try
                            {
                                cmd.ExecuteNonQuery();

                            }
                            catch (OracleException ex)
                            {

                                label_mesaj.Text = "Eroare " + ex.Message;

                            }

                        }
                    }
                    else
                    {
                        label_mesaj.Text = "Fisierul nu e de tip imagine";
                    }
                }
                else
                {
                    label_mesaj.Text = "Nu ati introdus datele";
                }
            }
            else
            {
                label_mesaj.Text = "Nu ai introdus toate datele!";
            }
        }

        //protected void btn_generare_sem_Click(object sender, EventArgs e)
        //{
        //    label_mesaj.Text = "";
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (OracleException ex)
        //    {
        //        label_mesaj.Text = "Eroare " + ex.Message;
        //    }

        //    OracleCommand cmd1 = new OracleCommand("generareSemnaturi", con);//numele procedurii 
        //    cmd1.CommandType = System.Data.CommandType.StoredProcedure;

        //    try
        //    {
        //        cmd1.ExecuteNonQuery();
        //    }
        //    catch (OracleException ex)
        //    {
        //        label_mesaj.Text = "Eroare " + ex.Message;
        //    }
        //    label_mesaj.Text = "Semnatura generata";

        //    con.Close();

        //}
    }
}