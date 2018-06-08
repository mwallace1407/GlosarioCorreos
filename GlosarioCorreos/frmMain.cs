using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Delimon.Win32.IO;
using glib.Email;

namespace GlosarioCorreos
{
    public partial class frmMain : Form
    {
        #region Variables

        private const int MaxLog = 1000000;
        private const string ArchivoLog = "LogEventos.log";

        private const string ArchivoLogP = "LogPerformance.log";

        private string vRuta = "";
        private string vPST = "";
        private Int16 vIdPST = 0;
        private int vTotalArchivos = 0;
        private int vConteo = 0;
        private DateTime FechaIni;

        private const int LapsoConteoRest = 1000;
        private int vConteoRest = 0;
        //private DateTime FechaIniRest;

        private const int MaxTimeOut = 5;
        private int ConteoTimeOut = 0;
        //private bool Pausar = false;

        private delegate void tsControlProgress(System.Windows.Forms.ProgressBar target, int value);

        private tsControlProgress updateProgress;

        private delegate void lblControlProgress(System.Windows.Forms.Label target, string value);

        private lblControlProgress updateProgresslbl;

        #endregion Variables

        #region Metodos

        #region Chart

        private void InicializarPieProceso()
        {
            try
            {
                pieProceso.LeftMargin = 10;
                pieProceso.RightMargin = 10;
                pieProceso.TopMargin = 10;
                pieProceso.BottomMargin = 10;
                pieProceso.FitChart = false;
                pieProceso.SliceRelativeHeight = .10f;
                pieProceso.InitialAngle = 90;
                pieProceso.EdgeLineWidth = 1;
                pieProceso.EdgeColorType = System.Drawing.PieChart.EdgeColorType.Contrast;

                pieProceso.Colors = new Color[] { Color.FromArgb(120, Color.LightGreen), Color.FromArgb(120, Color.IndianRed) };
                pieProceso.SliceRelativeDisplacements = new float[] { .05f, .05f };
                pieProceso.Texts = new string[] { "", "" };
            }
            catch { }
        }

        private void CrearPieProceso(decimal TotalArchivos, decimal ArchivosProcesados)
        {
            try
            {
                if (TotalArchivos - ArchivosProcesados >= 1)
                    pieProceso.Values = new decimal[] { ArchivosProcesados, TotalArchivos - ArchivosProcesados };
                else
                    pieProceso.Values = new decimal[] { ArchivosProcesados, 0 };

                pieProceso.ToolTips = new string[] { "Procesado: " + ArchivosProcesados.ToString() + "%", "Restante: " + (TotalArchivos - ArchivosProcesados).ToString() + "%" };
            }
            catch { }
        }

        #endregion Chart

        #region Threading

        public void ActualizarProgressBar(ProgressBar pb, int Valor)
        {
            if (pb.InvokeRequired)
                pb.Invoke(updateProgress, new object[] { pb, Valor });
            else
                pb.Value = Valor;
        }

        public void ActualizarLabel(Label pb, string Valor)
        {
            if (pb.InvokeRequired)
                pb.Invoke(updateProgresslbl, new object[] { pb, Valor });
            else
                pb.Text = Valor;
        }

        #endregion Threading

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

        #region TrackPerformance

        private DateTime FechaIniPerf;
        private int vConteoPerf = 0;

