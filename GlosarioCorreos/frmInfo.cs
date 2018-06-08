using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GlosarioCorreos
{
    public partial class frmInfo : Form
    {
        #region Variables
        private int IDCorreo = 0;
        #endregion Variables
        #region Propiedades
        public int IdCorreo
        {
            set
            {
                IDCorreo = value;
            }
        }
        #endregion Propiedades
        #region Metodos
        public frmInfo()
        {
            InitializeComponent();
        }

        private DataTable TransponerTabla(DataTable TablaOriginal)
        {
            DataTable TablaTranspuesta = new DataTable();

            TablaTranspuesta.Columns.Add(TablaOriginal.Columns[0].ColumnName.ToString());

            foreach (DataRow inRow in TablaOriginal.Rows)
            {
                string Columna = inRow[0].ToString();

                TablaTranspuesta.Columns.Add(Columna);
            }

            for (int rConteo = 1; rConteo <= TablaOriginal.Columns.Count - 1; rConteo++)
            {
                DataRow dr = TablaTranspuesta.NewRow();

                dr[0] = TablaOriginal.Columns[rConteo].ColumnName.ToString();

                for (int cConteo = 0; cConteo <= TablaOriginal.Rows.Count - 1; cConteo++)
                {
                    string ValorColumna = TablaOriginal.Rows[cConteo][rConteo].ToString();

                    dr[cConteo + 1] = ValorColumna;
                }

                TablaTranspuesta.Rows.Add(dr);
            }

            return TablaTranspuesta;
        }
        #endregion Metodos
        #region Eventos
        private void frmInfo_Load(object sender, EventArgs e)
        {
            if (IDCorreo > 0)
            {
                SqlConnection cn = null;
                SqlCommand cmd = null;

                try
                {
                    DataTable Resultados = new DataTable();
                    string QueryResultante = "";

                    QueryResultante = GlosarioCorreos.Properties.Resources.QueryInfoCorreo.Replace("@@GC_Id", IDCorreo.ToString());

                    cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                    cmd = new SqlCommand(QueryResultante, cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();
                    cmd.CommandTimeout = 18000;
                    Resultados.Load(cmd.ExecuteReader());

                    if (Resultados.Rows.Count == 1)
                    {
                        lstInfo.DataSource = TransponerTabla(Resultados);
                    }
                    else
                    {
                        MessageBox.Show("No se obtuvo la información para el correo con Id: " + IDCorreo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                finally
                {
                    if (cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se recibió correctamente el Id del correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #endregion Eventos
    }
}
