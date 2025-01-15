using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Proiect_BDM
{
    public partial class Vizualizare : System.Web.UI.Page
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

        protected void btn_flip_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                con.Open(); //deschidem conexiunea

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                return;
            }

            OracleCommand cmd = new OracleCommand("proc_flip", con);//numele procedurii 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("vid", OracleDbType.Int32);
            cmd.Parameters.Add("flux", OracleDbType.Blob);

            //directia pentru parametrul de iesire
            cmd.Parameters[0].Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters[1].Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters[0].Value = Convert.ToInt32(tb_id.Text);

            try
            {
                cmd.ExecuteNonQuery(); //cand vreau sa returneze nu returneze

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                con.Close(); // Asigurați-vă că închideți conexiunea în caz de eroare
                return;
            }

            Byte[] blob = new Byte[((OracleBlob)cmd.Parameters[1].Value).Length];

            try
            {
                ((OracleBlob)cmd.Parameters[1].Value).Read(blob, 0, blob.Length); //citeste variabila

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                con.Close();
            }
            

            Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(blob);
        }

        protected void btn_stergere_tablou_Click(object sender, EventArgs e)
        {

        }

        protected void btn_roteste_tablou_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            if(tb_rotatie.Text!="")
            { 
            try
            {
                con.Open(); //deschidem conexiunea

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                return;
            }

            OracleCommand cmd = new OracleCommand("proc_rotate", con);//numele procedurii 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("vid", OracleDbType.Int32);
            cmd.Parameters.Add("vgrade", OracleDbType.Int32);
            cmd.Parameters.Add("flux", OracleDbType.Blob);

            //directia pentru parametrul de iesire
            cmd.Parameters[0].Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters[1].Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters[2].Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters[0].Value = Convert.ToInt32(tb_id.Text);
            cmd.Parameters[1].Value = Convert.ToInt32(tb_rotatie.Text);

            try
            {
                cmd.ExecuteNonQuery(); //cand vreau sa returneze un singur element

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                con.Close(); // Asigurați-vă că închideți conexiunea în caz de eroare
                return;
            }

            byte[] blob = new byte[((OracleBlob)cmd.Parameters[2].Value).Length];

            try
            {
                ((OracleBlob)cmd.Parameters[2].Value).Read(blob, 0, blob.Length); //citeste variabila

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                con.Close();
            }

            Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(blob);
            }
            else
            {
                Label1.Text = "Trebuie sa introduci gradul de rotatie!";
            }
        }

        protected void btn_cautare_Click(object sender, EventArgs e)
        {
            if (tb_id.Text!="") { 
            try
            {
                con.Open(); 

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

            cmd.Parameters[0].Value = Convert.ToInt32(tb_id.Text);

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
        }
        else{
                Label1.Text = "Trebuie sa introduci id-ul!";
            }
        }

        protected void tb_rotatie_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
         
        }

        protected void btn_grey_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            try
            {
                con.Open(); //deschidem conexiunea

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                return;
            }

            OracleCommand cmd = new OracleCommand("proc_greyscale", con);//numele procedurii 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("vid", OracleDbType.Int32);
            cmd.Parameters.Add("flux", OracleDbType.Blob);

            //directia pentru parametrul de iesire
            cmd.Parameters[0].Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters[1].Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters[0].Value = Convert.ToInt32(tb_id.Text);

            try
            {
                cmd.ExecuteNonQuery(); //cand vreau sa returneze nu returneze

            }
            catch (OracleException ex)
            {
                Label1.Text = ex.Message;
                con.Close(); // Asigurați-vă că închideți conexiunea în caz de eroare
                return;
            }

            Byte[] blob = new Byte[((OracleBlob)cmd.Parameters[1].Value).Length];

            try
            {
                ((OracleBlob)cmd.Parameters[1].Value).Read(blob, 0, blob.Length); //citeste variabila

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                con.Close();
            }


            Image1.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(blob);
        }
    }
}