        private void RegistrarLogDesempenno(string Modulo)
        {
            try
            {
                string Archivo = Path.Combine(Environment.CurrentDirectory, ArchivoLogP);

                vConteoPerf++;

                TimeSpan diff = (DateTime.Now - FechaIniPerf);
                File.AppendAllText(Archivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff") + "\t" + vConteoPerf.ToString() + "\t" + Modulo + "\t" + diff.TotalMilliseconds.ToString() + Environment.NewLine, Encoding.UTF8);
            }
            catch { }
        }

        #endregion TrackPerformance

        #endregion Log

        #region BD

        private DataTable ObtenerPST()
        {
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpS_GlosarioCorreosCatalogo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.CommandTimeout = 10;
                MsjBD.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerPST", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return MsjBD;
        }

        private Int64 InsertarCorreo(Int16 CatId, string Remitente, DateTime Fecha, string Asunto, string Cuerpo, string Archivo, string PST, string CarpetaCorreo)
        {
            Int64 CorreoId = 0;
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioCorreos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GCP_Id", SqlDbType.SmallInt);
                param.Value = CatId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GC_Remitente", SqlDbType.VarChar);
                param.Value = Remitente;
                cmd.Parameters.Add(param);

                if (Fecha.Year < 1900)
                    Fecha = new DateTime(1900, 1, 1);

                param = new SqlParameter("@GC_Fecha", SqlDbType.DateTime);
                param.Value = Fecha;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GC_Asunto", SqlDbType.VarChar);
                param.Value = Asunto;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GC_Cuerpo", SqlDbType.VarChar);
                param.Value = Cuerpo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GC_Ruta", SqlDbType.VarChar);
                param.Value = CarpetaCorreo;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 5;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        Int64.TryParse(rdr.GetDecimal(0).ToString(), out CorreoId);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2)
                {
                    ConteoTimeOut++;

                    if (ConteoTimeOut <= MaxTimeOut)
                    {
                        InsertarCorreo(CatId, Remitente, Fecha, Asunto, Cuerpo, Archivo, PST, CarpetaCorreo);
                    }
                    else
                    {
                        ConteoTimeOut = 0;
                        Thread.Sleep(300000);//Esperar 5 minutos
                        InsertarCorreo(CatId, Remitente, Fecha, Asunto, Cuerpo, Archivo, PST, CarpetaCorreo);
                    }
                }
                else
                {
                    RegistrarLogLocal("InsertarCorreo", ex.Message + "->" + ex.StackTrace, PST, Archivo);
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("InsertarCorreo", ex.Message + "->" + ex.StackTrace, PST, Archivo);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return CorreoId;
        }

        private void InsertarAdjuntos(Int64 CorreoId, string Ruta, string Archivo, string Extension, Int64 Tamanno)
        {
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioCorreosAdjuntos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GC_Id", SqlDbType.BigInt);
                param.Value = CorreoId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCA_Ruta", SqlDbType.VarChar);
                param.Value = Ruta;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCA_Archivo", SqlDbType.VarChar);
                param.Value = Archivo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCA_Extension", SqlDbType.VarChar);
                param.Value = Extension;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCA_Tamanno", SqlDbType.BigInt);
                param.Value = Tamanno;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 5;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("InsertarAdjuntos", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void InsertarDestinatarios(Int64 CorreoId, string Destinatario, string Nombre)
        {
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioCorreosDestinatarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GC_Id", SqlDbType.BigInt);
                param.Value = CorreoId;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCD_Destinatario", SqlDbType.VarChar);
                param.Value = Destinatario;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GCD_Nombre", SqlDbType.VarChar);
                param.Value = Nombre;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 5;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("InsertarDestinatarios", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        #endregion BD

        public frmMain()
        {
            InitializeComponent();
            updateProgress = new tsControlProgress(ActualizarProgressBar);
            updateProgresslbl = new lblControlProgress(ActualizarLabel);
            InicializarPieProceso();
        }

        private List<stAdjuntos> ObtenerAdjuntos(string Carpeta, string Archivo, string PST)
        {
            List<stAdjuntos> Adjuntos = new List<stAdjuntos> { };
            bool Excluir;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(Carpeta);

                Archivo = Path.GetFileName(Archivo).Replace(Path.GetExtension(Archivo), "") + "-";
                //string[] Att = Directory.GetFiles(Carpeta, Archivo + "*.*");

                foreach (string att in Directory.GetFiles(Carpeta, Archivo + "*.*"))
                {
                    Excluir = false;

                    if (Path.GetExtension(att) != ".eml" && Path.GetExtension(att) != "")
                    {
                        if (Path.GetFileName(att).Length > 5 && Path.GetFileName(att).Replace(Archivo, "").Substring(0, 5) == "image")
                            Excluir = true;

                        if (!Excluir)
                        {
                            stAdjuntos adj = new stAdjuntos(Path.GetFileName(att).Replace(Archivo, ""), Path.GetExtension(att), new FileInfo(att).Length);
                            Adjuntos.Add(adj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerAdjuntos", ex.Message, PST, Archivo);
            }

            return Adjuntos;
        }

        private List<stDestinatarios> ObtenerDestinarios(ref RxMailMessage msg, string PST, string Archivo)
        {
            List<stDestinatarios> Destinatarios = new List<stDestinatarios> { };

            try
            {
                if (msg.To.Count > 0)
                {
                    foreach (System.Net.Mail.MailAddress address in msg.To)
                    {
                        stDestinatarios dest = new stDestinatarios(address.Address, address.DisplayName);
                        Destinatarios.Add(dest);
                    }
                }

                if (msg.CC.Count > 0)
                {
                    foreach (System.Net.Mail.MailAddress address in msg.CC)
                    {
                        stDestinatarios dest = new stDestinatarios(address.Address, address.DisplayName);
                        Destinatarios.Add(dest);
                    }
                }

                if (msg.Bcc.Count > 0)
                {
                    foreach (System.Net.Mail.MailAddress address in msg.Bcc)
                    {
                        stDestinatarios dest = new stDestinatarios(address.Address, address.DisplayName);
                        Destinatarios.Add(dest);
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerDestinarios", ex.Message, PST, Archivo);
            }

            return Destinatarios;
        }

        private string GetMailText(RxMailMessage mm)
        {
            // check for plain text in body
            if (!mm.IsBodyHtml && !string.IsNullOrEmpty(mm.Body))
                return mm.Body;

            string sText = string.Empty;
            foreach (System.Net.Mail.AlternateView av in mm.AlternateViews)
            {
                // check for plain text
                if (string.Compare(av.ContentType.MediaType, "text/plain", true) == 0)
                    continue;// return StreamToString(av.ContentStream);

                // check for HTML text
                if (string.Compare(av.ContentType.MediaType, "text/html", true) == 0)
                    sText = StreamToString(av.ContentStream);
            }

            // HTML is our only hope
            if (sText == string.Empty && mm.IsBodyHtml && !string.IsNullOrEmpty(mm.Body))
                sText = mm.Body;

            if (sText == string.Empty)
                return string.Empty;
            else
                return sText;
            // need to convert the HTML to plaintext
            //return PgUtil.StripHTML(sText);
        }

        private string StreamToString(System.IO.Stream stream)
        {
            string sText = string.Empty;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
            {
                sText = sr.ReadToEnd();
                stream.Seek(0, System.IO.SeekOrigin.Begin);   // leave the stream the way we found it
                stream.Close();
            }

            return sText;
        }

        private void LeerEML(string Carpeta, string Archivo, string PST, Int16 IdPST)
        {
            try
            {
                MimeReader mime = new MimeReader();
                string Remitente = "";
                Int64 IdCorreo = 0;
                //FechaIniPerf = DateTime.Now; //TrackPerformance
                RxMailMessage msg = mime.GetEmail(Archivo);
                //RegistrarLogDesempenno("GetEmail"); //TrackPerformance

                if (msg != null)
                {
                    List<stAdjuntos> Adjuntos = new List<stAdjuntos> { };
                    List<stDestinatarios> Destinatarios = new List<stDestinatarios> { };

                    //FechaIniPerf = DateTime.Now; //TrackPerformance
                    Adjuntos = ObtenerAdjuntos(Carpeta, Archivo, PST);
                    //RegistrarLogDesempenno("ObtenerAdjuntos"); //TrackPerformance
                    //FechaIniPerf = DateTime.Now; //TrackPerformance
                    Destinatarios = ObtenerDestinarios(ref msg, PST, Archivo);
                    //RegistrarLogDesempenno("ObtenerDestinarios"); //TrackPerformance

                    if (msg.From != null)
                    {
                        Remitente = msg.From.Address;
                    }
                    else
                    {
                        if (msg.Sender != null)
                            Remitente = msg.Sender.Address;
                        else
                            Remitente = "";
                    }

                    //FechaIniPerf = DateTime.Now; //TrackPerformance
                    IdCorreo = InsertarCorreo(IdPST, Remitente, msg.DeliveryDate, msg.Subject, GetMailText(msg), Archivo, PST, Carpeta.Replace(vRuta, ""));
                    //RegistrarLogDesempenno("InsertarCorreo"); //TrackPerformance

                    if (IdCorreo > 0)
                    {
                        foreach (stAdjuntos att in Adjuntos.Distinct())
                        {
                            try
                            {
                                //FechaIniPerf = DateTime.Now; //TrackPerformance
                                InsertarAdjuntos(IdCorreo, Carpeta.Replace(vRuta, ""), att.Archivo, att.Extension, att.Tamanno);
                                //RegistrarLogDesempenno("InsertarAdjuntos"); //TrackPerformance
                            }
                            catch (Exception ex)
                            {
                                RegistrarLogLocal("InsertarAdjuntosCall", ex.Message, PST, Archivo);
                            }
                        }

                        List<string> DestinatariosF = new List<string> { };

                        foreach (stDestinatarios dest in Destinatarios.Distinct())
                        {
                            try
                            {
                                //FechaIniPerf = DateTime.Now; //TrackPerformance
                                if (!DestinatariosF.Contains(dest.Direccion))
                                {
                                    InsertarDestinatarios(IdCorreo, dest.Direccion, dest.Nombre);
                                    DestinatariosF.Add(dest.Direccion);
                                }
                                //RegistrarLogDesempenno("InsertarDestinatarios"); //TrackPerformance
                            }
                            catch (Exception ex)
                            {
                                RegistrarLogLocal("InsertarDestinatariosCall", ex.Message, PST, Archivo);
                            }
                        }
                    }

                    msg.Dispose();
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("LeerEML", ex.Message, PST, Archivo);
            }
        }

        private void ReconocerEML(string Carpeta, string PST, Int16 IdPST)
        {
            try
            {
                foreach (string archivo in Directory.GetFiles(Carpeta))
                {
                    vConteo++;
                    vConteoRest++;

                    try
                    {
                        if (vTotalArchivos > 0)
                            CrearPieProceso(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(vConteo * 100) / vTotalArchivos, 2)));

                        if (vConteoRest >= LapsoConteoRest)
                        {
                            TimeSpan diff = (DateTime.Now - FechaIni);
                            double TotalSegundos = ((vTotalArchivos - vConteo) * diff.TotalSeconds) / vConteo;

                            vConteoRest = 0;
                            ActualizarLabel(lblRestante, CalcularDateDiffStr(DateTime.Now, DateTime.Now.AddSeconds(TotalSegundos), "Restante (aprox.): ", " ", false));
                        }
                    }
                    catch { }

                    if (Path.GetExtension(archivo) == "" && !Path.GetFileName(archivo).Contains("-"))
                    {
                        File.Move(archivo, archivo + ".eml");
                        LeerEML(Carpeta, archivo + ".eml", PST, IdPST);
                    }
                    else if (Path.GetExtension(archivo) == ".eml")
                    {
                        LeerEML(Carpeta, archivo, PST, IdPST);
                    }
                }

                foreach (string subCarpeta in Directory.GetDirectories(Carpeta))
                    ReconocerEML(subCarpeta, PST, IdPST);
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ReconocerEML", ex.Message, PST, Carpeta);
            }
        }

        private void Procesar()
        {
            //FechaIniRest = DateTime.Now;
            ReconocerEML(vRuta, vPST, vIdPST);
        }

        private void Des_HabilitarControles(bool Activo)
        {
            foreach (Control c in this.Controls)
                c.Enabled = Activo;

            pnlPie.Visible = !Activo;
            pnlPie.Enabled = !Activo;
            pieProceso.Enabled = !Activo;
            lblRestante.Visible = !Activo;
        }

        private void CargarLista()
        {
            //ddlPST.Items.Clear();
            ddlPST.DisplayMember = "Descripcion";
            ddlPST.ValueMember = "Valor";
            ddlPST.DataSource = ObtenerPST();
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
            else if (!ContarCeros && diff.Seconds == 0 && diff.TotalMinutes < 0)
                Res += "<1 segundo" + Separador;

            return Res;
        }

        private string CalcularDateDiffStr(TimeSpan diff, string TextoIni, string Separador, bool ContarCeros)
        {
            string Res = "";

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
            else if (!ContarCeros && diff.Seconds == 0 && diff.TotalMinutes < 0)
                Res += "<1 segundo" + Separador;

            return Res;
        }

        #endregion Metodos

        #region Eventos

        private void frmMain_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btnExplorar_Click(object sender, EventArgs e)
        {
            fbd01.ShowDialog(this);
            txtRuta.Text = "";

            if (Directory.Exists(fbd01.SelectedPath))
                txtRuta.Text = fbd01.SelectedPath;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            vRuta = "";
            vPST = "";
            vIdPST = 0;
            vConteo = 0;
            vTotalArchivos = 0;

            txtRuta.Text = txtRuta.Text.Trim();

            if (Directory.Exists(txtRuta.Text))
            {
                if (!string.IsNullOrWhiteSpace(ddlPST.Text))
                {
                    string[] Elementos = ddlPST.Text.Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);

                    if (Elementos.Count() == 3)
                    {
                        vPST = Elementos[1].Trim();
                    }
                }

                Int16.TryParse(ddlPST.SelectedValue.ToString(), out vIdPST);

                if (vIdPST > 0)
                {
                    if (Path.GetFileNameWithoutExtension(vPST).Length > 0 && Path.GetExtension(vPST) == ".pst")
                    {
                        FechaIni = DateTime.Now;
                        Des_HabilitarControles(false);
                        vRuta = txtRuta.Text;

                        try
                        {
                            vTotalArchivos = Directory.GetFiles(vRuta, "*.*", SearchOption.AllDirectories).Count();
                        }
                        catch (Exception ex)
                        {
                            vTotalArchivos = 0;
                            RegistrarLogLocal("btnBuscar", ex.Message, vPST, "N/A");
                        }

                        if (vTotalArchivos == 0)
                            MessageBox.Show("No se pudo calcular el total de archivos, no se mostrará un avance del proceso.", "Glosario de correos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        wkrMain.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("El nombre del PST es incorrecto", "Glosario de correos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el id del PST", "Glosario de correos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El directorio no existe", "Glosario de correos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAgregar_Click(object sender, EventArgs e)
        {
            frmAdd frm = new frmAdd();

            if (!string.IsNullOrWhiteSpace(ddlPST.Text))
            {
                string[] Elementos = ddlPST.Text.Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);

                if (Elementos.Count() == 3)
                {
                    frm.Equipo = Elementos[0].Trim();
                    frm.Archivo = Elementos[1].Trim();
                    frm.Ruta = Elementos[2].Trim();
                }
            }

            if (frm.ShowDialog(this) != DialogResult.Cancel)
                CargarLista();
        }

        private void wkrMain_DoWork(object sender, DoWorkEventArgs e)
        {
            Procesar();
        }

        private void wkrMain_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Des_HabilitarControles(true);
            MessageBox.Show(CalcularDateDiffStr(FechaIni, DateTime.Now, "Tiempo de proceso: ", " ", false));
        }

        private void ddlPST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPST.SelectedIndex > 0)
            {
                tip01.ToolTipTitle = "PST Seleccionado:";
                tip01.SetToolTip(ddlPST, ddlPST.Text);
            }
        }

        #endregion Eventos
    }

    public struct stDestinatarios
    {
        public string Direccion;
        public string Nombre;

        public stDestinatarios(string vDireccion, string vNombre)
        {
            Direccion = vDireccion;
            Nombre = vNombre;
        }
    }

    public struct stAdjuntos
    {
        public string Archivo;
        public string Extension;
        public Int64 Tamanno;

        public stAdjuntos(string vArchivo, string vExtension, Int64 vTamanno)
        {
            Archivo = vArchivo;
            Extension = vExtension;
            Tamanno = vTamanno;
        }
    }
}