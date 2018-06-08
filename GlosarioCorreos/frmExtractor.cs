using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace GlosarioCorreos
{
    public partial class frmExtractor : Form
    {
        #region Variables
        private const int MaxLog = 1000000;
        private const string ArchivoLog = "LogEventos.log";
        private const string ArchivoQ = "QueryEjecutado.log";

        private const int cID = 3;
        private const int cCorreo = 4;

        private DateTime FechaIni;
        private DataTable DTResultados;

        //Variables de búsqueda
        private int vbMaxResultados;
        private string vbPalabrasClave;
        private bool vbUsarFechas;
        private DateTime vbFechaIni;
        private DateTime vbFechaFin;
        private bool vbUsarExtensiones;
        private string vbExtensiones;
        private bool vbUsarRemitentes;
        private string vbRemitentes;
        private bool vbUsarDestinatarios;
        private string vbDestinatarios;
        private string vbBusquedaMult = "OR";
        private bool vbUsarAdjuntos;
        private bool vbUsarBDestinatarios;
        private bool vbUsarBusquedaRapida;
        private bool vbObtenerQuery = false;

        private frmInfo frmI = new frmInfo();
        #endregion Variables
        #region Log
        private void RegistrarLogLocal(string Modulo, string Mensaje, string Equipo, string ArchivoStr)
        {
            try
            {
                string Archivo = Path.Combine(Environment.CurrentDirectory, ArchivoLog);

                Mensaje = Mensaje.Replace("\n", ";").Replace("\r", ";");
                File.AppendAllText(Archivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff") + "\t" + Modulo + "\t" + Mensaje + "\t" + Equipo + "\t" + ArchivoStr + Environment.NewLine, Encoding.UTF8);

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

        private void RegistrarQuery(string Query)
        {
            try
            {
                string Archivo = Path.Combine(Environment.CurrentDirectory, ArchivoQ);

                File.AppendAllText(Archivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff") + Environment.NewLine + Query + Environment.NewLine + "*******************************", Encoding.UTF8);
            }
            catch { }
        }
        #endregion Log
        #region Metodos
        public frmExtractor()
        {
            InitializeComponent();
        }

        private string CalcularDateDiffStr(DateTime ini, DateTime fin, string TextoIni, string Separador, bool ContarCeros)
        {
            string Res = "";
            TimeSpan diff = (fin - ini);

            Res += TextoIni;

            //Días
            if (diff.Days > 0)
            {
                if (diff.Days == 1)
                    Res += diff.Days + " día" + Separador;
                else
                    Res += diff.Days + " días" + Separador;
            }

            if (ContarCeros && diff.Days == 0)
                Res += "0 días" + Separador;

            //Horas
            if (diff.Hours > 0)
            {
                if (diff.Hours == 1)
                    Res += diff.Hours + " hora" + Separador;
                else
                    Res += diff.Hours + " horas" + Separador;
            }

            if (ContarCeros && diff.Hours == 0)
                Res += "0 horas" + Separador;

            //Minutos
            if (diff.Minutes > 0)
            {
                if (diff.Minutes == 1)
                    Res += diff.Minutes + " minuto" + Separador;
                else
                    Res += diff.Minutes + " minutos" + Separador;
            }

            if (ContarCeros && diff.Minutes == 0)
                Res += "0 minutos" + Separador;

            //Segundos
            if (diff.Seconds > 0)
            {
                if (diff.Seconds == 1)
                    Res += diff.Seconds + " segundo" + Separador;
                else
                    Res += diff.Seconds + " segundos" + Separador;
            }

            if (ContarCeros && diff.Seconds == 0)
                Res += "0 segundos" + Separador;
            else if (!ContarCeros && diff.Seconds == 0 && diff.TotalMinutes < 1)
                Res += "<1 segundo" + Separador;

            return Res;
        }

        private void ProcesarDatosAlt(DataTable Datos, DateTime Fecha)
        {
            lstArchivos.DataSource = Datos;

            lblEncontrados.Text = "Correos encontrados: " + Datos.Rows.Count.ToString();
            lblTiempo.Text = CalcularDateDiffStr(Fecha, DateTime.Now, "Tiempo de proceso: ", " ", false);
        }

        private void Des_HabilitarControles(bool Activo)
        {
            foreach (Control c in this.Controls)
                c.Enabled = Activo;
        }

        private string ProcesarExtensiones()
        {
            string Extensiones = "";

            foreach (string Ext in txtExtensiones.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                Extensiones += "'." + Ext + "',";

            if (Extensiones.Length > 0)
                Extensiones = Extensiones.Remove(Extensiones.Length - 1);

            return Extensiones;
        }

        private string ProcesarRemitentes()
        {
            string Remitentes = "";

            foreach (string Rem in txtRemitentes.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                Remitentes += "'" + Rem + "',";

            if (Remitentes.Length > 0)
                Remitentes = Remitentes.Remove(Remitentes.Length - 1);

            return Remitentes;
        }

        private string ProcesarDestinatarios()
        {
            string Destinatarios = "";

            foreach (string Dest in txtDestinatarios.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                Destinatarios += "'" + Dest + "',";

            if (Destinatarios.Length > 0)
                Destinatarios = Destinatarios.Remove(Destinatarios.Length - 1);

            return Destinatarios;
        }

        private void ValidarFechas()
        {
            if (dtFin.Value < dtIni.Value)
            {
                lblErrorFF.Text = "Valores incorrectos. Se ignorará el filtro.";
                chkHayErrorFF.Checked = true;
            }
            else
            {
                lblErrorFF.Text = "";
                chkHayErrorFF.Checked = false;
            }
        }

        private void BuscarCorreos(int MaxRes, 
            string PalabrasClave, 
            bool UsarFechas, 
            DateTime FechaIni, 
            DateTime FechaFin, 
            bool UsarRemitentes,
            string Remitentes,
            bool UsarDestinatarios,
            string Destinatarios,
            bool UsarExtensiones,
            string Extensiones,
            bool UsarAdjuntos,
            bool UsarBDestinatarios,
            bool UsarBusquedaRapida)
        {
            DTResultados = new DataTable("Resultados");
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string QueryResultante = "";

            try
            {
                QueryResultante = GlosarioCorreos.Properties.Resources.QueryBaseBusqueda;
                QueryResultante += Environment.NewLine;

                if (MaxRes > 0)
                    QueryResultante = QueryResultante.Replace("SELECT", "SELECT TOP " + MaxRes.ToString());

                if (UsarAdjuntos || UsarExtensiones)
                    QueryResultante += " LEFT OUTER JOIN GlosarioCorreos_Adjuntos A ON C.GC_Id = A.GC_Id " + Environment.NewLine;

                if (UsarBDestinatarios || UsarDestinatarios)
                    QueryResultante += " LEFT OUTER JOIN GlosarioCorreos_Destinatarios D ON C.GC_Id = D.GC_Id " + Environment.NewLine;

                QueryResultante += "WHERE 1 = 1" + Environment.NewLine;

                if (PalabrasClave != "*.*")
                {
                    string[] Palabras = PalabrasClave.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (Palabras.Length == 1)
                    {
                        QueryResultante += "AND (";

                        if (UsarBusquedaRapida)
                            QueryResultante += "CONTAINS(GC_Asunto,'" + PalabrasClave + "') OR CONTAINS(GC_Cuerpo,'" + PalabrasClave + "')";
                        else
                            QueryResultante += "GC_Asunto LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai OR GC_Cuerpo LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai ";

                        if (UsarAdjuntos)
                            QueryResultante += " OR A.GCA_Archivo LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai ";

                        if (UsarBDestinatarios)
                            QueryResultante += " OR D.GCD_Destinatario LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai OR D.GCD_Nombre LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai ";

                        QueryResultante += ")" + Environment.NewLine;
                    }
                    else
                    {
                        QueryResultante += "AND (";

                        foreach (string Palabra in Palabras)
                        {
                            QueryResultante += "(";

                            if (UsarBusquedaRapida)
                                QueryResultante += "CONTAINS(GC_Asunto,'" + PalabrasClave + "') OR CONTAINS(GC_Cuerpo,'" + PalabrasClave + "')";
                            else
                                QueryResultante += "GC_Asunto LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai OR GC_Cuerpo LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai ";

                            if (UsarAdjuntos)
                                QueryResultante += " OR A.GCA_Archivo LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai ";

                            if (UsarBDestinatarios)
                                QueryResultante += " OR D.GCD_Destinatario LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai OR D.GCD_Nombre LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai ";

                            QueryResultante += ") " + vbBusquedaMult + " " + Environment.NewLine;
                        }

                        QueryResultante = QueryResultante.Remove(QueryResultante.Length - (vbBusquedaMult.Length + 3));
                        QueryResultante += ")" + Environment.NewLine;
                    }
                }

                //if (!string.IsNullOrWhiteSpace(Equipos))
                //    QueryResultante += "AND GA_Equipo IN (" + Equipos + ")" + Environment.NewLine;

                if (UsarFechas)
                {
                    QueryResultante += "AND (GC_Fecha >= '" + FechaIni.ToString("dd/MM/yyyy") + " 00:00:00' AND GC_Fecha <= '" + FechaFin.ToString("dd/MM/yyyy") + " 23:59:59')" + Environment.NewLine;
                }

                //if (UsarFechasM)
                //{
                //    QueryResultante += "AND (GA_FechaModificacion >= '" + FechaIniM.ToString("dd/MM/yyyy") + " 00:00:00' AND GA_FechaModificacion <= '" + FechaFinM.ToString("dd/MM/yyyy") + " 23:59:59')" + Environment.NewLine;
                //}

                //if (UsarTamanno)
                //{
                //    QueryResultante += "AND GA_Tamanno >= " + TamannoMin.ToString() + Environment.NewLine;
                //    QueryResultante += "AND GA_Tamanno <= " + TamannoMax.ToString() + Environment.NewLine;
                //}

                //if (UsarRegAct)
                //{
                //    if (!string.IsNullOrWhiteSpace(RegAct))
                //        QueryResultante += "AND GA_RegistroActual = '" + RegAct + "'" + Environment.NewLine;
                //}

                //if (UsarUnidades)
                //{
                //    if (!string.IsNullOrWhiteSpace(Unidades))
                //        QueryResultante += "AND GA_Unidad IN (" + Unidades + ")" + Environment.NewLine;
                //}

                if (UsarExtensiones)
                {
                    if (!string.IsNullOrWhiteSpace(Extensiones))
                        QueryResultante += "AND GCA_Extension IN (" + Extensiones + ")" + Environment.NewLine;
                }

                if (UsarRemitentes)
                {
                    if (!string.IsNullOrWhiteSpace(Remitentes))
                        QueryResultante += "AND GC_Remitente IN (" + Remitentes + ")" + Environment.NewLine;
                }

                if (UsarDestinatarios)
                {
                    if (!string.IsNullOrWhiteSpace(Remitentes))
                        QueryResultante += "AND GCD_Destinatario IN (" + Destinatarios + ")" + Environment.NewLine;
                }

                //QueryResultante += " ORDER BY GC_Asunto, GC_Fecha "; //Si se ordena se vuelve demasiado lento

                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand(QueryResultante, cn);
                cmd.CommandType = CommandType.Text;

                if (vbObtenerQuery)
                    RegistrarQuery(QueryResultante);

                cn.Open();
                cmd.CommandTimeout = 18000;
                DTResultados.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("BuscarArchivos", ex.Message + "->" + QueryResultante, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private DataTable ResultadosNulos()
        {
            DataTable Resultados = new DataTable();

            Resultados.Columns.Add("Remitente");
            Resultados.Columns.Add("Fecha");
            Resultados.Columns.Add("Asunto");
            Resultados.Columns.Add("ID");
            Resultados.Columns.Add("Correo");

            Resultados.AcceptChanges();

            return Resultados;
        }
        #endregion Metodos
        #region Eventos
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuGuardarBusqueda_Click(object sender, EventArgs e)
        {
            sfd01.ShowDialog(this);

            if (Directory.Exists(Path.GetDirectoryName(sfd01.FileName)))
            {
                try
                {
                    DTResultados.WriteXml(sfd01.FileName);
                    MessageBox.Show("Se ha guardado la búsqueda.", "Extractor del glosario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El directorio destino no existe.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuAbrirBusqueda_Click(object sender, EventArgs e)
        {
            ofd01.ShowDialog(this);

            if (File.Exists(ofd01.FileName))
            {
                try
                {
                    //FechaIni = DateTime.Now;
                    DTResultados = new DataTable("Resultados");
                    DTResultados.ReadXmlSchema(ofd01.FileName);
                    DTResultados.ReadXml(ofd01.FileName);

                    ProcesarDatosAlt(DTResultados, FechaIni);

                    MessageBox.Show("Se ha cargado completamente la búsqueda.", "Extractor del glosario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.", "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmExtractor_Load(object sender, EventArgs e)
        {
            txtKeywords.Focus();
            txtKeywords.SelectAll();
        }

        private void frmExtractor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lstArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargar VistaPrevia
            if (lstArchivos.SelectedIndex >= 0)
                brw01.DocumentText = lstArchivos.Items[lstArchivos.SelectedIndex].SubItems[cCorreo].Text;
        }

        private void lstArchivos_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (lstArchivos.SelectedIndex >= 0)
                {
                    int IdCorreo = 0;

                    int.TryParse(lstArchivos.Items[lstArchivos.SelectedIndex].SubItems[cID].Text, out IdCorreo);
                    frmI.IdCorreo = IdCorreo;
                    frmI.ShowDialog(this);
                }
            }
            catch { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Bloquear controles
            Des_HabilitarControles(false);
            pnlEngine.Visible = true;
            pnlEngine.Enabled = true;
            pbEngine.Enabled = true;
            pnlEngine.Location = gbResultados.Location;
            pnlEngine.Size = gbResultados.Size;
            pnlEngine.BringToFront();

            if (txtKeywords.Text.Length >= 3)
            {
                vbMaxResultados = Convert.ToInt32(numMaxResultados.Value);
                vbPalabrasClave = txtKeywords.Text;
                vbUsarFechas = chkUsarFechas.Checked;
                vbFechaIni = dtIni.Value;
                vbFechaFin = dtFin.Value;
                vbUsarExtensiones = chkUsarExtensiones.Checked;
                vbExtensiones = ProcesarExtensiones();
                vbUsarRemitentes = chkUsarRemitentes.Checked;
                vbRemitentes = ProcesarRemitentes();
                vbUsarDestinatarios = chkUsarDestinatarios.Checked;
                vbDestinatarios = ProcesarDestinatarios();
                vbUsarBusquedaRapida = chkBusquedaRapida.Checked;
                vbUsarAdjuntos = chkUsarAdjuntos.Checked;
                vbUsarBDestinatarios = chkUsarBDestinatarios.Checked;
                
                if (chkHayErrorFF.Checked)
                    vbUsarFechas = false;
                
                lstArchivos.Items.Clear();
                DTResultados = new DataTable("Resultados");
                lstArchivos.DataSource = ResultadosNulos();
                wkrBusqueda.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("El término de búsqueda debe contener al menos tres caracteres.", "Palabras clave incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numMaxResultados_ValueChanged(object sender, EventArgs e)
        {
            if (numMaxResultados.Value == 0)
                lblMaxResT.Visible = true;
            else
                lblMaxResT.Visible = false;
        }

        private void dtIni_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void dtFin_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void wkrBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            FechaIni = DateTime.Now;
            vbObtenerQuery = mnuObtenerQuery.Checked;

            BuscarCorreos(vbMaxResultados,
                vbPalabrasClave,
                vbUsarFechas,
                vbFechaIni,
                vbFechaFin,
                vbUsarRemitentes,
                vbRemitentes,
                vbUsarDestinatarios,
                vbDestinatarios,
                vbUsarExtensiones,
                vbExtensiones,
                vbUsarAdjuntos,
                vbUsarBDestinatarios,
                vbUsarBusquedaRapida);
        }

        private void wkrBusqueda_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (DTResultados.Rows.Count == 0)
            {
                DTResultados = new DataTable("Resultados");
                DTResultados = ResultadosNulos();
                MessageBox.Show("No se obtuvieron resultados para su búsqueda.", "Búsqueda de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ProcesarDatosAlt(DTResultados, FechaIni);
            }

            //Desbloquear controles
            Des_HabilitarControles(true);
            pnlEngine.Visible = false;
            pnlEngine.Enabled = false;
            pbEngine.Enabled = false;
        }

        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtIni.Enabled = chkUsarFechas.Checked;
            dtFin.Enabled = chkUsarFechas.Checked;
            dtIni.Focus();
        }

        private void chkUsarRemitentes_CheckedChanged(object sender, EventArgs e)
        {
            txtRemitentes.Enabled = chkUsarRemitentes.Checked;
        }

        private void chkUsarDestinatarios_CheckedChanged(object sender, EventArgs e)
        {
            txtDestinatarios.Enabled = chkUsarDestinatarios.Checked;
        }

        private void chkUsarExtensiones_CheckedChanged(object sender, EventArgs e)
        {
            txtExtensiones.Enabled = chkUsarExtensiones.Checked;
        }

        private void mnuObtenerQuery_Click(object sender, EventArgs e)
        {

        }
        #endregion Eventos
    }
}
