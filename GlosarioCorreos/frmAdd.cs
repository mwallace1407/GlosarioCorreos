using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delimon.Win32.IO;

namespace GlosarioCorreos
{
    public partial class frmAdd : Form
    {
        #region Variables

        private const int MaxLog = 1000000;
        private const string ArchivoLog = "LogEventos.log";

        private string vArchivo = "";
        private string vEquipo = "";
        private string vRuta = "";

        #endregion Variables

        #region Propiedades

        public string Archivo
        {
            get { return vArchivo; }
            set { vArchivo = value; }
        }

        public string Ruta
        {
            get { return vRuta; }
            set { vRuta = value; }
        }

        public string Equipo
        {
            get { return vEquipo; }
            set { vEquipo = value; }
        }

        #endregion Propiedades

        #region Metodos

        #region Log

        private void RegistrarLogLocal(string Modulo, string Mensaje, string PST, string ArchivoStr)
        {
            try
            {
                string Archivo = Path.Combine(Environment.CurrentDirectory, ArchivoLog);

                Mensaje = Mensaje.Replace("\n", ";").Replace("\r", ";");
                File.AppendAllText(Archivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff") + "\t" + Modulo + "\t" + Mensaje + "\t" + PST + "\t" + ArchivoStr + Environment.NewLine, Encoding.UTF8);

                int LineasSobrantes = File.ReadAllLines(Archivo).Count() - MaxLog;

                if (LineasSobrantes > 0)
                {
                    List<string> linesList = File.ReadAllLines(Archivo).ToList();

                    for (int w = 0; w < LineasSobrantes; w++)
                        linesList.RemoveAt(w);

                    File.WriteAllLines(Archivo, linesList.ToArray(), Encoding.UTF8);
                }
            }
            catch { }
        }

        #endregion Log

        public frmAdd()
        {
            InitializeComponent();
        }

        private void RegistrarPST(string sArchivo, string sRuta, string sEquipo, bool Activo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioCorreosCatalogo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GCP_Archivo", SqlDbType.VarChar);
                param.Value = sArchivo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCP_Ruta", SqlDbType.VarChar);
                param.Value = sRuta;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCP_Equipo", SqlDbType.VarChar);
                param.Value = sEquipo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCP_Activo", SqlDbType.Bit);
                param.Value = Activo;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 10;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("RegistrarPST", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        #endregion Metodos

        #region Eventos

        private void frmAdd_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vArchivo))
            {
                txtNombre.Text = vArchivo;
                txtEquipo.Text = vEquipo;
                txtRuta.Text = vRuta;
                txtNombre.SelectAll();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
                System.IO.Path.GetFileNameWithoutExtension(txtNombre.Text).Length > 0 &&
                System.IO.Path.GetExtension(txtNombre.Text) == ".pst" &&
                !string.IsNullOrWhiteSpace(txtRuta.Text) &&
                !string.IsNullOrWhiteSpace(txtEquipo.Text))
            {
                RegistrarPST(txtNombre.Text.Trim(), txtRuta.Text.Trim(), txtEquipo.Text.Trim(), chkActivo.Checked);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Datos incorrectos", "Glosario de correos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RegistrarPST(txtNombre.Text.Trim(), txtRuta.Text.Trim(), txtEquipo.Text.Trim(), false);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion Eventos
    }
}