using POSalesDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POSalesDb
{
    public class DBConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string path = Directory.GetCurrentDirectory();
        private string con;
        public string myConnection()
        {
            con = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
            return con;
        }

        //get fechaMantenimiento
      public MantenimientoModel FechaMantenimientoModel(int Id,DateTime fechaMantenimiento , DateTime fechaEntrega)
        {
            cn.ConnectionString = myConnection();
            MantenimientoModel MantenimientoModel = new MantenimientoModel();
            try
            {
                cm = new SqlCommand($"Select * from Mantenimiento Where fechaEntregaEquipo between {fechaEntrega} and {fechaMantenimiento} ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MantenimientoModel.Id = (int)dt.Rows[0]["Id"];
                    MantenimientoModel.IdEquipo = (int)dt.Rows[0]["IdEquipo"];
                    MantenimientoModel.fechaMantenimiento = Convert.ToDateTime(dt.Rows[0]["fechaMantenimiento"].ToString());
                    DateTime.TryParse(dt.Rows[0]["fechaEntregaEquipo"].ToString(), out fechaEntrega);
                    MantenimientoModel.fechaEntregaEquipo = fechaEntrega;
                    MantenimientoModel.descripcionFalla = dt.Rows[0]["descripcionFalla"].ToString();
                    MantenimientoModel.solucion = dt.Rows[0]["solucion"].ToString();
                    MantenimientoModel.idEstadoMantenimiento = (int)dt.Rows[0]["idEstadoMantenimiento"];
                    MantenimientoModel.idUsuarios = (int)dt.Rows[0]["idUsuarios"];
                    MantenimientoModel.idOrdenServicio = (int)dt.Rows[0]["idOrdenServicio"];
                    MantenimientoModel.estadoAplicarCorreccion = Convert.ToBoolean(dt.Rows[0]["estadoAplicarCorreccion"]);

                }
                return MantenimientoModel;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return MantenimientoModel;
            }
            finally
            {
                cn.Close();
            }
        }


        //get buscarCliente
        public Clientes BuscarCliente(int id,string buscarNombre,string buscarCi )
        {
            cn.ConnectionString = myConnection();
            Clientes clientes = new Clientes();
            try
            {
                cm = new SqlCommand($"Select * from Clientes Where Id={id} and nombre  like '%{buscarNombre}' and ciRuc like '%{buscarCi}'", cn);
                cn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn))
                {
                    da.Fill(dt);
                }

                if (dt.Rows.Count > 0)
                {
                    clientes.Id = (int)dt.Rows[0]["Id"];
                    clientes.nombre = Convert.ToString(dt.Rows[0]["nombre"]);
                    clientes.comercio = Convert.ToString(dt.Rows[0]["comercio"]);
                    clientes.codigo = Convert.ToString(dt.Rows[0]["codigo"]);
                    clientes.fechaNacimiento = Convert.ToDateTime(dt.Rows[0]["fechaNacimiento"]);
                    clientes.fechaRegistro = Convert.ToDateTime(dt.Rows[0]["fechaRegistro"]);
                    clientes.ciudad = Convert.ToString(dt.Rows[0]["ciudad"]);
                    clientes.tipo = Convert.ToString(dt.Rows[0]["tipo"]);
                    clientes.ciRuc = Convert.ToString(dt.Rows[0]["ciRuc"]);
                    clientes.pais = Convert.ToString(dt.Rows[0]["pais"]);
                    clientes.estado = Convert.ToString(dt.Rows[0]["estado"]);
                    clientes.direccion = Convert.ToString(dt.Rows[0]["direccion"]);
                    clientes.telefono = Convert.ToString(dt.Rows[0]["telefono"]);
                    clientes.celular = Convert.ToString(dt.Rows[0]["celular"]);
                    clientes.fax = Convert.ToString(dt.Rows[0]["fax"]);
                    clientes.cargo = Convert.ToString(dt.Rows[0]["cargo"]);
                    clientes.email = Convert.ToString(dt.Rows[0]["email"]);
                    clientes.tipo = Convert.ToString(dt.Rows[0]["tipoCliente"]);
                }
                return clientes;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return clientes;
            }
            finally
            {
                cn.Close();
            }
        }


        //get OrdenServicioModel id
        public OrdenServicioModel selectOrdenServicioModelPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            OrdenServicioModel orden = new OrdenServicioModel();
            try
            {
                cm = new SqlCommand($"Select * from OrdenServicio Where Id = {Id}", cn);
            
                cn.Open();
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn))
                {
                    da.Fill(dt);
                }
                
                if (dt.Rows.Count > 0)
                {
                    orden.Id = (int)dt.Rows[0]["Id"];
                    orden.Descripcion = dt.Rows[0]["descripcion"].ToString();
                    orden.idCliente = (int)dt.Rows[0]["idCliente"];
                    orden.idUsuarios = (int)dt.Rows[0]["idUsuarios"];
                   
                }
                return orden;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return orden;
            }
            finally
            {
                cn.Close();
            }
        }
        // get OrdenServicioModel
        public List<OrdenServicioModel> selectTodosLasOrdenServicioModel()
        {
            cn.ConnectionString = myConnection();
            List<OrdenServicioModel> ordens = new List<OrdenServicioModel>();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"Select * from OrdenServicio");
                using (SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn))
                {
                    cn.Open();
                    da.Fill(dt);
                }
            
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return ordens;
            }
            finally
            {
                cn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    OrdenServicioModel orden = new OrdenServicioModel();
                    orden.Id = (int)r["Id"];
                    orden.Descripcion = r["descripcion"].ToString();
                    orden.idCliente = (int)r["idCliente"];
                    orden.idUsuarios = (int)r["idUsuarios"];
                    orden.cliente = selectClientesId(orden.idCliente);
                    orden.usuario = selectUsuariosPorId(orden.idUsuarios);
                    orden.mantenimientos = selectLosMantenimientoPorOrden(orden.Id);
                    ordens.Add(orden);
                }

            }
            return ordens;
        }
        public DataSet selectTodosLasOrdenesDS()
        {
            cn.ConnectionString = myConnection();
            DataSet dt = new DataSet();
            try
            {
                cm = new SqlCommand($@"SELECT [ordenServicio].[Id]
                  ,[Fecha Ingreso]
	              ,[idCliente]
	              ,[ciRuc]
                  ,[nombre]
                  ,[idUsuarios]
	              ,[ordenServicio].[Estado]
              FROM [C:\USERS\AVSLA\DOCUMENTS\DBPOSALE.MDF].[dbo].[ordenServicio]
              join clientes on Clientes.Id = ordenServicio.idCliente");
                using (SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn))
                {
                    cn.Open();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }

        }

        private List<MantenimientoModel> selectLosMantenimientoPorOrden(int IdOrden)
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();

            try
            {
                cm = new SqlCommand($"Select * from Mantenimiento where IdOrdenServicio = {IdOrden} ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        MantenimientoModel MantenimientoModel = new MantenimientoModel();
                        MantenimientoModel.Id = (int)r["Id"];
                        MantenimientoModel.fechaMantenimiento = Convert.ToDateTime(r["fechaMantenimiento"].ToString());
                        MantenimientoModel.descripcionFalla = r["descripcionFalla"].ToString();
                        MantenimientoModel.solucion = r["solucion"].ToString();
                        MantenimientoModel.idEstadoMantenimiento = (int)r["idEstadoMantenimiento"];
                        MantenimientoModel.idUsuarios = (int)r["idUsuarios"];
                        MantenimientoModel.idOrdenServicio = (int)r["idOrdenServicio"];
                        if (!string.IsNullOrWhiteSpace(r["precioReferencial"].ToString()))
                        {
                            MantenimientoModel.precioReferencial = (decimal)r["precioReferencial"];
                        }
                        MantenimientoModel.estadoAplicarCorreccion = Convert.ToBoolean(r["estadoAplicarCorreccion"].ToString());
                        MantenimientoModel.reservas = selectReservaPorMantenimiento(MantenimientoModel.Id);
                        MantenimientoModels.Add(MantenimientoModel);
                    }

                }
                return MantenimientoModels;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return MantenimientoModels;
            }
            finally
            {
              
            }
        }

        public List<OrdenServicioModel> selectTodosLasOrdenServicioPorEntregar()
        {
            cn.ConnectionString = myConnection();
            List<OrdenServicioModel> ordens = new List<OrdenServicioModel>();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"Select * from OrdenServicio");
                using (SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn))
                {
                    cn.Open();
                    da.Fill(dt);
                }

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return ordens;
            }
            finally
            {
                cn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    OrdenServicioModel orden = new OrdenServicioModel();
                    orden.Id = (int)dt.Rows[0]["Id"];
                    orden.Descripcion = dt.Rows[0]["descripcion"].ToString();
                    orden.idCliente = (int)dt.Rows[0]["idCliente"];
                    orden.idUsuarios = (int)dt.Rows[0]["idUsuarios"];
                    orden.cliente = selectClientesId(orden.idCliente);
                    orden.usuario = selectUsuariosPorId(orden.idUsuarios);
                    ordens.Add(orden);
                }

            }
            return ordens;
        }
        //insertar OrdenServicioModel 
        public int insertOrdenServicioModel(OrdenServicioModel orden)
        {
            cn.ConnectionString = myConnection();
            int IdOrden = 0;
            try
            {
                cm = new SqlCommand("Insert into OrdenServicio (idCliente,idUsuarios) values(@idCliente,@idUsuarios) SET @ID = SCOPE_IDENTITY(); ", cn);
                cm.Parameters.AddWithValue("@idCliente", orden.idCliente);
                cm.Parameters.AddWithValue("@idUsuarios", orden.idUsuarios);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(),out IdOrden);
                return IdOrden;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return IdOrden;
            }
            finally
            {
                cn.Close();
            }

        }
        //actualizar OrdenServicioModel 
        public string actualizarOrdenServicioModel(OrdenServicioModel orden)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE OrdenServicio SET descripcion=@descripcion,idCliente=@idCliente,idUsuarios=@idUsuarios WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", orden.Id);
                cm.Parameters.AddWithValue("@descripcion",orden.Descripcion);
                cm.Parameters.AddWithValue("@idCliente", orden.idCliente);
                cm.Parameters.AddWithValue("@idUsuarios", orden.idUsuarios);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //eliminar OrdenServicioModel
        public string deleteOrdenServicioModel(int idOrdenServicioModel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM OrdenServicio WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idOrdenServicioModel);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        
        //get MantenimientoModel id
        public MantenimientoModel selectMantenimientoModelPorId(int Id)
        {
            DateTime fechaEntrega;
            cn.ConnectionString = myConnection();
            MantenimientoModel MantenimientoModel = new MantenimientoModel();
            try
            {
                cm = new SqlCommand($"Select * from Mantenimiento Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MantenimientoModel.Id = (int)dt.Rows[0]["Id"];
                    MantenimientoModel.IdEquipo = (int)dt.Rows[0]["IdEquipo"];
                    MantenimientoModel.fechaMantenimiento =Convert.ToDateTime( dt.Rows[0]["fechaMantenimiento"].ToString());
                    DateTime.TryParse(dt.Rows[0]["fechaEntregaEquipo"].ToString(), out fechaEntrega);
                    MantenimientoModel.fechaEntregaEquipo = fechaEntrega;
                    MantenimientoModel.descripcionFalla = dt.Rows[0]["descripcionFalla"].ToString();
                    MantenimientoModel.solucion = dt.Rows[0]["solucion"].ToString();
                    MantenimientoModel.idEstadoMantenimiento =(int)dt.Rows[0]["idEstadoMantenimiento"];
                    MantenimientoModel.idUsuarios=(int)dt.Rows[0]["idUsuarios"];
                    MantenimientoModel.idOrdenServicio = (int)dt.Rows[0]["idOrdenServicio"];
                    MantenimientoModel.estadoAplicarCorreccion = Convert.ToBoolean(dt.Rows[0]["estadoAplicarCorreccion"]);
                    MantenimientoModel.precioReferencial = Convert.ToDecimal(dt.Rows[0]["precioReferencial"].ToString());

                }
                return MantenimientoModel;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return MantenimientoModel;
            }
            finally
            {
                cn.Close();
            }
        }
        public string selectFallaDeEquipo(int Id)
        {
            DateTime fechaEntrega;
            string falla = string.Empty;
            cn.ConnectionString = myConnection();
            MantenimientoModel MantenimientoModel = new MantenimientoModel();
            try
            {
                cm = new SqlCommand($@"SELECT TOP (1) [Id]
                  ,[fechaMantenimiento]
                  ,[fechaEntregaEquipo]
                  ,[descripcionFalla]
                  ,[solucion]
                  ,[IdEstadoMantenimiento]
                  ,[idUsuarios]
                  ,[idOrdenServicio]
                  ,[estadoAplicarCorreccion]
                  ,[estadoNoAplicarCorreccion]
                  ,[idEquipo]
                  ,[precioReferencial]
                  ,[Codigo]
                    FROM [C:\USERS\AVSLA\DOCUMENTS\DBPOSALE.MDF].[dbo].[Mantenimiento]  Where IdEquipo = {1} order by [Id] desc", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    falla = dt.Rows[0]["descripcionFalla"].ToString();
                }
                return falla;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return falla;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectFallasDeEquipo(int Id)
        {
            DataSet dt = new DataSet();
            DateTime fechaEntrega;
            string falla = string.Empty;
            cn.ConnectionString = myConnection();
            MantenimientoModel MantenimientoModel = new MantenimientoModel();
            try
            {
                cm = new SqlCommand($@"SELECT [Id]
      ,[fechaMantenimiento]
      ,[fechaEntregaEquipo]
      ,[descripcionFalla]
      ,[solucion]
      ,[IdEstadoMantenimiento]
      ,[idUsuarios]
      ,[idOrdenServicio]
      ,[estadoAplicarCorreccion]
      ,[estadoNoAplicarCorreccion]
      ,[idEquipo]
      ,[precioReferencial]
      ,[Codigo]
  FROM [C:\USERS\AVSLA\DOCUMENTS\DBPOSALE.MDF].[dbo].[Mantenimiento]  Where IdEquipo = {Id} order by [Id] desc ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();

                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        // get MantenimientoModel
        public List<MantenimientoModel> selectTodosLosMantenimientoModels()
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();

            try
            {
                cm = new SqlCommand($"Select * from Mantenimiento ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        MantenimientoModel MantenimientoModel = new MantenimientoModel();
                        MantenimientoModel.Id = (int)dt.Rows[0]["Id"];
                        MantenimientoModel.fechaMantenimiento = Convert.ToDateTime( dt.Rows[0]["fechaMantenimiento"].ToString());
                        MantenimientoModel.fechaEntregaEquipo = Convert.ToDateTime(dt.Rows[0]["fechaEntregaEquipo"].ToString());
                        MantenimientoModel.descripcionFalla = dt.Rows[0]["descripcionFalla"].ToString();
                        MantenimientoModel.solucion = dt.Rows[0]["solucion"].ToString();
                        MantenimientoModel.idEstadoMantenimiento= (int)dt.Rows[0]["idEstadoMantenimiento"];
                        MantenimientoModel.idUsuarios = (int)dt.Rows[0]["idUsuarios"];
                        MantenimientoModel.idOrdenServicio = (int)dt.Rows[0]["idOrdenServicio"];
                        MantenimientoModel.estadoAplicarCorreccion= Convert.ToBoolean( dt.Rows[0]["estadoAplicarCorreccion"].ToString());
                        MantenimientoModels.Add(MantenimientoModel);
                    }

                }
                return MantenimientoModels;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return MantenimientoModels;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectTodosLosMantenimientoModelsData()
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                   
                         Mantenimiento LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.[IdEstadoMantenimiento] = estadoMantenimiento.Id Order by Mantenimiento.Id desc");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);

                da.Fill(dt);
              
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectTodosLosMantenimientoPorOrdenData(int IdOrden)
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                   
                         Mantenimiento LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.[IdEstadoMantenimiento] = estadoMantenimiento.Id where Mantenimiento.idOrdenServicio = {IdOrden} Order by Mantenimiento.Id desc");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);

                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectTodosLosMantenimientoDeHoyData()
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.codigo as idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                   
                         [dbo].[Mantenimiento] LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.IdEstadoMantenimiento = estadoMantenimiento.Id
						 where fechaMantenimiento = GETDATE()
						 Order by Mantenimiento.Id desc
                      ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);

                da.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectLosMantenimientoPorFechaMantenimientoData(DateTime fechaMantenimientoDesde, DateTime fechaMantenimientoHasta)
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.codigo as idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                            
                         Mantenimiento LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.[IdEstadoMantenimiento] = estadoMantenimiento.Id
                         Where Mantenimiento.fechaMantenimiento Between '{fechaMantenimientoDesde.ToString("yyyy/MM/dd")} 00:00:00' and '{fechaMantenimientoHasta.ToString("yyyy/MM/dd")} 23:59:59'
                         Order by Mantenimiento.Id desc");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectLosMantenimientoPorFechaEntregaData(DateTime FechaEntregaDesde, DateTime FechaEntregaHasta)
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.codigo as idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                             
                         Mantenimiento LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.[IdEstadoMantenimiento] = estadoMantenimiento.Id
                         Where Mantenimiento.fechaEntregaEquipo Between '{FechaEntregaDesde.ToString("yyyy/MM/dd")} 00:00:00' and '{FechaEntregaHasta.ToString("yyyy/MM/dd")} 23:59:59'
                         Order by Mantenimiento.Id desc");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectLosMantenimientoFiltrados(string Search)
        {
            cn.ConnectionString = myConnection();
            List<MantenimientoModel> MantenimientoModels = new List<MantenimientoModel>();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"SELECT Mantenimiento.Id,Mantenimiento.fechaMantenimiento , Mantenimiento.fechaEntregaEquipo, Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.IdEstadoMantenimiento, 
                         Mantenimiento.idUsuarios, Mantenimiento.codigo as idOrdenServicio, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.idEquipo, 
                         Equipo.codigo ,Equipo.descirpcionEquipo, estadoMantenimiento.descripcion
                         FROM                             
                         Mantenimiento LEFT JOIN
                         Equipo ON Mantenimiento.IdEquipo = Equipo.Id LEFT JOIN
                         estadoMantenimiento ON Mantenimiento.[IdEstadoMantenimiento] = estadoMantenimiento.Id
                         Where 
						 CONCAT(Mantenimiento.descripcionFalla, Mantenimiento.solucion, Mantenimiento.codigo, Equipo.codigo,Equipo.descirpcionEquipo) like '%{Search}%'
                         Order by Mantenimiento.Id desc");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public void actualizarEstadoDeOrden(int IdOrdenDeServicio,bool isReady)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE OrdenServicio SET descripcion=@descripcion,idCliente=@idCliente,idUsuarios=@idUsuarios WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@isReady", true);
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
            }
            finally
            {
                cn.Close();
            }
        }

        public void selectContadorDeMantenimientosRealizados(int IdOrdenDeServicio)
        {
            cn.ConnectionString = myConnection();
            cn.Open();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($@"select COUNT(idOrdenServicio) as Contador from Mantenimiento Where IdEstadoMantenimiento < 4 and idOrdenServicio = {IdOrdenDeServicio}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int Contador = 0;
                    if (int.TryParse(dt.Rows[0]["Contador"].ToString(), out Contador))
                    {
                        if (Contador == 0)
                        {
                            actualizarEstadoDeOrden(IdOrdenDeServicio, true);
                        }
                        else
                        {
                            actualizarEstadoDeOrden(IdOrdenDeServicio, false);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
            }
            finally
            {
                cn.Close();
            }
        }
        public string insertarReservas(Reserva reserva)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                actualizarvalorStock(reserva.Cantidad * (-1),reserva.items.Id);
                cm = new SqlCommand(@"Insert into Reserva (IdMantenimiento,estadoReserva,idItem,Cantidad,precioFinal,precioA)
                    values(@IdMantenimiento,@estadoReserva,@idItem,@Cantidad,@precioFinal,@precioA)", cn);
                cm.Parameters.AddWithValue("@IdMantenimiento", reserva.IdMantenimiento);
                cm.Parameters.AddWithValue("@estadoReserva", reserva.estadoReserva = "Activo");
                cm.Parameters.AddWithValue("@idItem", reserva.items.Id);
                cm.Parameters.AddWithValue("@Cantidad", reserva.Cantidad);
                cm.Parameters.AddWithValue("@precioFinal", reserva.precioFinal);
                cm.Parameters.AddWithValue("@precioA", reserva.items.precioA);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        } 
        //insertar MantenimientoModels 
        public string insertMantenimientoModels(MantenimientoModel MantenimientoModel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Mantenimiento (fechaMantenimiento,descripcionFalla,idEstadoMantenimiento,idUsuarios,idOrdenServicio,IdEquipo) values(@fechaMantenimientoModel,@descripcionFalla,@idEstadoMantenimiento,@idUsuarios,@idOrdenServicio,@IdEquipo)", cn);
                cm.Parameters.AddWithValue("@fechaMantenimientoModel", MantenimientoModel.fechaMantenimiento);
                cm.Parameters.AddWithValue("@descripcionFalla", MantenimientoModel.descripcionFalla);
                cm.Parameters.AddWithValue("@idEstadoMantenimiento", MantenimientoModel.idEstadoMantenimiento);
                cm.Parameters.AddWithValue("@idUsuarios", MantenimientoModel.idUsuarios);
                cm.Parameters.AddWithValue("@idOrdenServicio", MantenimientoModel.idOrdenServicio);
                cm.Parameters.AddWithValue("@IdEquipo", MantenimientoModel.IdEquipo); 
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar MantenimientoModel 
        public string actualizarMantenimientoModel(MantenimientoModel MantenimientoModel)
        {
            
            int Aplicar = 0, NoAplicar = 0;
            if (MantenimientoModel.estadoNoAplicarCorreccion)
            {
                NoAplicar = 1;
            }
            if (MantenimientoModel.estadoAplicarCorreccion)
            {
                Aplicar = 1;
            }
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                string Query = $@"UPDATE Mantenimiento  SET
                fechaMantenimiento='{MantenimientoModel.fechaMantenimiento.ToString("yyyy-MM-dd hh:mm:ss")}',
                descripcionFalla='{MantenimientoModel.descripcionFalla}',
                solucion='{MantenimientoModel.solucion}',
                idEstadoMantenimiento={MantenimientoModel.idEstadoMantenimiento},
                idUsuarios={MantenimientoModel.idUsuarios},
                idOrdenServicio={MantenimientoModel.idOrdenServicio},
                estadoAplicarCorreccion={Aplicar},
                estadoNoAplicarCorreccion={NoAplicar},
                precioReferencial ={MantenimientoModel.precioReferencial},";
                DateTime MinimunDate = Convert.ToDateTime("01/01/2000");
                if (MantenimientoModel.fechaEntregaEquipo > MinimunDate)
                {
                    Query += $" fechaEntregaEquipo = '{MantenimientoModel.fechaEntregaEquipo.ToString("yyyy-MM-dd")}'";
                }
                Query += $" WHERE Id = {MantenimientoModel.Id}";
                adapter.UpdateCommand = new SqlCommand(Query, cn);

                cn.Open();
                adapter.UpdateCommand.ExecuteNonQuery();
               

                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
        
            }
            if (MantenimientoModel.reservas == null)
            {
                return Error;
            }
            selectContadorDeMantenimientosRealizados(MantenimientoModel.idOrdenServicio);
            deleteReserva(MantenimientoModel.Id);

            if (MantenimientoModel.reservas.Count > 0)
            {
                foreach (var reserva in MantenimientoModel.reservas)
                {
                    reserva.IdMantenimiento = MantenimientoModel.Id;
                    insertarReservas(reserva);
                }

            }

        }

        //eliminar MantenimientoModels
        public string deleteMantenimientoModels(int idMantenimientoModels)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Mantenimiento WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idMantenimientoModels);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        
        //get EstadoMantenimiento id
        public EstadoMantenimiento selectEstadoMantenimientoPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            EstadoMantenimiento EstadoMantenimiento = new EstadoMantenimiento();
            try
            {
                cm = new SqlCommand($"Select * from EstadoMantenimiento Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    EstadoMantenimiento.Id = (int)dt.Rows[0]["Id"];
                    EstadoMantenimiento.descripcion = dt.Rows[0]["descripcion"].ToString();
                   
                }
                return EstadoMantenimiento;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return EstadoMantenimiento;
            }
            finally
            {
                cn.Close();
            }
        }
        // get MantenimientoModel
        public List<EstadoMantenimiento> selectTodosLosEstadosMantenimientoModels()
        {
            cn.ConnectionString = myConnection();
            List<EstadoMantenimiento> estadosMantenimientoModels = new List<EstadoMantenimiento>();

            try
            {
                cm = new SqlCommand($"Select * from EstadoMantenimiento ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        EstadoMantenimiento EstadoMantenimiento = new EstadoMantenimiento();
                        EstadoMantenimiento.Id = (int)dt.Rows[0]["Id"];
                        EstadoMantenimiento.descripcion = dt.Rows[0]["descripcion"].ToString();
                       
                        estadosMantenimientoModels.Add(EstadoMantenimiento);
                    }

                }
                return estadosMantenimientoModels;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return estadosMantenimientoModels;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar EstadosMantenimientoModels 
        public string insertEstadosMantenimientoModels(EstadoMantenimiento EstadoMantenimiento)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into EstadoMantenimiento (descripcion) values (@descripcion)", cn);
                cm.Parameters.AddWithValue("@descripcionFalla", EstadoMantenimiento.descripcion);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar EstadoMantenimiento 
        public string actualizarEstadoMantenimiento(EstadoMantenimiento EstadoMantenimiento)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE EstadoMantenimiento SET descripcion=@descripcion WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", EstadoMantenimiento.Id);
                cm.Parameters.AddWithValue("@descripcion", EstadoMantenimiento.descripcion);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //eliminar EstadoMantenimientos
        public string deleteEstadoMantenimientos(int idEstadosMantenimientoModels)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM EstadoMantenimiento WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idEstadosMantenimientoModels);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //get accesorios id
        public Accesorios selectAccesoriosPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Accesorios accesorios = new Accesorios();
            try
            {
                cm = new SqlCommand($"Select * from Accesorios Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    accesorios.Id = (int)dt.Rows[0]["Id"];
                    accesorios.accesoriosEquipo = dt.Rows[0]["accesoriosEquipo"].ToString();
                    accesorios.idEquipo = (int)dt.Rows[0]["idEquipo"];
                     
                }
                return accesorios;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return accesorios;
            }
            finally
            {
                cn.Close();
            }
        }
        // get Accesorios
        public List<Accesorios> selectTodosLosAccesorios()
        {
            cn.ConnectionString = myConnection();
            List<Accesorios> accesorios = new List<Accesorios>();

            try
            {
                cm = new SqlCommand($"Select * from Accesorios ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Accesorios accesorio = new Accesorios();
                        accesorio.Id = (int)dt.Rows[0]["Id"];
                        accesorio.accesoriosEquipo = dt.Rows[0]["accesoriosEquipo"].ToString();
                        accesorio.idEquipo =(int) dt.Rows[0]["idEquipo"];
                        
                        accesorios.Add(accesorio);
                    }

                }
                return accesorios;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return accesorios;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectTodosLosAccesoriosData()
        {
            cn.ConnectionString = myConnection();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"Select * from Accesorios join Equipo on Equipo.Id = accesorios.IdEquipo");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
              
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Equipos 
        public int insertAccesorios(Accesorios accesorios)
        {
            cn.ConnectionString = myConnection();
            int Error =0;   
                
            try
            {
                cm = new SqlCommand("Insert into Accesorios (accesoriosEquipo,idEquipo) values (@accesoriosEquipo,@idEquipo)", cn);
                cm.Parameters.AddWithValue("@accesoriosEquipo", accesorios.accesoriosEquipo);
                cm.Parameters.AddWithValue("@idEquipo", accesorios.idEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar Accesorios 
        public string actualizarAccesorios(Accesorios accesorios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Accesorios SET accesoriosEquipo=@accesoriosEquipo,idEquipo=@idEquipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", accesorios.Id);
                cm.Parameters.AddWithValue("@accesoriosEquipo",accesorios.accesoriosEquipo);
                cm.Parameters.AddWithValue("@idEquipo", accesorios.idEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //eliminar Accesorios
        public string deleteAccesorios(int idAccesorios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM equipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idAccesorios);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //get equipo id
        public Equipo selectEquipoPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Equipo equipo = new Equipo();
            try
            {
                cm = new SqlCommand($"Select * from Equipo Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    equipo.Id = (int)dt.Rows[0]["Id"];
                    equipo.descripcionEquipo = dt.Rows[0]["descirpcionEquipo"].ToString();
                    equipo.codigo = dt.Rows[0]["codigo"].ToString();
                    equipo.series = dt.Rows[0]["series"].ToString();
                    equipo.IdMarcaEquipo = (int)dt.Rows[0]["IdMarcaEquipo"];
                    equipo.IdtipoEquipo = (int)dt.Rows[0]["IdTipoEquipo"];
                }
                return equipo;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return equipo;
            }
            finally
            {
                cn.Close();
            }
        }
        // get Equipo
        public List<Equipo> selectTodosLosEquipos()
        {
            cn.ConnectionString = myConnection();
            List<Equipo> equipos = new List<Equipo>();

            try
            {
                cm = new SqlCommand($"Select * from Equipo ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        int idTipo, idMarca;
                        int.TryParse(r["IdtipoEquipo"].ToString(), out idTipo);
                        int.TryParse(r["Idmarca"].ToString(), out idMarca);
                        Equipo equipo = new Equipo();
                        equipo.Id = (int)r["Id"];
                        equipo.descripcionEquipo = r["descirpcionEquipo"].ToString();
                        equipo.IdtipoEquipo = idTipo;
                        equipo.IdMarcaEquipo = idMarca;
                        equipo.codigo = r["codigo"].ToString();
                        equipo.series = r["series"].ToString();
                        equipos.Add(equipo);
                        equipos.Add(equipo);
                    }

                }
                return equipos;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return equipos;
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Equipo> selectTodosLosEquiposPorCliente(int idCliente)
        {
            cn.ConnectionString = myConnection();
            List<Equipo> equipos = new List<Equipo>();

            try
            {
                cm = new SqlCommand($"Select * from Equipo Where IdCliente = {idCliente}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        int idTipo, idMarca;
                        int.TryParse(r["IdtipoEquipo"].ToString(), out idTipo);
                        int.TryParse(r["IdmarcaEquipo"].ToString(), out idMarca);
                        Equipo equipo = new Equipo();
                        equipo.Id = (int)r["Id"];
                        equipo.descripcionEquipo = r["descirpcionEquipo"].ToString();
                        equipo.IdtipoEquipo = idTipo;
                        equipo.IdMarcaEquipo = idMarca;
                        equipo.codigo = r["codigo"].ToString();
                        equipo.series = r["series"].ToString();
                        equipos.Add(equipo);
                    }

                }
                return equipos;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return equipos;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Equipos 
        public int insertEquipos(Equipo equipo)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand("Insert into Equipo (descirpcionEquipo,codigo,series,idCliente,IdtipoEquipo,IdMarcaEquipo) values (@descripcionEquipo,@codigo,@series,@idCliente,@IdtipoEquipo,@IdMarcaEquipo) SET @ID = SCOPE_IDENTITY();", cn);
                cm.Parameters.AddWithValue("@descripcionEquipo", equipo.descripcionEquipo);
                cm.Parameters.AddWithValue("@codigo", equipo.codigo);
                cm.Parameters.AddWithValue("@series", equipo.series);
                cm.Parameters.AddWithValue("@idcliente", equipo.idCliente);
                cm.Parameters.AddWithValue("@IdtipoEquipo", equipo.IdtipoEquipo);
                cm.Parameters.AddWithValue("@IdMarcaEquipo", equipo.IdMarcaEquipo);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(), out Error);
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar Equipo 
        public string actualizarEquipos(Equipo equipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand(@"UPDATE 
                Equipo 
                SET 
                descripcionFallo=@descripcionFallo,
                descripcionEquipo=@descripcionEquipo,
                codigo=@codigo,
                series=@series, 
                IdtipoEquipo=@IdtipoEquipo,
                IdMarca=@IdMarcaEquipo 
                WHERE Id = @Id", cn);
                cm.Parameters.AddWithValue("@Id", equipo.Id);
                cm.Parameters.AddWithValue("@descripcionEquipo", equipo.descripcionEquipo);
                cm.Parameters.AddWithValue("@codigo", equipo.codigo);
                cm.Parameters.AddWithValue("@series", equipo.series);
                cm.Parameters.AddWithValue("@IdtipoEquipo", equipo.IdtipoEquipo);
                cm.Parameters.AddWithValue("@IdMarcaEquipo", equipo.IdMarcaEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //eliminar Equipo
        public string deleteEquipo(int idEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM equipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //get reserva id
        public Reserva selectReservaPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Reserva reserva = new Reserva();
            try
            {
                cm = new SqlCommand($"Select * from Reserva Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    reserva.Id = (int)dt.Rows[0]["Id"];
                    reserva.estadoReserva = dt.Rows[0]["estadoReserva"].ToString();
                    reserva.idItem =(int) dt.Rows[0]["IdItem"];
                    }
                return reserva;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return reserva;
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Reserva> selectReservaPorMantenimiento(int IdMantenimiento)
        {
            cn.ConnectionString = myConnection();
            List<Reserva> reservas = new List<Reserva>();
            Reserva reserva = new Reserva();
            try
            {
                cm = new SqlCommand($"Select * from Reserva Where IdMantenimiento = {IdMantenimiento}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                da.Dispose();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        reserva.Id = (int)r["Id"];
                        reserva.estadoReserva = r["estadoReserva"].ToString();
                        reserva.idItem = (int)r["IdItem"];
                        reserva.Cantidad = (int)r["cantidad"];
                        reserva.precioFinal = (decimal)r["precioFinal"];
                        reserva.precioUnitario = (decimal)r["precioUnitario"];
                        reserva.items = selectItemPorId(reserva.idItem);
                        reservas.Add(reserva);
                    }
                   
                }
                return reservas;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return reservas;
            }
            finally
            {

            }
        }
        // get Reserva
        public List<Reserva> selectTodosLasReservas()
        {
            cn.ConnectionString = myConnection();
            List<Reserva> reservas = new List<Reserva>();

            try
            {
                cm = new SqlCommand($"Select * from Reserva ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Reserva reserva = new Reserva();
                        reserva.Id = (int)dt.Rows[0]["Id"];
                        reserva.estadoReserva = dt.Rows[0]["estadoReserva"].ToString();
                        reserva.idItem =(int)dt.Rows[0]["idItem"];
                        reservas.Add(reserva);
                    }

                }
                return reservas;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return reservas;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Reservas 
        public string insertReservas(Reserva reserva)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
        //         public int IdMantenimiento { get; set; }
        //public string estadoReserva { get; set; }
        //public int idItem { get; set; }
        //public Items items { get; set; }
        //public int Cantidad { get; set; }
        //public decimal precioReferencial { get; set; }
        //public decimal precioFinal { get; set; }
        //public decimal precioUnitario { get; set; }
        cm = new SqlCommand(@"Insert into Reserva (IdMantenimiento,estadoReserva,idItem,Cantidad,precioUnitario,precioFinal) 
                        values (@IdMantenimiento,@estadoReserva,@idItem,@Cantidad,@precioUnitario,@precioFinal)", cn);
                cm.Parameters.AddWithValue("@estadoReserva", reserva.estadoReserva);
                cm.Parameters.AddWithValue("@idItem", reserva.idItem);
                cm.Parameters.AddWithValue("@IdMantenimiento", reserva.IdMantenimiento);
                cm.Parameters.AddWithValue("@Cantidad", reserva.Cantidad);
                cm.Parameters.AddWithValue("@precioUnitario", reserva.precioUnitario);
                cm.Parameters.AddWithValue("@precioFinal", reserva.precioFinal);
                cn.Open();
                adapter.InsertCommand = cm;
                adapter.InsertCommand.ExecuteNonQuery();
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar Reserva 
        public string actualizarReserva(Reserva reserva)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Reserva SET estadoReserva=@estadoReserva,idItem=@idItem WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", reserva.Id);
                cm.Parameters.AddWithValue("@estadoReserva", reserva.estadoReserva);
                cm.Parameters.AddWithValue("@idItem", reserva.idItem);
                cn.Open();
                adapter.DeleteCommand = cm;
                adapter.DeleteCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }

        //eliminar Reserva
        public string deleteReserva(int IdMantenimiento)
        {
            List<Reserva> reservas = new List<Reserva>();
            reservas = selectReservaPorMantenimiento(IdMantenimiento);
            foreach(var reserva in reservas)
            {
                actualizarvalorStock(reserva.Cantidad, reserva.items.Id);
            }
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Reserva WHERE IdMantenimiento = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", IdMantenimiento);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //get Compras Id
        public Compras selectComprasPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Compras compras = new Compras();
            try
            {
                cm = new SqlCommand($"Select * from Compras Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    compras.Id = (int)dt.Rows[0]["Id"];
                    compras.tipoCompra = dt.Rows[0]["tipoCompra"].ToString();
                    compras.codigoCompra = dt.Rows[0]["codigoCompra"].ToString();
                    compras.idProveedor = (int)dt.Rows[0]["IdProveedor"];
                    compras.idUsuario = (int)dt.Rows[0]["IdUsuario"];
                    compras.formaPago = dt.Rows[0]["formaPago"].ToString();
                    compras.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"].ToString());
                    compras.Iva = Convert.ToDecimal(dt.Rows[0]["Iva"].ToString());
                    compras.total = Convert.ToDecimal(dt.Rows[0]["total"].ToString());

                }
                return compras;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return compras;
            }
            finally
            {
                cn.Close();
            }
        }
        // get compras
        public List<Compras> selectTodosLasCompras()
        {
            cn.ConnectionString = myConnection();
            List<Compras> compras = new List<Compras>();

            try
            {
                cm = new SqlCommand($"Select * from Compras");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Compras compra = new Compras();
                        compra.Id = (int)dt.Rows[0]["Id"];
                        compra.tipoCompra = dt.Rows[0]["tipoCompra"].ToString();
                        compra.codigoCompra = dt.Rows[0]["codigoCompra"].ToString();
                        compra.idProveedor = (int)dt.Rows[0]["idProveedor"];
                        compra.fecha = Convert.ToDateTime(dt.Rows[0]["fecha"].ToString());
                        compra.formaPago = dt.Rows[0]["formaPago"].ToString();
                        compra.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"].ToString());
                        compra.Iva = Convert.ToDecimal(dt.Rows[0]["Iva"].ToString());
                        compra.total = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
                        compras.Add(compra);
                    }

                }
                return compras;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return compras;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectComprasDataPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            DataSet dt = new DataSet();
            try
            {
                cm = new SqlCommand($"Select * from Compras where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }

        //insertar compras
        public int insertCompras(Compras compras)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand(@"Insert into Compras 
                (tipoCompra,codigoCompra,idProveedor,fecha,Iva,IvaPrecio,subtotal,total,idUsuario) 
                values
                (@tipoCompra,@codigoCompra,@idProveedor,@fecha,@Iva,@IvaPrecio,@subtotal,@total,@idUsuario) SET @ID = SCOPE_IDENTITY();", cn);
                cm.Parameters.AddWithValue("@tipoCompra", compras.tipoCompra);
                cm.Parameters.AddWithValue("@idUsuario", compras.idUsuario);
                cm.Parameters.AddWithValue("@codigoCompra", compras.codigoCompra);
                cm.Parameters.AddWithValue("@idProveedor", compras.idProveedor);
                cm.Parameters.AddWithValue("@fecha", DateTime.Now);
                cm.Parameters.AddWithValue("@iva", compras.Iva);
                cm.Parameters.AddWithValue("@IvaPrecio", compras.IvaPrecio);
                cm.Parameters.AddWithValue("@subtotal", compras.subtotal);
                cm.Parameters.AddWithValue("@total", compras.total);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(), out Error);
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        public int insertFacturaMantenimiento(Factura factura)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand(@"INSERT INTO [dbo].[factura]
                   ([clienteId]
                   ,[usuario]
                   ,[fecha_venta]
                   ,[total]
                   ,[iva]
                   ,[subtotal]
                   ,[descuento]
                   ,[IdOrden]
                   ,[TipoFactura])
                     VALUES
                    (@clienteId,
                    @usuario,
                    GETDATE(),
                    @total,
                    @iva,
                    @subtotal,
                    @descuento,
                    @IdOrden,
                    @TipoFactura)
                    SET @ID = SCOPE_IDENTITY();", cn);
                cm.Parameters.AddWithValue("@clienteId", factura.clienteId);
                cm.Parameters.AddWithValue("@usuario", factura.usuario);
                cm.Parameters.AddWithValue("@total", factura.total);
                cm.Parameters.AddWithValue("@Date", DateTime.Now);
                cm.Parameters.AddWithValue("@iva", factura.iva);
                cm.Parameters.AddWithValue("@subtotal", factura.subtotal);
                cm.Parameters.AddWithValue("@descuento", factura.descuento);
                cm.Parameters.AddWithValue("@IdOrden", factura.idORden);
                cm.Parameters.AddWithValue("@TipoFactura", 2);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(), out Error);
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        public int insertDetalleVenta(DetallesVenta detalles)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand(@"
               INSERT INTO [dbo].[DetallesVentas]
                (
                [IdFactura]
                ,[IdItem]
                ,[precioVenta]
                ,[cantidad]
                ,[montoTotal]
                ,[fechaRegistro])
                VALUES
                (@idCompra
                ,@IdItem
                ,@PrecioCompra
                ,@Cantidad
                ,@Total
                ,GETDATE());", cn);
                cm.Parameters.AddWithValue("@idCompra", detalles.IdFactura);
                cm.Parameters.AddWithValue("@IdItem", detalles.IdItem);
                cm.Parameters.AddWithValue("@PrecioCompra", detalles.precioVenta);
                cm.Parameters.AddWithValue("@Cantidad", detalles.cantidad);
                cm.Parameters.AddWithValue("@Total", detalles.montoTotal);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        public int insertDetallesCompras(Detalle_Compra compras)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand(@"
                INSERT INTO [dbo].[Detalle_Compra]
                ([idCompra]
               ,[IdItems]
               ,[PrecioCompra]
               ,[Cantidad]
               ,[Total]
               ,[FechaRegistro])
                 VALUES
                (@idCompra
                ,@IdItem
                ,@PrecioCompra
                ,@Cantidad
                ,@Total
                ,@FechaRegistro);", cn);
                cm.Parameters.AddWithValue("@idCompra", compras.IdCompra);
                cm.Parameters.AddWithValue("@IdItem", compras.IdItem);
                cm.Parameters.AddWithValue("@PrecioCompra", compras.precioCompra);
                cm.Parameters.AddWithValue("@Cantidad", compras.cantidad);
                cm.Parameters.AddWithValue("@Total", compras.montoTotal);
                cm.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar compras
        public string actualizarCompras(Compras compras)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Compras SET tipoCompra=@tipoCompra,codigoCompra=@codigoCompra,idProveedor=@idProveedor,fecha=@fecha,idProducto=@idProducto,stock=@stock,formaPago=@formaPago,subtotal=@subtotal,Iva=@Iva ,total=@total WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", compras.Id);
                cm.Parameters.AddWithValue("@tipoCompra", compras.tipoCompra);
                cm.Parameters.AddWithValue("@codigoCompra", compras.codigoCompra);
                cm.Parameters.AddWithValue("@idProveedor", compras.idProveedor);
                cm.Parameters.AddWithValue("@fecha", compras.fecha);
                cm.Parameters.AddWithValue("@formaPago", compras.formaPago);
                cm.Parameters.AddWithValue("@subtotal", compras.subtotal);
                cm.Parameters.AddWithValue("@Iva", compras.Iva);
                cm.Parameters.AddWithValue("@total", compras.total);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Compras
        public string deleteCompras(int idCompras)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Compras WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idCompras);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }


        public string restarValorStock(int qty, int idItem)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {

                cm = new SqlCommand($"Update items set stock = stock - {qty} Where id = {idItem}", cn);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        public string restarValorStock(int qty, string pcode)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {

                cm = new SqlCommand($"Update items set stock = stock - {qty} Where codigoBarras = {pcode}", cn);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        public string actualizarvalorStock(int qty, int idItem)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {

                cm = new SqlCommand($"Update items set stock = stock + {qty} Where id = {idItem}", cn);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        
        public DataSet generarInformeDaño ()
        {
            cn.ConnectionString=myConnection();
            cm = new SqlCommand("SELECT Clientes.Id, Clientes.nombre, Clientes.ciRuc, Clientes.celular, Equipo.idCliente, Equipo.descirpcionEquipo, Equipo.codigo, estadoMantenimiento.descripcion, Mantenimiento.solucion, Mantenimiento.estadoAplicarCorreccion, Mantenimiento.estadoNoAplicarCorreccion, Mantenimiento.precioReferencial, Mantenimiento.fechaMantenimiento, Mantenimiento.fechaEntregaEquipo Clientes INNER JOIN Equipo ON Clientes.Id = Equipo.idCliente INNER JOIN estadoMantenimiento ON Equipo.Id = estadoMantenimiento.Id INNER JOIN Mantenimiento ON Equipo.Id = Mantenimiento.idEquipo INNER JOIN ordenServicio ON Mantenimiento.idOrdenServicio = ordenServicio.Id", cn);
         SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataSet table = new DataSet();
            cn.Open();
            adapter.Fill(table);
            adapter.Dispose();
            cn.Close();
            return table;
        }
        public DataSet generarInformeOrdenMatenimiento(int IdOrden)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($@"SELECT [IdOrden]
              ,[IdMantenimiento]
              ,[codigo]
              ,[descirpcionEquipo]
              ,[accesoriosEquipo]
                FROM [dbo].[OrdenesDetallados] Where IdORden = {IdOrden}", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataSet table = new DataSet();
            cn.Open();
            adapter.Fill(table);
            adapter.Dispose();
            cn.Close();
            return table;
        }
        public DataSet generarReporte(int IdCompra) 
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($"SELECT [items].[nombre],[PrecioCompra],[Cantidad],[Total] FROM [dbo].[Detalle_Compra] inner join items on Items.Id =  [Detalle_Compra].IdItems where [idCompra] = {IdCompra}", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataSet table = new DataSet();
            cn.Open();
            adapter.Fill(table);
            adapter.Dispose();
            cn.Close();
            return table;
        }
        public DataSet generarReporteFactura(int idFactura)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($@"SELECT items.nombre,precioVenta as PrecioCompra,cantidad,DetallesVentas.montoTotal as Total
            FROM DetallesVentas 
            inner join items on Items.Id =  DetallesVentas.IdItem
            where IdFactura = {idFactura}", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataSet table = new DataSet();
            cn.Open();
            adapter.Fill(table);
            adapter.Dispose();
            cn.Close();
            return table;
        }
        public string actualizarvalorStock(int qty, string pcode)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {

                cm = new SqlCommand($"Update items set stock = stock + {qty} Where codigoBarras = {pcode}", cn);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        public DataTable SelectTodosLosProveedores()
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("SELECT * FROM Proveedores", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            cn.Open();
            adapter.Fill(table);
            adapter.Dispose();
            cn.Close();
            return table;
        }
        public DataTable LoadItemsForSuppliers(string txtSearch)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($"SELECT p.id, p.Nombre, p.codigoBarras, p.descripcion, b.marca, c.Categoria, p.precioA, p.stock,negativo FROM items AS p left JOIN Marcas AS b ON b.Id = p.bid left JOIN Categorias AS c on c.Id = p.cid WHERE CONCAT(p.Nombre,p.codigoBarras, b.marca, c.Categoria) LIKE '%{txtSearch}%' and (combo = 0)", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public DataTable LoadItemsForCashier(string txtSearch)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($"SELECT p.id, p.Nombre, p.codigoBarras, p.descripcion, b.marca, c.Categoria, p.precioA, p.stock,negativo FROM items AS p left JOIN Marcas AS b ON b.Id = p.bid left JOIN Categorias AS c on c.Id = p.cid WHERE CONCAT(p.Nombre,p.codigoBarras, b.marca, c.Categoria) LIKE '%{txtSearch}%' and (Stock > 0 or Negativo = 1)", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }


        public static void CrearEvento(string cmd)
        {
            string MyLogName = DateTime.Now.ToString("ddMMyyyHHmmssfff");
            string sourceName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string subPath = @"Errores";
            bool exists = System.IO.Directory.Exists(subPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }

            if (!exists)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(subPath, sourceName)))
                {
                    outputFile.WriteLine(cmd, Environment.NewLine);
                }
            }
            else
            {
                using (StreamWriter outputFile = File.AppendText(Path.Combine(subPath, sourceName)))
                {
                    outputFile.WriteLine(cmd, Environment.NewLine);
                }
            }
        }
        public Usuarios loginAction(string account, string password)
        {
            Usuarios usuario = new Usuarios();
            cn.ConnectionString = myConnection();

            string _username = "", _name = "", _role = "";
            try
            {
                bool found;
                cn.Open();
                cm = new SqlCommand("Select * From Usuarios Where username = @username and contraseña = @contraseña", cn);
                cm.Parameters.AddWithValue("@username", account);
                cm.Parameters.AddWithValue("@contraseña", password);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    usuario.Id = (int)dr["Id"];
                    usuario.username = dr["username"].ToString();
                    usuario.nombre = dr["nombre"].ToString();
                    usuario.role = dr["role"].ToString();
                    usuario.isactive = bool.Parse(dr["isactive"].ToString());

                }
                else
                {
                    found = false;
                }
                dr.Close();
                cn.Close();

                return usuario;

            }

            catch (SqlException ex)
            {
                CrearEvento(ex.ToString());
                return usuario;
                cn.Close();

            }

        }
        public async Task AddStockIn(Enstock stock)
        {
            try
            {
                await cn.OpenAsync();
                cm = new SqlCommand("INSERT INTO Enstock (refno, pcode, sdate, stockinby, supplierid)VALUES (@refno, @pcode, @sdate, @stockinby, @supplierid)", cn);
                cm.Parameters.AddWithValue("@refno", stock.refno);
                cm.Parameters.AddWithValue("@pcode", stock.pcode);
                cm.Parameters.AddWithValue("@sdate", stock.sdate);
                cm.Parameters.AddWithValue("@stockinby", stock.stockinby);
                cm.Parameters.AddWithValue("@supplierid", stock.supplierId);
                await cm.ExecuteNonQueryAsync();
                cn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable getTable(string qury)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand(qury, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public string ExecuteQuery(String sql)
        {
            string Error = String.Empty;
            try
            {
                cn.ConnectionString = myConnection();
                cn.Open();
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();

                Error = "";
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();

            }

        }

        public String getPassword(string username)
        {
            string password = "";
            cn.ConnectionString = myConnection();
            cn.Open();
            cm = new SqlCommand("SELECT contraseña FROM Usuarios WHERE username = '" + username + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["contraseña"].ToString();
            }
            dr.Close();
            cn.Close();
            return password;
        }

        public double ExtractData(string sql)
        {

            cn = new SqlConnection();
            cn.ConnectionString = myConnection();
            cn.Open();
            cm = new SqlCommand(sql, cn);
            double data = double.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return data;

        }
        public void beginTransaction()
        {

            cn = new SqlConnection();
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("BEGIN TRANSACTION", cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void commitTransaction()
        {

            cn = new SqlConnection();
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("COMMIT TRANSACTION;", cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void rollBackTransaction()
        {

            cn = new SqlConnection();
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("ROLLBACK;", cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }



        /// <summary>
        /// Actualizar Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        ///   CRUD PARA CLASE ITEM
        ///------ SECCION PARA SELECT ITEMS --------------
        ///
        public Items selectItemPorId(int Id)
        {
            Items item = new Items();
            try
            {
                cn.ConnectionString = myConnection();
                cm = new SqlCommand($"Select * from Items Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    item.Id = (int)dt.Rows[0]["Id"];
                    item.nombre = dt.Rows[0]["nombre"].ToString();
                    item.codigoBarras = dt.Rows[0]["codigoBarras"].ToString();
                    item.precioA = (decimal)dt.Rows[0]["precioA"];
                    item.precioB = (decimal)dt.Rows[0]["precioB"];
                    item.precioC = (decimal)dt.Rows[0]["precioC"];
                    item.precioD = (decimal)dt.Rows[0]["precioD"];
                    item.descripcion = dt.Rows[0]["descripcion"].ToString();
                    item.stock = (int)dt.Rows[0]["stock"];
                    item.stockMin = (int)dt.Rows[0]["stockMin"];
                    item.unidad = (int)dt.Rows[0]["unidad"];
                    item.bId = (int)dt.Rows[0]["bId"];
                    item.cId = (int)dt.Rows[0]["cId"];
                    item.gId = (int)dt.Rows[0]["gId"];
                    item.mId = (int)dt.Rows[0]["mId"];
                    item.servicio = (bool)dt.Rows[0]["servicio"];
                    item.aplicaSeries = (bool)dt.Rows[0]["aplicaSeries"];
                    item.negativo = (bool)dt.Rows[0]["negativo"];
                    item.hascombo = (bool)dt.Rows[0]["combo"];
                    item.ice = (decimal)dt.Rows[0]["ice"];
                 
                    item.HasIva = (bool)dt.Rows[0]["HasIva"];
                    item.iva = (decimal)dt.Rows[0]["iva"];
                    if (File.Exists(dt.Rows[0]["imagen"].ToString()))
                    {
                        item.imagen = (Bitmap)Image.FromFile(dt.Rows[0]["imagen"].ToString());
                    }
                    else
                    {
                        item.imagen = (Bitmap)Image.FromFile(@"Image\cancel_30px.png");
                    }
                    
                    item.descripcion = dt.Rows[0]["imagenUrl"].ToString();
                    item.valorIce = (decimal)dt.Rows[0]["valorIce"];
                    item.montoTotal = (decimal)dt.Rows[0]["montoTotal"];
                }
                return item;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return item;
            }
            finally
            {
                cn.Close();
            }
        }
        public string selectItemImagenUrl(int Id)
        {
            string imagen = string.Empty;
            try
            {
                cn.ConnectionString = myConnection();
                cm = new SqlCommand($"Select imagen from Items Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                   
                    if (File.Exists(dt.Rows[0]["imagen"].ToString()))
                    {
                        imagen = dt.Rows[0]["imagen"].ToString();
                    }
                    else
                    {
                        imagen = @"Image\cancel_30px.png";
                    }

                
                }
                return imagen;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return imagen;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable selectPendientesEnStock(string txtRefNo)
        {
            cn.ConnectionString = myConnection();
            List<Enstock> enstocks = new List<Enstock>();
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"SELECT * FROM vwEnStock WHERE refno = '{txtRefNo}' AND status = 'Pendiente'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Items> selectTodosLosItems()
        {
            cn.ConnectionString = myConnection();
            List<Items> items = new List<Items>();
            decimal precioA = 0, precioB = 0, precioC = 0, precioD = 0, peso = 0, comision = 0, descMax = 0, costo = 0, ice = 0, valorIce = 0, iva = 0, montoTotal = 0;
            int Id = 0, unidadCaja = 0, stockMax = 0, stockMin = 0, stock = 0, bId = 0, cId = 0, gId = 0, mId = 0, unidad = 0;

            try
            {
                cm = new SqlCommand($"Select * from Items ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Items item = new Items();
                        int.TryParse(r["Id"].ToString(), out Id);
                        item.Id = Id;
                        item.nombre = r["nombre"].ToString();
                        item.codigoBarras = r["codigoBarras"].ToString();
                        decimal.TryParse(r["precioA"].ToString(), out precioA);
                        item.precioA = precioA;
                        decimal.TryParse(r["precioB"].ToString(), out precioB);
                        item.precioB = precioB;
                        decimal.TryParse(r["precioC"].ToString(), out precioC);
                        item.precioC = precioC;
                        decimal.TryParse(r["precioD"].ToString(), out precioD);
                        item.precioD = precioD;
                        item.descripcion = r["descripcion"].ToString();
                        int.TryParse(r["stockMin"].ToString(), out stockMin);
                        item.stockMin = stockMin;

                        int.TryParse(r["stock"].ToString(), out stock);
                        item.stock = stock;
                        int.TryParse(r["unidad"].ToString(), out unidad);
                        item.unidad = (int)r["unidad"];
                        int.TryParse(r["bId"].ToString(), out bId);
                        item.bId = (int)r["bId"];
                        int.TryParse(r["cId"].ToString(), out cId);
                        item.cId = (int)r["cId"];
                        int.TryParse(r["gId"].ToString(), out gId);
                        item.gId = (int)r["gId"];
                        int.TryParse(r["mId"].ToString(), out mId);
                        item.mId = mId;
                        item.servicio = (bool)r["servicio"];
                        item.aplicaSeries = (bool)r["aplicaSeries"];
                        item.negativo = (bool)r["negativo"];
                        item.hascombo = (bool)r["combo"];
                        decimal.TryParse(r["ice"].ToString(), out ice);
                        item.ice = ice;
                        decimal.TryParse(r["valorIce"].ToString(), out valorIce);
                        item.valorIce = valorIce;
                        item.HasIva = bool.Parse(r["HasIva"].ToString());
                        decimal.TryParse(r["iva"].ToString(), out iva);
                        item.iva = iva;
                        if (File.Exists(r["imagen"].ToString()))
                        {
                            item.imagen = (Bitmap)Image.FromFile(r["imagen"].ToString());
                        }
                        else
                        {
                            item.imagen = (Bitmap)Image.FromFile($@"{path}\Image\cancel_30px.png");
                        }
                        item.descripcion = r["imagenUrl"].ToString();
                        decimal.TryParse(r["montoTotal"].ToString(), out montoTotal);
                        item.montoTotal = montoTotal;
                        items.Add(item);
                    }

                }
                return items;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return items;
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Items> selectTodosLosItemsSinCombo()
        {
            cn.ConnectionString = myConnection();
            List<Items> items = new List<Items>();
            decimal precioA = 0, precioB = 0, precioC = 0, precioD = 0, peso = 0, comision = 0, descMax = 0, costo = 0, ice = 0, valorIce = 0, iva = 0, montoTotal = 0;
            int Id = 0, unidadCaja = 0, stockMax = 0, stockMin = 0, bId = 0, cId = 0, gId = 0, mId = 0, unidad = 0;

            try
            {
                cm = new SqlCommand($"Select * from Items where combo = 0 ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Items item = new Items();
                        int.TryParse(r["Id"].ToString(), out Id);
                        item.Id = Id;
                        item.nombre = r["nombre"].ToString();
                        item.codigoBarras = r["codigoBarras"].ToString();
                        decimal.TryParse(r["precioA"].ToString(), out precioA);
                        item.precioA = precioA;
                        decimal.TryParse(r["precioB"].ToString(), out precioB);
                        item.precioB = precioB;
                        decimal.TryParse(r["precioC"].ToString(), out precioC);
                        item.precioC = precioC;
                        decimal.TryParse(r["precioD"].ToString(), out precioD);
                        item.precioD = precioD;
                        item.descripcion = r["descripcion"].ToString();
                        int.TryParse(r["stockMin"].ToString(), out stockMin);
                        item.stockMin = stockMin;
                        int.TryParse(r["unidad"].ToString(), out unidad);
                        item.unidad = (int)r["unidad"];
                        int.TryParse(r["bId"].ToString(), out bId);
                        item.bId = (int)r["bId"];
                        int.TryParse(r["cId"].ToString(), out cId);
                        item.cId = (int)r["cId"];
                        int.TryParse(r["gId"].ToString(), out gId);
                        item.gId = (int)r["gId"];
                        int.TryParse(r["mId"].ToString(), out mId);
                        item.mId = mId;
                        item.servicio = (bool)r["servicio"];
                        item.aplicaSeries = (bool)r["aplicaSeries"];
                        item.negativo = (bool)r["negativo"];
                        item.hascombo = (bool)r["combo"];
                        decimal.TryParse(r["ice"].ToString(), out ice);
                        item.ice = ice;
                        decimal.TryParse(r["valorIce"].ToString(), out valorIce);
                        item.valorIce = valorIce;
                        item.HasIva = bool.Parse(r["HasIva"].ToString());
                        decimal.TryParse(r["iva"].ToString(), out iva);
                        item.iva = iva;
                        if (File.Exists(r["imagen"].ToString()))
                        {
                            item.imagen = (Bitmap)Image.FromFile(r["imagen"].ToString());
                        }
                        else
                        {
                            item.imagen = (Bitmap)Image.FromFile(@"Image\cancel_30px.png");
                        }
                        item.descripcion = r["imagenUrl"].ToString();
                        decimal.TryParse(r["montoTotal"].ToString(), out montoTotal);
                        item.montoTotal = montoTotal;
                        items.Add(item);
                    }

                }
                return items;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return items;
            }
            finally
            {
                cn.Close();
            }
        }
        ///------ SECCION PARA NSERT ITEMS --------------
        public int insertItem(Items item)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            string RetornarId = "SELECT LAST_INSERT_ID();";
            try
            {
                cm = new SqlCommand("Insert into Items" + 
                    " (nombre," +
                    "codigoBarras," +
                    "precioA," +
                    "precioB," +
                    "precioC," +
                    "precioD," +
                    "descripcion," +
                    "descMax," +
                    "stockMin," +
                    "stock," +
                    "unidad," +
                    "bId," +
                    "cId," +
                    "gId," +
                    "mId," +
                    "servicio," +
                    "aplicaSeries," +
                    "negativo," + 
                    "combo," + 
                    "ice," + 
                    "valorIce," + 
                    "imagen," + 
                    "imagenUrl" + 
                    ",iva" + 
                    ",montoTotal" + 
                    ",HasIva) " +
                    "values " +
                    "(@nombre, " +
                    "@codigoBarras," +
                    "@precioA," +
                    "@precioB," +
                    "@precioC," +
                    "@precioD," +
                    "@descripcion," +
                  
                    "@stockMin," +
                    "@stock," +
                    "@unidad," +
                    "@bId," +
                    "@cId," +
                    "@gId," +
                    "@mId," +
                    "@servicio," +
                    "@aplicaSeries," +
                    "@negativo," +
                    "@combo," +
                    "@ice," +
                    "@valorIce," +
                    "@imagen," +
                    "@imagenUrl," +
                    "@iva," +
                    "@montoTotal," +
                    "@HasIva) SET @ID = SCOPE_IDENTITY();", cn);
                cm.Parameters.AddWithValue("@nombre", item.nombre);
                cm.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                cm.Parameters.AddWithValue("@precioA", item.precioA);
                cm.Parameters.AddWithValue("@precioB", item.precioB);
                cm.Parameters.AddWithValue("@precioC", item.precioC);
                cm.Parameters.AddWithValue("@precioD", item.precioD);
                cm.Parameters.AddWithValue("@descripcion", item.descripcion);
        
                cm.Parameters.AddWithValue("@stockMin", item.stockMin);
                cm.Parameters.AddWithValue("@stock", item.stock);
                cm.Parameters.AddWithValue("@unidad", item.unidad);
                cm.Parameters.AddWithValue("@bId", item.bId);
                cm.Parameters.AddWithValue("@cId", item.cId);
                cm.Parameters.AddWithValue("@gId", item.gId);
                cm.Parameters.AddWithValue("@mId", item.mId);
                cm.Parameters.AddWithValue("@servicio", item.servicio);
                cm.Parameters.AddWithValue("@aplicaSeries", item.aplicaSeries);
                cm.Parameters.AddWithValue("@negativo", item.negativo);
                cm.Parameters.AddWithValue("@combo", item.hascombo);
                cm.Parameters.AddWithValue("@ice", item.ice);
                cm.Parameters.AddWithValue("@valorIce", item.valorIce);
                cm.Parameters.AddWithValue("@HasIva", item.HasIva);
                cm.Parameters.AddWithValue("@iva", item.iva);
                if (item.imagen != null)
                {
                    if (!Directory.Exists(($@"{Directory.GetCurrentDirectory()}\ItemsImage")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\ItemsImage");
                    }
                    item.imagen.Save($@"{Directory.GetCurrentDirectory()}\ItemsImage\{item.Id}{item.nombre}{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
                }
                cm.Parameters.AddWithValue("@imagen", $@"{Directory.GetCurrentDirectory()}\ItemsImage\{item.Id}{item.nombre}{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
                cm.Parameters.AddWithValue("@imagenUrl", item.descripcion);
                cm.Parameters.AddWithValue("@montoTotal", item.precioA * item.precioB);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(), out Error);
                return Error;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = 0;
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        ///------ SECCION PARA UPDATE ITEMS --------------
        public string actualizarItem(Items item)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Items SET " +
                   "nombre=@nombre,"+
                   "codigoBarras=@codigoBarras," +
                   "precioA=@precioA," +
                   "precioB=@precioB,"+
                   "precioC=@precioC,"+
                   "precioD=@precioD," +
                   "descripcion=@descripcion,"+
                   "descMax=@descMax," +
                   "stockMin=@stockMin," +
                   "stock=@stockMax," +
                   "unidad=@unidad," +
                   "bId=@bId," +
                   "cId=@cId," +
                   "gId=@gId," +
                   "mId=@mId," +
                   "servicio=@servicio," +
                   "aplicaSeries=@aplicaSeries," +
                   "negativo=@negativo," +
                   "combo=@combo," +
                   "ice=@ice," +
                   "valorIce=@valorIce," +
                   "HasIva=@HasIva," +
                   "iva=@iva," +
                   "imagen=@imagen," +
                   "imagenUrl=@imagenUrl," +
                   "montoTotal=@montoTotal " +
                   "WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", item.Id);
                cm.Parameters.AddWithValue("@nombre", item.nombre);
                cm.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                cm.Parameters.AddWithValue("@precioA", item.precioA);
                cm.Parameters.AddWithValue("@precioB", item.precioB);
                cm.Parameters.AddWithValue("@precioC", item.precioC);
                cm.Parameters.AddWithValue("@precioD", item.precioD);
                cm.Parameters.AddWithValue("@descripcion", item.descripcion);
            
                cm.Parameters.AddWithValue("@stockMax", item.stock);
                cm.Parameters.AddWithValue("@stockMin", item.stockMin); 
                cm.Parameters.AddWithValue("@unidad", item.unidad);
                cm.Parameters.AddWithValue("@bId", item.bId);
                cm.Parameters.AddWithValue("@cId", item.cId);
                cm.Parameters.AddWithValue("@gId", item.gId);
                cm.Parameters.AddWithValue("@mId", item.mId);
                cm.Parameters.AddWithValue("@servicio", item.servicio);
                cm.Parameters.AddWithValue("@aplicaSeries", item.aplicaSeries);
                cm.Parameters.AddWithValue("@negativo", item.negativo);
                cm.Parameters.AddWithValue("@combo", item.hascombo);
                cm.Parameters.AddWithValue("@ice", item.ice);
                cm.Parameters.AddWithValue("@valorIce", item.valorIce);
                cm.Parameters.AddWithValue("@HasIva", item.HasIva);
                cm.Parameters.AddWithValue("@iva", item.iva);


                if (item.imagen != null)
                {
                    if (!Directory.Exists(($@"{Directory.GetCurrentDirectory()}\ItemsImage")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\ItemsImage");
                    }
                    item.imagen.Save($@"{Directory.GetCurrentDirectory()}\ItemsImage\{item.Id}{item.nombre}{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
                }
                cm.Parameters.AddWithValue("@imagen", $@"{Directory.GetCurrentDirectory()}\ItemsImage\{item.Id}{item.nombre}{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
                cm.Parameters.AddWithValue("@imagenUrl", item.descripcion);
                cm.Parameters.AddWithValue("@montoTotal", item.precioA * item.precioB);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            { cn.Close(); }
        }
        ///------ SECCION PARA DELETE ITEMS --------------
        public string deleteItem(int idItem)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Items WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idItem);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //get Usuarios Id
        public Usuarios selectUsuariosPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Usuarios usuarios = new Usuarios();
            try
            {
                cm = new SqlCommand($"Select * from Usuarios Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    usuarios.Id = (int)dt.Rows[0]["Id"];
                    usuarios.nombre = dt.Rows[0]["username"].ToString();
                    usuarios.role = dt.Rows[0]["role"].ToString();
                    usuarios.nombre = dt.Rows[0]["nombre"].ToString();
                    usuarios.isactive = Convert.ToBoolean(dt.Rows[0]["isactive"].ToString());
                }
                return usuarios;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return usuarios;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectUsuariosDataPorId(int Id)
        {
            DataSet dt = new DataSet();
            cn.ConnectionString = myConnection();
            Usuarios usuarios = new Usuarios();
            try
            {
                cm = new SqlCommand($"Select * from Usuarios Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
           
                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }
        // get usuarios 
        public List<Usuarios> selectTodosLosUsuarios()
        {
            cn.ConnectionString = myConnection();
            List<Usuarios> usuarios = new List<Usuarios>();

            try
            {
                cm = new SqlCommand($"Select * from Items");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Usuarios usuario = new Usuarios();
                        usuario.Id = (int)dt.Rows[0]["Id"];
                        usuario.nombre = dt.Rows[0]["nombre"].ToString();
                        usuario.role = dt.Rows[0]["role"].ToString();
                        usuario.isactive = Convert.ToBoolean(dt.Rows[0]["isactive"].ToString());
                        usuarios.Add(usuario);
                    }

                }
                return usuarios;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return usuarios;
            }
            finally
            {
                cn.Close();
            }
        }

        //insertar usuarios
        public string insertUsuarios(Usuarios usuarios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Usuarios (username,contraseña,role,nombre,isactive values(@username,@contraseña,@role,@nombre,@isactive))", cn);
                cm.Parameters.AddWithValue("@username", usuarios.nombre);
                cm.Parameters.AddWithValue("@role", usuarios.role);
                cm.Parameters.AddWithValue("@nombre", usuarios.nombre);
                cm.Parameters.AddWithValue("@isactive", usuarios.isactive);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar usuario 
        public string actualizarUsuario(Usuarios usuarios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Usuarios SET username=@username,contraseña=@contraseña,nombre=@nombre,role=@role,isactive=@isactive WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", usuarios.Id);
                cm.Parameters.AddWithValue("@nombre", usuarios.nombre);
                cm.Parameters.AddWithValue("@contraseña", usuarios.contraseña);
                cm.Parameters.AddWithValue("@role", usuarios.role);
                cm.Parameters.AddWithValue("@nombre", usuarios.role);
                cm.Parameters.AddWithValue("@isactive", usuarios.isactive);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar usuarios
        public string deleteUsers(int idUsuarios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM usuarios WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idUsuarios);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //get ajustamiento id
        public Ajustamiento selectAjustamientosPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Ajustamiento ajustamiento = new Ajustamiento();
            try
            {
                cm = new SqlCommand($"Select * from Ajustamiento Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ajustamiento.Id = (int)dt.Rows[0]["Id"];
                    ajustamiento.referenceno = dt.Rows[0]["referenceno"].ToString();
                    ajustamiento.pcode = dt.Rows[0]["pcode"].ToString();
                    ajustamiento.qty = Convert.ToInt16(dt.Rows[0]["qty"]);
                    ajustamiento.action = dt.Rows[0]["action"].ToString();
                    ajustamiento.remarks = dt.Rows[0]["remarks"].ToString();
                    ajustamiento.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"].ToString());
                    ajustamiento.user = dt.Rows[0]["[user]"].ToString();

                }
                return ajustamiento;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return ajustamiento;
            }
            finally
            {
                cn.Close();
            }
        }
        // get ajustamiento
        public List<Ajustamiento> selectTodosLosAjustes()
        {
            cn.ConnectionString = myConnection();
            List<Ajustamiento> ajustamientos = new List<Ajustamiento>();

            try
            {
                cm = new SqlCommand($"Select * from Ajustamientos ");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Ajustamiento ajustamiento = new Ajustamiento();
                        ajustamiento.Id = (int)dt.Rows[0]["Id"];
                        ajustamiento.referenceno = dt.Rows[0]["referenceno"].ToString();
                        ajustamiento.pcode = dt.Rows[0]["pcode"].ToString();
                        ajustamiento.qty = Convert.ToInt32(dt.Rows[0]["qty"]);
                        ajustamiento.action = dt.Rows[0]["action"].ToString();
                        ajustamiento.remarks = dt.Rows[0]["remarks"].ToString();
                        ajustamiento.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"]);
                        ajustamiento.user = dt.Rows[0]["[user]"].ToString();

                        ajustamientos.Add(ajustamiento);
                    }

                }
                return ajustamientos;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return ajustamientos;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar ajustamientos 
        public string Ajustamiento(Ajustamiento ajustamiento)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Ajustamiento (referenceno,pcode,qty,action,remarks,sdate,[user] values(@referenceno,@pcode,@qty,@action,@remarks,@sdate,@[user]))");
                cm.Parameters.AddWithValue("@referenceno", ajustamiento.referenceno);
                cm.Parameters.AddWithValue("@pcode", ajustamiento.pcode);
                cm.Parameters.AddWithValue("@qty", ajustamiento.qty);
                cm.Parameters.AddWithValue("@action", ajustamiento.action);
                cm.Parameters.AddWithValue("@remarks", ajustamiento.remarks);
                cm.Parameters.AddWithValue("@sdate", ajustamiento.sdate);
                cm.Parameters.AddWithValue("@[user]", ajustamiento.user);

                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar ajustamiento 
        public string actualizarAjustamiento(Ajustamiento ajustamientos)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Ajustamiento SET referenceno=@referenceno,pcode=@pcode,qty=@qty,action=@action,sdate=@sdate,[user]=@[user] WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", ajustamientos.Id);
                cm.Parameters.AddWithValue("@referenceno", ajustamientos.referenceno);
                cm.Parameters.AddWithValue("@pcode", ajustamientos.pcode);
                cm.Parameters.AddWithValue("@qty", ajustamientos.qty);
                cm.Parameters.AddWithValue("@action", ajustamientos.action);
                cm.Parameters.AddWithValue("@sdate", ajustamientos.sdate);
                cm.Parameters.AddWithValue("@[user]", ajustamientos.user);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Items
        public string deleteItems(int idAjustamiento)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Ajustamiento WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idAjustamiento);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
         
        //obtener bodega id 
        public Bodega selectBodegaId(int Id)
        {
            cn.ConnectionString = myConnection();
            Bodega bodegas = new Bodega();
            try
            {
                cm = new SqlCommand($"Select * from Bodega Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bodegas.Id = (int)dt.Rows[0]["Id"];
                    bodegas.Nombre = dt.Rows[0]["nombre"].ToString();
                }
                return bodegas;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return bodegas;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener bodega
        public List<Bodega> selectTodosLosBodegas()
        {
            cn.ConnectionString = myConnection();
            List<Bodega> bodega = new List<Bodega>();

            try
            {
                cm = new SqlCommand($"Select * from Bodega");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Bodega bodegas = new Bodega();
                        bodegas.Id = (int)dt.Rows[0]["Id"];
                        bodegas.Nombre = dt.Rows[0]["nombre"].ToString();
                        bodega.Add(bodegas);
                    }

                }
                return bodega;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return bodega;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar bodega
        public string insertBodega(Bodega bodega)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Bodega (nombre values(@Bodega))");
                cm.Parameters.AddWithValue("@nombre", bodega.Nombre);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        public string actualizarBodega(Bodega bodega)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Bodega SET nombre=@nombre WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", bodega.Id);
                cm.Parameters.AddWithValue("@nombre", bodega.Nombre);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar bodegas
        public string deleteBodegas(int idBodegas)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Bodega WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idBodegas);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener cancel por id 
        public Cancel selectCancelId(int Id)
        {
            cn.ConnectionString = myConnection();
            Cancel cancel = new Cancel();
            try
            {
                cm = new SqlCommand($"Select * from Cancel Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cancel.Id = (int)dt.Rows[0]["Id"];
                    cancel.transno = dt.Rows[0]["nombre"].ToString();
                    cancel.pcode = dt.Rows[0]["pcode"].ToString();
                    cancel.qty = (int)dt.Rows[0]["qty"];
                    cancel.total = (decimal)dt.Rows[0]["total"];
                    cancel.sdate = (DateTime)dt.Rows[0]["sdate"];
                    cancel.voidby = dt.Rows[0]["voidby"].ToString();
                    cancel.cancelledby = dt.Rows[0]["cancelledby"].ToString();
                    cancel.reason = dt.Rows[0]["reason"].ToString();
                    cancel.action = dt.Rows[0]["action"].ToString();
                }

                return cancel;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return cancel;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener cancel
        public List<Cancel> selectTodosLosCancel()
        {
            cn.ConnectionString = myConnection();
            List<Cancel> cancel = new List<Cancel>();

            try
            {
                cm = new SqlCommand($"Select * from Cancel");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Cancel cnl = new Cancel();
                        cnl.Id = (int)dt.Rows[0]["Id"];
                        cnl.transno = dt.Rows[0]["nombre"].ToString();
                        cnl.pcode = dt.Rows[0]["pcode"].ToString();
                        cnl.qty = (int)dt.Rows[0]["qty"];
                        cnl.total = (decimal)dt.Rows[0]["total"];
                        cnl.sdate = (DateTime)dt.Rows[0]["sdate"];
                        cnl.voidby = dt.Rows[0]["voidby"].ToString();
                        cnl.cancelledby = dt.Rows[0]["cancelledby"].ToString();
                        cnl.reason = dt.Rows[0]["reason"].ToString();
                        cnl.action = dt.Rows[0]["action"].ToString();
                        cancel.Add(cnl);
                    }

                }
                return cancel;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return cancel;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar cancel
        public string insertCancel(Cancel cancel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Cancel (transno,pcode,price,qty,total,sdate,voidby,cancelledby,reason,action values(@transno,@pcode,@price,@qty,@total,@sdate,@voidby,@cancelledby,@reason,@action))");
                cm.Parameters.AddWithValue("@transno", cancel.transno);
                cm.Parameters.AddWithValue("@pcode", cancel.pcode);
                cm.Parameters.AddWithValue("@price", cancel.price);
                cm.Parameters.AddWithValue("@qty", cancel.qty);
                cm.Parameters.AddWithValue("@total", cancel.total);
                cm.Parameters.AddWithValue("@sdate", cancel.sdate);
                cm.Parameters.AddWithValue("@voidby", cancel.voidby);
                cm.Parameters.AddWithValue("@cancelledby", cancel.cancelledby);
                cm.Parameters.AddWithValue("@reason", cancel.reason);
                cm.Parameters.AddWithValue("@action", cancel.action);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar cancel
        public string actualizarCancel(Cancel cancel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Cancel SET transno=@transno,pcode=@pcode,price=@price,qty=@qty,total=@total,sdate=@sdate,voidby=@voidby,cancelledby=@cancelledby, WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", cancel.Id);
                cm.Parameters.AddWithValue("@transno", cancel.transno);
                cm.Parameters.AddWithValue("@pcode", cancel.pcode);
                cm.Parameters.AddWithValue("@price", cancel.price);
                cm.Parameters.AddWithValue("@qty", cancel.qty);
                cm.Parameters.AddWithValue("@total", cancel.total);
                cm.Parameters.AddWithValue("@sdate", cancel.sdate);
                cm.Parameters.AddWithValue("@voidby", cancel.voidby);
                cm.Parameters.AddWithValue("@cancelledby", cancel.cancelledby);
                cm.Parameters.AddWithValue("@reason", cancel.reason);
                cm.Parameters.AddWithValue("@action", cancel.action);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar cancel
        public string deleteCancel(int idCancel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Bodega WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idCancel);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener id carrito
        public Carrito selectCarritoId(int Id)
        {
            cn.ConnectionString = myConnection();
            Carrito carrito = new Carrito();
            try
            {
                cm = new SqlCommand($"Select * from Carrito Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    carrito.Id = (int)dt.Rows[0]["Id"];
                    carrito.trasnno = dt.Rows[0]["transnno"].ToString();
                    carrito.pcode = dt.Rows[0]["pcode"].ToString();
                    carrito.price = Convert.ToDecimal(dt.Rows[0]["price"].ToString());
                    carrito.cantidad = (int)dt.Rows[0]["cantidad"];
                    carrito.disc_percent = Convert.ToDecimal(dt.Rows[0]["disc_percent"]);
                    carrito.disc = Convert.ToDecimal(dt.Rows[0]["disc"].ToString());
                    carrito.total = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
                    carrito.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"].ToString());
                    carrito.status = dt.Rows[0]["status"].ToString();
                    carrito.cashier = dt.Rows[0]["cashier"].ToString();

                }
                return carrito;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return carrito;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener Carrito
        public List<Carrito> selectTodosLosCarrito()
        {
            cn.ConnectionString = myConnection();
            List<Carrito> carrito = new List<Carrito>();

            try
            {
                cm = new SqlCommand($"Select * from Bodega");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Carrito carritos = new Carrito();
                        carritos.Id = (int)dt.Rows[0]["Id"];
                        carritos.trasnno = dt.Rows[0]["nombre"].ToString();
                        carritos.pcode = dt.Rows[0]["pcode"].ToString();
                        carritos.price = Convert.ToDecimal(dt.Rows[0]["price"].ToString());
                        carritos.cantidad = (int)dt.Rows[0]["cantidad"];
                        carritos.disc_percent = Convert.ToDecimal(dt.Rows[0]["disc_percent"].ToString());
                        carritos.disc = Convert.ToDecimal(dt.Rows[0]["disc"].ToString());
                        carritos.total = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
                        carritos.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"].ToString());
                        carritos.status = dt.Rows[0]["status"].ToString();
                        carritos.cashier = dt.Rows[0]["cashier"].ToString();

                        carrito.Add(carritos);
                    }

                }
                return carrito;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return carrito;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar carrito
        public string insertCarrito(Carrito carrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Carrito (trasnno,pcode,price,cantidad,disc_percent,disc,total,sdate,status,cashier values(@trasnno,@pcode,@price,@cantidad,@disc_percent,@disc,@total,@sdate,@status,@cashier))");
                cm.Parameters.AddWithValue("@trasnno", carrito.trasnno);
                cm.Parameters.AddWithValue("@pcode", carrito.pcode);
                cm.Parameters.AddWithValue("@price", carrito.price);
                cm.Parameters.AddWithValue("@cantidad", carrito.cantidad);
                cm.Parameters.AddWithValue("@disc_percent", carrito.disc_percent);
                cm.Parameters.AddWithValue("@disc", carrito.disc);
                cm.Parameters.AddWithValue("@total", carrito.total);
                cm.Parameters.AddWithValue("@sdate", carrito.sdate);
                cm.Parameters.AddWithValue("@status", carrito.status);
                cm.Parameters.AddWithValue("@cashier", carrito.cashier);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un carrito
        public string actualizarCarrito(Carrito carrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Carrito SET transnno=@transnno,pcode=@pcode,price=@price,camtidad=@cantidad,disc_percent=@disc_percent,disc=@disc,total=@total,sdate=@sdate,status=@status,cashier=@cashier WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", carrito.Id);
                cm.Parameters.AddWithValue("@transnno", carrito.trasnno);
                cm.Parameters.AddWithValue("@pcode", carrito.pcode);
                cm.Parameters.AddWithValue("@price", carrito.price);
                cm.Parameters.AddWithValue("@cantidad", carrito.cantidad);
                cm.Parameters.AddWithValue("@disc_percent", carrito.disc_percent);
                cm.Parameters.AddWithValue("@disc", carrito.disc);
                cm.Parameters.AddWithValue("@total", carrito.total);
                cm.Parameters.AddWithValue("@sdate", carrito.sdate);
                cm.Parameters.AddWithValue("@status", carrito.status);
                cm.Parameters.AddWithValue("@cashier", carrito.cashier);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();;
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Carrito
        public string deleteCarrito(int idCarrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Carrito WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idCarrito);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener id categorias
        public Categorias selectCategoriasId(int Id)
        {
            cn.ConnectionString = myConnection();
            Categorias categoria = new Categorias();
            try
            {
                cm = new SqlCommand($"Select * from Categorias Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    categoria.Id = (int)dt.Rows[0]["Id"];
                    categoria.nombre = dt.Rows[0]["Categoria"].ToString();

                }
                return categoria;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return categoria;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener Categoria
        public List<Categorias> selectTodosLasCategorias()
        {
            cn.ConnectionString = myConnection();
            List<Categorias> categoria = new List<Categorias>();

            try
            {
                cm = new SqlCommand($"Select * from Categorias");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Categorias cat = new Categorias();
                        cat.Id = (int)dt.Rows[0]["Id"];
                        cat.nombre = dt.Rows[0]["Categoria"].ToString();

                        categoria.Add(cat);
                    }

                }
                return categoria;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return categoria;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar categoria
        public string insertCategoria(Categorias categoria)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Categorias (Categoria values(@Categoria))");
                cm.Parameters.AddWithValue("@Categoria", categoria.nombre);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una Categoria
        public string actualizarCategoria(Categorias categoria)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Categorias SET Categorias=@Categorias WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", categoria.Id);
                cm.Parameters.AddWithValue("@categoria", categoria.nombre);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Categorias
        public string deleteCategorias(int idCarrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Categorias WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idCarrito);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener id descripcionVenta   
        public DescripcionVenta selectDescripcionVentaId(int Id)
        {
            cn.ConnectionString = myConnection();
            DescripcionVenta descripcion = new DescripcionVenta();
            try
            {
                cm = new SqlCommand($"Select * from DescripcionVenta Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    descripcion.IdVenta = (int)dt.Rows[0][" Id_descripcion_venta"];
                    descripcion.IdItem = (int)dt.Rows[0]["producto"];
                    descripcion.cantidad = (int)dt.Rows[0]["cantidad"];
                    descripcion.cantidad = (int)dt.Rows[0]["venta"];
                    descripcion.precioCompra = Convert.ToDecimal(dt.Rows[0]["precio"].ToString());
                }
                return descripcion;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return descripcion;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener descripcion
        public List<DescripcionVenta> selectTodosLaDescripcionVenta()
        {
            cn.ConnectionString = myConnection();
            List<DescripcionVenta> descripcion = new List<DescripcionVenta>();

            try
            {
                cm = new SqlCommand($"Select * from DescripcionVenta");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        DescripcionVenta des = new DescripcionVenta();
                        des.IdVenta = (int)dt.Rows[0][" Id_descripcion_venta"];
                        des.IdItem = (int)dt.Rows[0]["producto"];
                        des.cantidad = (int)dt.Rows[0]["cantidad"];
                        des.cantidad = (int)dt.Rows[0]["venta"];
                        des.precioCompra = Convert.ToDecimal(dt.Rows[0]["precio"].ToString());
                        descripcion.Add(des);
                    }

                }
                return descripcion;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return descripcion;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Descripcion

        //eliminar Descripcion
        public string deleteDescripcionVenta(int idDescripcion)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM DescripcionVenta WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idDescripcion);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        //obtener id Enstock  
        public Enstock selectEnstockId(int Id)
        {
            cn.ConnectionString = myConnection();
            Enstock enstock = new Enstock();
            try
            {
                cm = new SqlCommand($"Select * from Enstock Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    enstock.Id = (int)dt.Rows[0]["Id"];
                    enstock.refno = Convert.ToString(dt.Rows[0]["refno"]);
                    enstock.pcode = Convert.ToString(dt.Rows[0]["pcode"]);
                    enstock.qty = (int)dt.Rows[0]["qty"];
                    enstock.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"]);
                    enstock.stockinby = Convert.ToString(dt.Rows[0]["stockinby"]);
                    enstock.status = Convert.ToString(dt.Rows[0]["status"]);
                    enstock.supplierId = Convert.ToString(dt.Rows[0]["supplierId"]);
                }
                return enstock;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return enstock;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener Enstock
        public List<Enstock> obtenerTodosLosEnstock()
        {
            cn.ConnectionString = myConnection();
            List<Enstock> enstocks = new List<Enstock>();

            try
            {
                cm = new SqlCommand($"Select * from Clientes");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Enstock enstock = new Enstock();
                        enstock.Id = (int)dt.Rows[0]["Id"];
                        enstock.refno = Convert.ToString(dt.Rows[0]["refno"]);
                        enstock.pcode = Convert.ToString(dt.Rows[0]["pcode"]);
                        enstock.qty = (int)dt.Rows[0]["qty"];
                        enstock.sdate = Convert.ToDateTime(dt.Rows[0]["sdate"]);
                        enstock.stockinby = Convert.ToString(dt.Rows[0]["stockinby"]);
                        enstock.status = Convert.ToString(dt.Rows[0]["status"]);
                        enstock.supplierId = Convert.ToString(dt.Rows[0]["supplierId"]);
                        enstocks.Add(enstock);
                    }

                }
                return enstocks;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return enstocks;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Enstock
        public string insertEnstock(Enstock enstock)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Enstock (refno,pcode,qty,sdate,stockinby,status,supplierId)values(@refno,@pcode,@qty,@sdate,@stockinby,@status,@supplierId)");
                cm.Parameters.AddWithValue("@refno", enstock.refno);
                cm.Parameters.AddWithValue("@pcode", enstock.pcode);
                cm.Parameters.AddWithValue("@qty", enstock.qty);
                cm.Parameters.AddWithValue("@sdate", enstock.sdate);
                cm.Parameters.AddWithValue("@stockinby", enstock.stockinby);
                cm.Parameters.AddWithValue("@stutus", enstock.status);
                cm.Parameters.AddWithValue("@supplierId", enstock.supplierId);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar en Stock
        public string actualizarEnstock(Enstock enstock)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Enstock SET refno=@refno,pcode=@pcode,qty=@qty,sdate=@sdate,stockinby=@stockinby,status=@status,supplierId=@supplierId WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", enstock.Id);
                cm.Parameters.AddWithValue("@refno", enstock.refno);
                cm.Parameters.AddWithValue("@pcode", enstock.pcode);
                cm.Parameters.AddWithValue("@qty", enstock.qty);
                cm.Parameters.AddWithValue("@sdate", enstock.sdate);
                cm.Parameters.AddWithValue("@stockinby", enstock.stockinby);
                cm.Parameters.AddWithValue("@status", enstock.status);
                cm.Parameters.AddWithValue("@supplierId", enstock.supplierId);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Enstock
        public string deleteEnstock(int idEnstock)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Clientes WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idEnstock);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        //obtener id Clientes   
        public Clientes selectClientesId(int Id)
        {
            cn.ConnectionString = myConnection();
            Clientes clientes = new Clientes();
            try
            {
                cm = new SqlCommand($"Select * from Clientes Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    clientes.Id = (int)dt.Rows[0]["Id"];
                    clientes.nombre = Convert.ToString(dt.Rows[0]["nombre"]);
                    clientes.comercio = Convert.ToString(dt.Rows[0]["comercio"]);
                    clientes.codigo = Convert.ToString(dt.Rows[0]["codigo"]);
                    clientes.fechaNacimiento = Convert.ToDateTime(dt.Rows[0]["fechaNacimiento"]);
                    clientes.fechaRegistro = Convert.ToDateTime(dt.Rows[0]["fechaRegistro"]);
                    clientes.ciudad = Convert.ToString(dt.Rows[0]["ciudad"]);
                    clientes.tipo = Convert.ToString(dt.Rows[0]["tipo"]);
                    clientes.ciRuc = Convert.ToString(dt.Rows[0]["ciRuc"]);
                    clientes.pais = Convert.ToString(dt.Rows[0]["pais"]);
                    clientes.estado = Convert.ToString(dt.Rows[0]["estado"]);
                    clientes.direccion = Convert.ToString(dt.Rows[0]["direccion"]);
                    clientes.telefono = Convert.ToString(dt.Rows[0]["telefono"]);
                    clientes.celular = Convert.ToString(dt.Rows[0]["celular"]);
                    clientes.fax = Convert.ToString(dt.Rows[0]["fax"]);
                    clientes.cargo = Convert.ToString(dt.Rows[0]["cargo"]);
                    clientes.email = Convert.ToString(dt.Rows[0]["email"]);
                    clientes.tipo = Convert.ToString(dt.Rows[0]["tipoCliente"]);
                }
                return clientes;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return clientes;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectClienteIdData(int Id)
        {
            DataSet dt = new DataSet();
            cn.ConnectionString = myConnection();
            Clientes clientes = new Clientes();
            try
            {
                cm = new SqlCommand($"Select * from Clientes Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
               
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener clientes
        public List<Clientes> TodosLosClientes()
        {
            cn.ConnectionString = myConnection();
            List<Clientes> client = new List<Clientes>();

            try
            {
                cm = new SqlCommand($"Select * from Clientes");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Clientes clientes = new Clientes();
                        clientes.Id = (int)r["Id"];
                        clientes.nombre = Convert.ToString(r["nombre"]);
                        clientes.comercio = Convert.ToString(r["comercio"]);
                        clientes.codigo = Convert.ToString(r["codigo"]);
                        clientes.fechaNacimiento = Convert.ToDateTime(r["fechaNacimiento"]);
                        clientes.fechaRegistro = Convert.ToDateTime(r["fechaRegistro"]);
                        clientes.ciudad = Convert.ToString(r["ciudad"]);
                        clientes.tipo = Convert.ToString(r["tipo"]);
                        clientes.ciRuc = Convert.ToString(r["ciRuc"]);
                        clientes.pais = Convert.ToString(r["pais"]);
                        clientes.estado = Convert.ToString(r["estado"]);
                        clientes.direccion = Convert.ToString(r["direccion"]);
                        clientes.telefono = Convert.ToString(r["telefono"]);
                        clientes.celular = Convert.ToString(r["celular"]);
                        clientes.fax = Convert.ToString(r["fax"]);
                        clientes.cargo = Convert.ToString(r[15]);
                        clientes.email = Convert.ToString(r["email"]);
                        clientes.tipo = Convert.ToString(r["tipoCliente"]);
                        client.Add(clientes);
                    }

                }
                return client;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return client;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Clientes
        public string insertClientes(Clientes clientes)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Clientes (nombre,comercio,codigo,fechaNacimiento,fechaRegistro,ciudad,tipo,ciRuc,pais,estado,direccion,telefono,celular,fax,cargo,email,tipoCliente )values(@nombre,@comercio,@codigo,@fechaNacimiento,@fechaRegistro,@ciudad,@tipo,@ciRuc,@pais,@estado,@direccion,@telefono,@celular,@fax,@cargo,@email,@tipoCliente)", cn);

                cm.Parameters.AddWithValue("@nombre", clientes.nombre);
                cm.Parameters.AddWithValue("@comercio", clientes.comercio);
                cm.Parameters.AddWithValue("@codigo", clientes.codigo);
                cm.Parameters.AddWithValue("@fechaNacimiento", clientes.fechaNacimiento.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@fechaRegistro", clientes.fechaRegistro.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@ciudad", clientes.ciudad);
                cm.Parameters.AddWithValue("@tipo", clientes.tipo);
                cm.Parameters.AddWithValue("@ciRuc", clientes.ciRuc);
                cm.Parameters.AddWithValue("@pais", clientes.pais);
                cm.Parameters.AddWithValue("@estado", clientes.estado);
                cm.Parameters.AddWithValue("@direccion", clientes.direccion);
                cm.Parameters.AddWithValue("@telefono", clientes.telefono);
                cm.Parameters.AddWithValue("@celular", clientes.celular);
                cm.Parameters.AddWithValue("@fax", clientes.fax);
                cm.Parameters.AddWithValue("@cargo", clientes.cargo);
                cm.Parameters.AddWithValue("@email", clientes.email);
                cm.Parameters.AddWithValue("@tipoCliente", clientes.tipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una Clientes
        public string actualizarClientes(Clientes clientes)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Clientes SET nombre=@nombre,comercio=@comercio,codigo=@codigo,fechaNacimiento=@fechaNacimiento,fechaRegistro=@fechaRegistro,ciudad=@ciudad,tipo=@tipo,ciRuc=@ciRuc,pais=@pais,estado=@estado,direccion=@direccion,telefono=@telefono,celular=@celular,fax=@fax,cargo=@cargo, email=@email,tipoCLiente=@tipoCliente WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", clientes.Id);
                cm.Parameters.AddWithValue("@nombre", clientes.nombre);
                cm.Parameters.AddWithValue("@comercio", clientes.comercio);
                cm.Parameters.AddWithValue("@codigo", clientes.codigo);
                cm.Parameters.AddWithValue("@fechaNacimiento", clientes.fechaNacimiento.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@fechaRegistro", clientes.fechaRegistro.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@ciudad", clientes.ciudad);
                cm.Parameters.AddWithValue("@tipo", clientes.tipo);
                cm.Parameters.AddWithValue("@ciRuc", clientes.ciRuc);
                cm.Parameters.AddWithValue("@pais", clientes.pais);
                cm.Parameters.AddWithValue("@estado", clientes.estado);
                cm.Parameters.AddWithValue("@direccion", clientes.direccion);
                cm.Parameters.AddWithValue("@telefono", clientes.telefono);
                cm.Parameters.AddWithValue("@celular", clientes.celular);
                cm.Parameters.AddWithValue("@fax", clientes.fax);
                cm.Parameters.AddWithValue("@cargo", clientes.cargo);
                cm.Parameters.AddWithValue("@email", clientes.email);
                cm.Parameters.AddWithValue("@tipoCliente", clientes.tipo);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar clientes
        public string deleteClientes(int idClientes)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Clientes WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idClientes);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        //obtener id factura   
        public Factura selectFacturaId(int Id)
        {
            cn.ConnectionString = myConnection();
            Factura factura = new Factura();
            try
            {
                cm = new SqlCommand($"Select * from factura Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    factura.id_venta = (int)dt.Rows[0]["id_venta"];
                    factura.numero = (int)dt.Rows[0]["numero"];
                    factura.clienteId = (int)dt.Rows[0]["clienteId"];
                    factura.usuario = (int)dt.Rows[0]["usuario"];
                    factura.fecha_venta = Convert.ToDateTime(dt.Rows[0]["fecha_venta"]);
                    factura.total = Convert.ToDecimal(dt.Rows[0]["total"]);
                    factura.iva = Convert.ToDecimal(dt.Rows[0]["iva"]);
                    factura.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"]);
                    factura.descuento = Convert.ToDecimal(dt.Rows[0]["descuento"]);
                    factura.productoId = (int)dt.Rows[0]["productoId"];
                }
                return factura;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return factura;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectFacturaIdData(int Id)
        {
            DataSet dt = new DataSet();
            cn.ConnectionString = myConnection();
            Factura factura = new Factura();
            try
            {
                cm = new SqlCommand($"Select * from factura Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
        
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener factura
        public List<Factura> TodosLasFacturas()
        {
            cn.ConnectionString = myConnection();
            List<Factura> fac = new List<Factura>();

            try
            {
                cm = new SqlCommand($"Select * from Clientes");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Factura facturas = new Factura();
                        facturas.id_venta = (int)dt.Rows[0]["id_venta"];
                        facturas.numero = (int)dt.Rows[0]["nombre"];
                        facturas.clienteId = (int)dt.Rows[0]["comercio"];
                        facturas.usuario = (int)dt.Rows[0]["usuario"];
                        facturas.fecha_venta = Convert.ToDateTime(dt.Rows[0]["fecha_venta"]);
                        facturas.total = Convert.ToDecimal(dt.Rows[0]["total"]);
                        facturas.iva = Convert.ToDecimal(dt.Rows[0]["iva"]);
                        facturas.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"]);
                        facturas.descuento = Convert.ToDecimal(dt.Rows[0]["descuento"]);
                        facturas.productoId = (int)dt.Rows[0]["productoId"];

                        fac.Add(facturas);
                    }

                }
                return fac;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return fac;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar facturas
        public string insertFacturas(Factura factura)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into factura (numero,clienteId,usuario,fecha_venta,total,iva,subtotal,descuento,productoId)values(@numero,@clienteId,@usuario,@fecha_venta,@total,@iva,@subtotal,@descuento,@productoId)",cn);
                cm.Parameters.AddWithValue("@numero", factura.numero);
                cm.Parameters.AddWithValue("@clienteId", factura.clienteId);
                cm.Parameters.AddWithValue("@usuario", factura.usuario);
                cm.Parameters.AddWithValue("@fecha_venta", factura.fecha_venta.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@total", factura.total);
                cm.Parameters.AddWithValue("@iva", factura.iva);
                cm.Parameters.AddWithValue("@subtotal", factura.subtotal);
                cm.Parameters.AddWithValue("@descuento", factura.descuento);
                cm.Parameters.AddWithValue("@productoId", factura.productoId);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una factura
        public string actualizarFactura(Factura factura)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE factura SET numero=@numero,clienteId=@clienteId,usuario=@usuario,fecha_venta=@fecha_venta,total=@total,iva=@iva,subtotal=@subtotal,descuento=@descuento,productoId=@productoId WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", factura.id_venta);
                cm.Parameters.AddWithValue("@numero", factura.numero);
                cm.Parameters.AddWithValue("@clienteId", factura.clienteId);
                cm.Parameters.AddWithValue("@usuario", factura.usuario);
                cm.Parameters.AddWithValue("@fecha_venta", factura.fecha_venta.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@total", factura.total);
                cm.Parameters.AddWithValue("@iva", factura.iva);
                cm.Parameters.AddWithValue("@subtotal", factura.subtotal);
                cm.Parameters.AddWithValue("@descuento", factura.descuento);
                cm.Parameters.AddWithValue("@productoId", factura.productoId);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar factura
        public string deletefactura(int idFacturas)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Clientes WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idFacturas);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        //obtener id tipoEquipo   
        public TipoEquipo selectTipoEquipoId(int Id)
        {
            cn.ConnectionString = myConnection();
            TipoEquipo tipoEquipo = new TipoEquipo();
            try
            {
                cm = new SqlCommand($"Select * from TipoEquipo Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    tipoEquipo.Id = (int)dt.Rows[0]["Id"];
                    tipoEquipo.tipoEquipo = Convert.ToString(dt.Rows[0]["tipoEquipo"]);

                }
                return tipoEquipo;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tipoEquipo;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener tipoEquipo
        public List<TipoEquipo> TodosTipoEquipo()
        {
            cn.ConnectionString = myConnection();
            List<TipoEquipo> tipoEquipo = new List<TipoEquipo>();

            try
            {
                cm = new SqlCommand($"Select * from TipoEquipo");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        TipoEquipo tipoEquipos = new TipoEquipo();
                        tipoEquipos.Id = (int)dt.Rows[0]["Id"];
                        tipoEquipos.tipoEquipo = Convert.ToString(dt.Rows[0]["tipoEquipo"]);

                        tipoEquipo.Add(tipoEquipos);
                    }

                }
                return tipoEquipo;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tipoEquipo;
            }
            finally
            {
                cn.Close();
            }
        }
      
        //insertar un tipoEquipo
            public int insertTipoEquipo(TipoEquipo tipoEquipo)
        {
            cn.ConnectionString = myConnection();
            int Error = 0;
            try
            {
                cm = new SqlCommand("Insert into TipoEquipo (tipoEquipo)values(@tipoEquipo)",cn);
                cm.Parameters.AddWithValue("@tipoEquipo", tipoEquipo.tipoEquipo);
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cn.Open();
                cm.ExecuteNonQuery();
                int.TryParse(param.Value.ToString(), out Error);
                return Error;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un tipoEquipo
        public string actualizarTipoEquipo(TipoEquipo tipoEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE TipoEquipo SET tipoEquipo=@tipoEquipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", tipoEquipo.Id);
                cm.Parameters.AddWithValue("@tipoEquipo", tipoEquipo.tipoEquipo);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar tipoEquipo
        public string deleteTipoEquipo(int idTipoEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM TipoEquipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idTipoEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        //obtener id MarcaEquipo   
        public MarcaEquipo selectMarcaEquipoId(int Id)
        {
            cn.ConnectionString = myConnection();
            MarcaEquipo marcaEquipo = new MarcaEquipo();
            try
            {
                cm = new SqlCommand($"Select * from MarcaEquipo Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    marcaEquipo.Id = (int)dt.Rows[0]["Id"];
                    marcaEquipo.NombreMarcaEquipo = Convert.ToString(dt.Rows[0]["marcaEquipo"]);

                }
                return marcaEquipo;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return marcaEquipo;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener marcaEquipo
        public List<MarcaEquipo> TodosLasMarcasEquipo()
        {
            cn.ConnectionString = myConnection();
            List<MarcaEquipo> marcaEquipo = new List<MarcaEquipo>();

            try
            {
                cm = new SqlCommand($"Select * from MarcaEquipo");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        MarcaEquipo marcaEquipos = new MarcaEquipo();
                        marcaEquipos.Id = (int)dt.Rows[0]["Id"];
                        marcaEquipos.NombreMarcaEquipo = Convert.ToString(dt.Rows[0]["marcaEquipo"]);

                        marcaEquipo.Add(marcaEquipos);
                    }

                }
                return marcaEquipo;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return marcaEquipo;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar un marcaEquipo
        public string insertMarcaEquipo(MarcaEquipo marcaEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into MarcaEquipo (marcaEquipo)values(@marcaEquipo)",cn);
                cm.Parameters.AddWithValue("@marcaEquipo", marcaEquipo.NombreMarcaEquipo);
                cn.Open();
                adapter.InsertCommand = cm;
                adapter.InsertCommand.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un marcaEquipo
        public string actualizarMarcaEquipo(MarcaEquipo marcaEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE MarcaEquipo SET marcaEquipo=@marcaEquipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", marcaEquipo.Id);
                cm.Parameters.AddWithValue("@nombre", marcaEquipo.NombreMarcaEquipo);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar MarcaEquipo
        public string deleteMarcaEquipo(int idMarcaEquipo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM MarcaEquipo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idMarcaEquipo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        //obtener id grupo   
        public Grupo selectGrupoId(int Id)
        {
            cn.ConnectionString = myConnection();
            Grupo grupo = new Grupo();
            try
            {
                cm = new SqlCommand($"Select * from Grupo Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    grupo.Id = (int)dt.Rows[0]["Id"];
                    grupo.nombre = Convert.ToString(dt.Rows[0]["nombre"]);

                }
                return grupo;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return grupo;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener grupo
        public List<Grupo> TodosLosGrupo()
        {
            cn.ConnectionString = myConnection();
            List<Grupo> grup = new List<Grupo>();

            try
            {
                cm = new SqlCommand($"Select * from Grupo");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Grupo grupos = new Grupo();
                        grupos.Id = (int)dt.Rows[0]["Id"];
                        grupos.nombre = Convert.ToString(dt.Rows[0]["nombre"]);

                        grup.Add(grupos);
                    }

                }
                return grup;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return grup;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar grupo
        public string insertGrupo(Grupo grupo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Grupo (nombre)values(@nombre)");
                cm.Parameters.AddWithValue("@nombre", grupo.nombre);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un grupo
        public string actualizarGrupo(Grupo grupo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Grupo SET nombre=@nombre WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", grupo.Id);
                cm.Parameters.AddWithValue("@nombre", grupo.nombre);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Grupo
        public string deleteGrupo(int idGrupo)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Grupo WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idGrupo);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        //obtener id Inventario   
        public Inventario selectInventarioId(int Id)
        {
            cn.ConnectionString = myConnection();
            Inventario inventario = new Inventario();
            try
            {
                cm = new SqlCommand($"Select * from Inventario Where Id_inventario = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    inventario.Id_inventario = (int)dt.Rows[0]["Id"];
                    inventario.producto = (int)dt.Rows[0]["producto"];
                    inventario.cantidad = (int)dt.Rows[0]["cantidad"];
                    inventario.tipo = Convert.ToString(dt.Rows[0]["tipo"]);
                    inventario.fecha_inventario = Convert.ToDateTime(dt.Rows[0]["fecha_inventario"]);
                }
                return inventario;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return inventario;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener Inventario
        public List<Inventario> TodosLosInventario()
        {
            cn.ConnectionString = myConnection();
            List<Inventario> inv = new List<Inventario>();

            try
            {
                cm = new SqlCommand($"Select * from Inventario");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Inventario inventario = new Inventario();
                        inventario.Id_inventario = (int)dt.Rows[0]["Id_inventario"];
                        inventario.producto = (int)dt.Rows[0]["producto"];
                        inventario.cantidad = (int)dt.Rows[0]["cantidad"];
                        inventario.tipo = Convert.ToString(dt.Rows[0]["tipo"]);
                        inventario.fecha_inventario = Convert.ToDateTime(dt.Rows[0]["fecha_inventario"]);
                        inv.Add(inventario);
                    }

                }
                return inv;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return inv;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Inventario
        public string insertInventario(Inventario inventario)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Inventario (producto,cantidad,tipo,fecha_inventario)values(@producto,@cantidad,@tipo,@fecha_inventario)");
                cm.Parameters.AddWithValue("@producto", inventario.producto);
                cm.Parameters.AddWithValue("@cantidad", inventario.cantidad);
                cm.Parameters.AddWithValue("@tipo", inventario.tipo);
                cm.Parameters.AddWithValue("@fecha_inventario", inventario.fecha_inventario.ToString("yyyy/MM/dd"));
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un inventario
        public string actualizarInventario(Inventario inventario)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Inventario SET producto=@producto,cantidad=@cantidad,tipo=@tipo,fecha_inventario=@fecha_inventario WHERE Id_inventario = @Id  ", cn);
                cm.Parameters.AddWithValue("@", inventario.Id_inventario);
                cm.Parameters.AddWithValue("@producto", inventario.producto);
                cm.Parameters.AddWithValue("@cantidad", inventario.cantidad);
                cm.Parameters.AddWithValue("@tipo", inventario.tipo);
                cm.Parameters.AddWithValue("@fecha_inventario", inventario.fecha_inventario.ToString("yyyy/MM/dd"));
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Inventario
        public string deleteInventario(int idInventario)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM inventario WHERE Id_inventario = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idInventario);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        public List<Marcas> TodosLasMarcas()
        {
            cn.ConnectionString = myConnection();
            List<Marcas> marca = new List<Marcas>();

            try
            {
                cm = new SqlCommand($"Select * from Marcas");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Marcas marcas = new Marcas();
                        marcas.Id = (int)dt.Rows[0]["Id"];
                        marcas.Nombre = Convert.ToString(dt.Rows[0]["marca"]);

                        marca.Add(marcas);
                    }

                }
                return marca;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return marca;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener id marcas   
        public Marcas selectMarcasId(int Id)
        {
            cn.ConnectionString = myConnection();
            Marcas marca = new Marcas();
            try
            {
                cm = new SqlCommand($"Select * from Marcas Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    marca.Id = (int)dt.Rows[0]["Id"];
                    marca.Nombre = Convert.ToString(dt.Rows[0]["marca"]);
                }
                return marca;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return marca;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener marcas
        public List<TipoEquipo> TodosLosTipoEquipos()
        {
            cn.ConnectionString = myConnection();
            List<TipoEquipo> tipoEquipos = new List<TipoEquipo>();

            try
            {
                cm = new SqlCommand($"Select * from TipoEquipo");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        TipoEquipo tipoEquipo = new TipoEquipo();
                        tipoEquipo.Id = (int)dt.Rows[0]["Id"];
                        tipoEquipo.tipoEquipo = Convert.ToString(dt.Rows[0]["tipoEquipo"]);

                        tipoEquipos.Add(tipoEquipo);
                    }

                }
                return tipoEquipos;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tipoEquipos;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar marca
        public string insertMarca(Marcas marca)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Marcas (marca)values(@marca)");
                cm.Parameters.AddWithValue("@marca", marca.Nombre);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una marca
        public string actualizarMarca(Marcas marca)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Marcas SET marca=@marca WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", marca.Id);
                cm.Parameters.AddWithValue("@marca", marca.Nombre);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar marcas
        public string deleteMarca(int idMarca)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Marcas WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idMarca);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        //obtener id proovedores   
        public Provedeedores selectProovedoresId(int Id)
        {
            cn.ConnectionString = myConnection();
            Provedeedores provedeedores = new Provedeedores();
            try
            {
                cm = new SqlCommand($"Select * from [Proveedores] Where id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    provedeedores.Id = (int)dt.Rows[0]["Id"];
                    provedeedores.proveedor = Convert.ToString(dt.Rows[0]["proovedor"]);
                    provedeedores.direccion = Convert.ToString(dt.Rows[0]["direccion"]);
                    provedeedores.contactPerson = Convert.ToString(dt.Rows[0]["contactPerson"]);
                    provedeedores.telefono = Convert.ToString(dt.Rows[0]["telefono"]);
                    provedeedores.email = Convert.ToString(dt.Rows[0]["email"]);
                    provedeedores.fax = Convert.ToString(dt.Rows[0]["fax"]);
                    provedeedores.RazonSocial = Convert.ToString(dt.Rows[0]["RazonSocial"]);
                    provedeedores.cedulaRuc = Convert.ToString(dt.Rows[0]["cedulaRuc"]);
                    provedeedores.DiasCredito = (int)dt.Rows[0]["DiasCredito"];
                    provedeedores.estado = Convert.ToString(dt.Rows[0]["estado"]);
                    provedeedores.ciudad = Convert.ToString(dt.Rows[0]["ciudad"]);
                    provedeedores.pais = Convert.ToString(dt.Rows[0]["pais"]);
                    provedeedores.provincia = Convert.ToString(dt.Rows[0]["provincia"]);
                    provedeedores.codPostal = Convert.ToString(dt.Rows[0]["codPostal"]);
                    provedeedores.paginaWeb = Convert.ToString(dt.Rows[0]["paginaWeb"]);

                }
                return provedeedores;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return provedeedores;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectProveedorDataPorId(int Id)
        {
            DataSet dt = new DataSet();
            cn.ConnectionString = myConnection();
            Usuarios usuarios = new Usuarios();
            try
            {
                cm = new SqlCommand($"Select * from [Proveedores] Where Id = {Id}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();

                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return dt;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener proovedores
        public List<Provedeedores> TodosLosProovedores()
        {
            cn.ConnectionString = myConnection();
            List<Provedeedores> prov = new List<Provedeedores>();

            try
            {
                cm = new SqlCommand($"Select * from Proveedores");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Provedeedores provedeedores = new Provedeedores();
                        provedeedores.Id = (int)dt.Rows[0]["Id"];
                        provedeedores.proveedor = Convert.ToString(dt.Rows[0]["proveedor"]);
                        provedeedores.direccion = Convert.ToString(dt.Rows[0]["direccion"]);
                        provedeedores.contactPerson = Convert.ToString(dt.Rows[0]["contactPerson"]);
                        provedeedores.telefono = Convert.ToString(dt.Rows[0]["telefono"]);
                        provedeedores.email = Convert.ToString(dt.Rows[0]["email"]);
                        provedeedores.fax = Convert.ToString(dt.Rows[0]["fax"]);
                        provedeedores.RazonSocial = Convert.ToString(dt.Rows[0]["RazonSocial"]);
                        provedeedores.cedulaRuc = Convert.ToString(dt.Rows[0]["cedulaRuc"]);
                        provedeedores.DiasCredito = (int)dt.Rows[0]["DiasCredito"];
                        provedeedores.estado = Convert.ToString(dt.Rows[0]["estado"]);
                        provedeedores.ciudad = Convert.ToString(dt.Rows[0]["ciudad"]);
                        provedeedores.pais = Convert.ToString(dt.Rows[0]["pais"]);
                        provedeedores.provincia = Convert.ToString(dt.Rows[0]["provincia"]);
                        provedeedores.codPostal = Convert.ToString(dt.Rows[0]["codPostal"]);
                        provedeedores.paginaWeb = Convert.ToString(dt.Rows[0]["paginaWeb"]);
                        prov.Add(provedeedores);
                    }

                }
                return prov;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return prov;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Proveedores
        public string insertProveedores(Provedeedores provedeedores)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Proveedores (proveedor,direccion,contactPerson,telefono,email,fax,RazonSocial,cedulaRuc,DiasCredito,estado,ciudad,pais,provincia,codPostal,paginaWeb)values(@proveedor,@direccion,@contactPerson,@telefono,@email,@fax,@RazonSocial,@cedulaRuc,@DiasCredito,@estado,@ciudad,@pais,@provincia,@codPostal,@paginaWeb)", cn);
                cm.Parameters.AddWithValue("@proveedor", provedeedores.proveedor);
                cm.Parameters.AddWithValue("@direccion", provedeedores.direccion);
                cm.Parameters.AddWithValue("@contactPerson", provedeedores.contactPerson);
                cm.Parameters.AddWithValue("@telefono", provedeedores.telefono);
                cm.Parameters.AddWithValue("@email", provedeedores.email);
                cm.Parameters.AddWithValue("@fax", provedeedores.fax);
                cm.Parameters.AddWithValue("@RazonSocial", provedeedores.RazonSocial);
                cm.Parameters.AddWithValue("@cedulaRuc", provedeedores.cedulaRuc);
                cm.Parameters.AddWithValue("@DiasCredito", provedeedores.DiasCredito);
                cm.Parameters.AddWithValue("@estado", provedeedores.estado);
                cm.Parameters.AddWithValue("@ciudad", provedeedores.ciudad);
                cm.Parameters.AddWithValue("@pais", provedeedores.pais);
                cm.Parameters.AddWithValue("@codPostal", provedeedores.codPostal);
                cm.Parameters.AddWithValue("@paginaWeb", provedeedores.paginaWeb);
                cm.Parameters.AddWithValue("@estado", provedeedores.estado);

                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar un proveedores
        public string actualizarProveedores(Provedeedores provedeedores)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Proveedores SET proveedor=@proveedor,direccion=@direccion,contactPerson=@contactPerson,telefono=@telefono,email=@email,fax=@fax,RazonSocial=@RazonSocial,cedulaRuc=@cedulaRuc,DiasCredito=@DiasCredito,estado=@estado,ciudad=@ciudad,pais=@pais,provincia=@provincia,codPostal=@codPostal,paginaWeb=@paginaWeb WHERE Id_inventario = @Id  ", cn);
                cm.Parameters.AddWithValue("@", provedeedores.Id);
                cm.Parameters.AddWithValue("@proveedor", provedeedores.proveedor);
                cm.Parameters.AddWithValue("@direccion", provedeedores.direccion);
                cm.Parameters.AddWithValue("@contactPerson", provedeedores.contactPerson);
                cm.Parameters.AddWithValue("@telefono", provedeedores.telefono);
                cm.Parameters.AddWithValue("@email", provedeedores.email);
                cm.Parameters.AddWithValue("@fax", provedeedores.fax);
                cm.Parameters.AddWithValue("@RazonSocial", provedeedores.RazonSocial);
                cm.Parameters.AddWithValue("@cedulaRuc", provedeedores.cedulaRuc);
                cm.Parameters.AddWithValue("@DiasCredito", provedeedores.DiasCredito);
                cm.Parameters.AddWithValue("@estado", provedeedores.estado);
                cm.Parameters.AddWithValue("@ciudad", provedeedores.ciudad);
                cm.Parameters.AddWithValue("@pais", provedeedores.pais);
                cm.Parameters.AddWithValue("@provincia", provedeedores.provincia);
                cm.Parameters.AddWithValue("@codPostal", provedeedores.codPostal);
                cm.Parameters.AddWithValue("@paginaWeb", provedeedores.paginaWeb);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Proveedores
        public string deleteProveedores(int idProveedor)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Proveedores WHERE Id_inventario = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idProveedor);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        //obtener id Tiendas  
        public Tiendas selectTiendasId(int Id)
        {
            cn.ConnectionString = myConnection();
            Tiendas tienda = new Tiendas();
            try
            {
                cm = new SqlCommand($"Select * from Tiendas Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    tienda.Id = (int)dt.Rows[0]["Id"];
                    tienda.store = Convert.ToString(dt.Rows[0]["store"]);
                    tienda.address = Convert.ToString(dt.Rows[0]["address"]);
                }
                return tienda;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tienda;
            }
            finally
            {
                cn.Close();
            }
        }
        public DataSet selectTiendasDataId(int Id)
        {
            cn.ConnectionString = myConnection();
            DataSet tienda = new DataSet();
            try
            {
                cm = new SqlCommand($"Select * from Tiendas Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tienda;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener Tiendas
        public List<Tiendas> TodosLasTiendas()
        {
            cn.ConnectionString = myConnection();
            List<Tiendas> tiendas = new List<Tiendas>();

            try
            {
                cm = new SqlCommand($"Select * from Tiendas", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Tiendas tienda = new Tiendas();
                        tienda.Id = (int)dt.Rows[0]["Id"];
                        tienda.store = Convert.ToString(dt.Rows[0]["store"]);
                        tienda.address = Convert.ToString(dt.Rows[0]["address"]);
                        tiendas.Add(tienda);
                    }

                }
                return tiendas;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return tiendas;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar tiendas
        public string insertTiendas(Tiendas tienda)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Tiendas (store,address)values(@store,@address)", cn);
                cm.Parameters.AddWithValue("@store", tienda.store);
                cm.Parameters.AddWithValue("@address", tienda.address);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una tienda
        public string actualizarTienda(Tiendas tienda)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Tiendas SET store=@store,address=@address WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", tienda.Id);
                cm.Parameters.AddWithValue("@store", tienda.store);
                cm.Parameters.AddWithValue("@address", tienda.address);
                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar tiendas
        public string deleteTTiendas(int idTienda)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Tiendas WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idTienda);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }

        //obtener id Venta  
        public Venta selectVentasId(int Id)
        {
            cn.ConnectionString = myConnection();
            Venta venta = new Venta();
            try
            {
                cm = new SqlCommand($"Select * from Venta Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    venta.Id_venta = (int)dt.Rows[0]["Id"];
                    venta.numero = (int)dt.Rows[0]["numero"];
                    venta.Idcliente = (int)dt.Rows[0]["cliente"];
                    venta.Idusuario = (int)dt.Rows[0]["usuario"];
                    venta.fecha_venta = Convert.ToDateTime(dt.Rows[0]["fecha_venta"]);
                    venta.total = Convert.ToDecimal(dt.Rows[0]["total"]);
                    venta.iva = Convert.ToDecimal(dt.Rows[0]["iva"]);
                    venta.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"]);
                    venta.descuento = Convert.ToDecimal(dt.Rows[0]["total"]);

                }
                return venta;

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return venta;
            }
            finally
            {
                cn.Close();
            }
        }

        //obtener ventas
        public List<Venta> TodosLasVentas()
        {
            cn.ConnectionString = myConnection();
            List<Venta> ventas = new List<Venta>();

            try
            {
                cm = new SqlCommand($"Select * from Venta", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Venta venta = new Venta();
                        venta.Id_venta = (int)dt.Rows[0]["Id"];
                        venta.numero = (int)dt.Rows[0]["numero"];
                        venta.Idcliente = (int)dt.Rows[0]["cliente"];
                        venta.Idusuario = (int)dt.Rows[0]["usuario"];
                        venta.fecha_venta = Convert.ToDateTime(dt.Rows[0]["fecha_venta"]);
                        venta.total = Convert.ToDecimal(dt.Rows[0]["total"]);
                        venta.iva = Convert.ToDecimal(dt.Rows[0]["iva"]);
                        venta.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"]);
                        venta.descuento = Convert.ToDecimal(dt.Rows[0]["total"]);

                        ventas.Add(venta);
                    }

                }
                return ventas;
            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return ventas;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar Ventas
        //all views
        public string insertVentas(Venta venta)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Venta (numero,cliente,usuario,fecha_venta,total,iva,subtotal,descuento)values(@numero,@cliente,@usuario,@fecha_venta,@total,@iva,@subtotal,@descuento)", cn);
                cm.Parameters.AddWithValue("@numero", venta.numero);
                cm.Parameters.AddWithValue("@cliente", venta.Idcliente);
                cm.Parameters.AddWithValue("@usuario", venta.Idusuario);
                cm.Parameters.AddWithValue("@fecha_venta", venta.fecha_venta.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@total", venta.total);
                cm.Parameters.AddWithValue("@iva", venta.iva);
                cm.Parameters.AddWithValue("@subtotal", venta.subtotal);
                cm.Parameters.AddWithValue("@descuento", venta.descuento);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar una venta
        public string actualizaVenta(Venta venta)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Venta SET numero=@numero,cliente=@cliente,usuario=@usuario,fecha_venta=@fecha_venta,total=@total,iva=@iva,subtotal=@subtotal,descuento=@descuento WHERE Id_venta = @Id  ", cn);
                cm.Parameters.AddWithValue("@", venta.Id_venta);
                cm.Parameters.AddWithValue("@numero", venta.numero);
                cm.Parameters.AddWithValue("@cliente", venta.Idcliente);
                cm.Parameters.AddWithValue("@usuario", venta.Idusuario);
                cm.Parameters.AddWithValue("@fecha_venta", venta.fecha_venta.ToString("yyyy/MM/dd"));
                cm.Parameters.AddWithValue("@total", venta.total);
                cm.Parameters.AddWithValue("@iva", venta.iva);
                cm.Parameters.AddWithValue("@subtotal", venta.subtotal);
                cm.Parameters.AddWithValue("@descuento", venta.descuento);


                cn.Open();
                adapter.UpdateCommand = cm;
                adapter.UpdateCommand.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar Venta
        public string deleteVenta(int idVenta)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Venta WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", idVenta);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }


        // Combos
        public string insertCombo(int idProducto,int idProductoRelacionado)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into [ComboDeProductos] (idProducto,IdProductosRelacionados) values(@idProducto,@idProductoRelacionado)", cn);
                cm.Parameters.AddWithValue("@idProducto", idProducto);
                cm.Parameters.AddWithValue("@idProductoRelacionado", idProductoRelacionado);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;

            }

            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        public string deleteCombo(int IdProducto ,int idProductoRelacionado)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM [dbo].[ComboDeProductos] WHERE [IdProducto]=@IdProducto and [IdProductosRelacionados] = @idProductoRelacionado", cn);
                cm.Parameters.AddWithValue("@IdProducto", IdProducto);
                cm.Parameters.AddWithValue("@idProductoRelacionado", idProductoRelacionado);
                cn.Open();
                cm.ExecuteNonQuery();
                return Error;
            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }

        }
        public Items selectitemConCombo(int IdProducto)
        {
            Items item = new Items();
            cn.ConnectionString = myConnection();
            List<Items> items = new List<Items>();
            decimal precioA = 0, precioB = 0, precioC = 0, precioD = 0, peso = 0, comision = 0, descMax = 0, costo = 0, ice = 0, valorIce = 0, iva = 0, montoTotal = 0;
            int Id = 0, unidadCaja = 0, stockMax = 0, stockMin = 0, bId = 0, cId = 0, gId = 0, mId = 0, unidad = 0;
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"SELECT [IdProducto],[IdProductosRelacionados] FROM [dbo].[ComboDeProductos] Where [ComboDeProductos].IdProducto = {IdProducto}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
       
                da.Fill(dt);
               

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return item;
            }
            finally
            {
                cn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0]["IdProducto"].ToString(), out Id);
                item = selectItemPorId(Id);
                foreach (DataRow r in dt.Rows)
                {
                    int idCombo = 0;
                    Items itemCombo = new Items();
                    int.TryParse(dt.Rows[0]["IdProductosRelacionados"].ToString(), out idCombo);
                    itemCombo = selectItemPorId(idCombo);
                    items.Add(itemCombo);
                }

            }
            item.Combo = items;
            return item;
        }

        public List<Items> selectCombo(int IdProducto)
        {
            Items item = new Items();
            cn.ConnectionString = myConnection();
            List<Items> items = new List<Items>();
            decimal precioA = 0, precioB = 0, precioC = 0, precioD = 0, peso = 0, comision = 0, descMax = 0, costo = 0, ice = 0, valorIce = 0, iva = 0, montoTotal = 0;
            int Id = 0, unidadCaja = 0, stockMax = 0, stockMin = 0, bId = 0, cId = 0, gId = 0, mId = 0, unidad = 0;
            DataTable dt = new DataTable();
            try
            {
                cm = new SqlCommand($"SELECT [IdProducto],[IdProductosRelacionados] FROM [dbo].[ComboDeProductos] Where [ComboDeProductos].IdProducto = {IdProducto}", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                da.Fill(dt);
               

            }
            catch (Exception ex)
            {
                CrearEvento(ex.ToString());
                return items;
            }
            finally
            {
                cn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int idCombo = 0;
                    Items itemCombo = new Items();
                    int.TryParse(r["IdProductosRelacionados"].ToString(), out idCombo);
                    itemCombo = selectItemPorId(idCombo);
                    itemCombo.categoria=selectCategoriasId(itemCombo.cId);
                    itemCombo.marcas = selectMarcasId(itemCombo.mId);
                    itemCombo.Bodega= selectBodegaId(itemCombo.bId);
                    itemCombo.grupo = selectGrupoId(itemCombo.gId);       
                    items.Add(itemCombo);
             
                }


            }

            item.Combo = items;
            return items;
        }
    }
}