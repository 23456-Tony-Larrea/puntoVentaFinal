using POSalesDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POSalesDB
{
    public class DBConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string con;
        public string myConnection()
        {
            con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\avsla\Documents\DBPOSale.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
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
                return usuario;
                cn.Close();
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
            cm = new SqlCommand("SELECT password FROM tbUser WHERE username = '" + username + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
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
            cm = new SqlCommand("BEGIN TRANSACTION;", cn);
            cn.Open();      
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void commitTransaction()
        {

            cn = new SqlConnection();
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("COMMIT;", cn);
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
                    item.codigoUno = dt.Rows[0]["codigoUno"].ToString();
                    item.codigoDos = dt.Rows[0]["codigoDos"].ToString();
                    item.codigoTres = dt.Rows[0]["codigoTres"].ToString();
                    item.codigoCuatro = dt.Rows[0]["codigoCuatro"].ToString();
                    item.codigoBarras = dt.Rows[0]["codigoBarras"].ToString();
                    item.precioA = (decimal)dt.Rows[0]["precioA"];
                    item.precioB = (decimal)dt.Rows[0]["precioB"];
                    item.precioC = (decimal)dt.Rows[0]["precioC"];
                    item.precioD = (decimal)dt.Rows[0]["precioD"];
                    item.descripcion = dt.Rows[0]["descripcion"].ToString();
                    item.unidadCaja = (int)dt.Rows[0]["unidadCaja"];
                    item.peso = (decimal)dt.Rows[0]["peso"];
                    item.comision = (decimal)dt.Rows[0]["comision"];
                    item.descMax = (decimal)dt.Rows[0]["descMax"];
                    item.stockMax = (int)dt.Rows[0]["stockMax"];
                    item.stockMin = (int)dt.Rows[0]["stockMin"];
                    item.costo = (decimal)dt.Rows[0]["costo"];
                    item.unidad = (int)dt.Rows[0]["unidad"];
                    item.bId = (int)dt.Rows[0]["bId"];
                    item.cId = (int)dt.Rows[0]["cId"];
                    item.gId = (int)dt.Rows[0]["gId"];
                    item.mId = (int)dt.Rows[0]["mId"];
                    item.servicio = (bool)dt.Rows[0]["servicio"];
                    item.aplicaSeries = (bool)dt.Rows[0]["aplicaSeries"];
                    item.negativo = (bool)dt.Rows[0]["negativo"];
                    item.combo = (bool)dt.Rows[0]["combo"];
                    item.gasto = (bool)dt.Rows[0]["gasto"];
                    item.ice = (decimal)dt.Rows[0]["ice"];
                    item.valorIce = (decimal)dt.Rows[0]["valorIce"];
                    item.HasIva = (bool)dt.Rows[0]["HasIva"];
                    item.iva = (decimal)dt.Rows[0]["iva"];
                    item.imagen = (byte[])dt.Rows[0]["imagen"];
                    item.descripcion = dt.Rows[0]["imagenUrl"].ToString();
                    item.montoTotal = (decimal)dt.Rows[0]["montoTotal"];
                    item.categoriaA = dt.Rows[0]["categoriaA"].ToString();
                    item.categoriaB = dt.Rows[0]["categoriaB"].ToString();
                    item.categoriaC = dt.Rows[0]["categoriaC"].ToString();
                    item.categoriaD = dt.Rows[0]["categoriaD"].ToString();
                    item.categoriaE = dt.Rows[0]["categoriaE"].ToString();
                }
                cm.ExecuteNonQuery();
                return item;

            }
            catch (Exception ex)
            {
                return item;
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
                        item.Id = (int)r["Id"];
                        item.nombre = r["nombre"].ToString();
                        item.codigoUno = r["codigoUno"].ToString();
                        item.codigoDos = r["codigoDos"].ToString();
                        item.codigoTres = r["codigoTres"].ToString();
                        item.codigoCuatro = r["codigoCuatro"].ToString();
                        item.codigoBarras = r["codigoBarras"].ToString();
                        item.precioA = (decimal)r["precioA"];
                        item.precioB = (decimal)r["precioB"];
                        item.precioC = (decimal)r["precioC"];
                        item.precioD = (decimal)r["precioD"];
                        item.descripcion = r["descripcion"].ToString();
                        item.unidadCaja = (int)r["unidadCaja"];
                        item.peso = (decimal)r["peso"];
                        item.comision = (decimal)r["comision"];
                        item.descMax = (decimal)r["descMax"];
                        item.stockMax = (int)r["stockMax"];
                        item.stockMin = (int)r["stockMin"];
                        item.costo = (decimal)r["costo"];
                        item.unidad = (int)r["unidad"];
                        item.bId = (int)r["bId"];
                        item.cId = (int)r["cId"];
                        item.gId = (int)r["gId"];
                        item.mId = (int)r["mId"];
                        item.servicio = (bool)r["servicio"];
                        item.aplicaSeries = (bool)r["aplicaSeries"];
                        item.negativo = (bool)r["negativo"];
                        item.combo = (bool)r["combo"];
                        item.gasto = (bool)r["gasto"];
                        item.ice = (decimal)r["ice"];
                        item.valorIce = decimal.Parse(r["valorIce"].ToString());
                        item.HasIva = bool.Parse(r["HasIva"].ToString());
                        item.iva = (decimal)r["iva"];
                        item.imagen = Encoding.ASCII.GetBytes(r["imagen"].ToString());
                        item.descripcion = r["imagenUrl"].ToString();
                        item.montoTotal = (decimal)r["montoTotal"];
                        item.categoriaA = r["categoriaA"].ToString();
                        item.categoriaB = r["categoriaB"].ToString();
                        item.categoriaC = r["categoriaC"].ToString();
                        item.categoriaD = r["categoriaD"].ToString();
                        item.categoriaE = r["categoriaE"].ToString();
                        items.Add(item);
                    }

                }
                cm.ExecuteNonQuery();
                return items;

            }
            catch (Exception ex)
            {
                return items;
            }
            finally
            {
                cn.Close();
            }
        }
        ///------ SECCION PARA NSERT ITEMS --------------
        public string insertItem(Items item)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Items (nombre,codigoUno,codigoDos,codigoTres,codigoCuatro,codigoBarras,precioA,precioB,precioC,precioD,descripcion,unidadCaja,peso,comision,descMax,stockMin,stockMax,costo,unidad,bId,cId,gId,mId,servicio,aplicaSeries,negativo,combo,gasto,ice,valorIce,imagen,imagenUrl,iva,montoTotal,HasIva,categoriaA,categoriaB,categoriaC,categoriaD,categoriaE values(@nombre,@codigoUno,@codigoDos,@codigoTres,@codigoCuatro,@codigoBarras,@precioA,@precioB,@precioC,@precioD,@descripcion,@unidadCaja,@peso,@comision,@descMax,@stockMin,@stockMax,@costo,@unidad,@bId,@cId,@gId,@mId,@servicio,@aplicaSeries,@negativo,@combo,@gasto,@ice,@valorIce,@imagen,@imagenUrl,@iva,@montoTotal,@HasIva,@categoriaA,@categoriaB,@categoriaC,@categoriaD,@categoriaE))");
                cm.Parameters.AddWithValue("@nombre", item.nombre);
                cm.Parameters.AddWithValue("@codigoUno", item.codigoUno);
                cm.Parameters.AddWithValue("@codigoDos", item.codigoDos);
                cm.Parameters.AddWithValue("@codigoTres", item.codigoTres);
                cm.Parameters.AddWithValue("@codigoCuatro", item.codigoCuatro);
                cm.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                cm.Parameters.AddWithValue("@precioA", item.precioA);
                cm.Parameters.AddWithValue("@precioB", item.precioB);
                cm.Parameters.AddWithValue("@precioC", item.precioC);
                cm.Parameters.AddWithValue("@precioD", item.precioD);
                cm.Parameters.AddWithValue("@descripcion", item.descripcion);
                cm.Parameters.AddWithValue("@unidadCaja", item.unidadCaja);
                cm.Parameters.AddWithValue("@peso", item.peso);
                cm.Parameters.AddWithValue("@comision", item.comision);
                cm.Parameters.AddWithValue("@descMax", item.descMax);
                cm.Parameters.AddWithValue("@stockMax", item.stockMax);
                cm.Parameters.AddWithValue("@stockMin", item.stockMin);
                cm.Parameters.AddWithValue("@costo", item.costo);
                cm.Parameters.AddWithValue("@unidad", item.unidad);
                cm.Parameters.AddWithValue("@bId", item.bId);
                cm.Parameters.AddWithValue("@cId", item.cId);
                cm.Parameters.AddWithValue("@gId", item.gId);
                cm.Parameters.AddWithValue("@mId", item.mId);
                cm.Parameters.AddWithValue("@servicio", item.servicio);
                cm.Parameters.AddWithValue("@aplicaSeries", item.aplicaSeries);
                cm.Parameters.AddWithValue("@negativo", item.negativo);
                cm.Parameters.AddWithValue("@combo", item.combo);
                cm.Parameters.AddWithValue("@gasto", item.gasto);
                cm.Parameters.AddWithValue("@ice", item.ice);
                cm.Parameters.AddWithValue("@valorIce", item.valorIce);
                cm.Parameters.AddWithValue("@HasIva", item.HasIva);
                cm.Parameters.AddWithValue("@iva", item.iva);
                cm.Parameters.AddWithValue("@imagen", item.imagen);
                cm.Parameters.AddWithValue("@imagenUrl", item.descripcion);
                cm.Parameters.AddWithValue("@montoTotal", item.precioA * item.precioB);
                cm.Parameters.AddWithValue("@categoriaA", item.categoriaA);
                cm.Parameters.AddWithValue("@categoriaB", item.categoriaB);
                cm.Parameters.AddWithValue("@categoriaC", item.categoriaC);
                cm.Parameters.AddWithValue("@categoriaD", item.categoriaD);
                cm.Parameters.AddWithValue("@categoriaE", item.categoriaE);
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
        ///------ SECCION PARA UPDATE ITEMS --------------
        public string actualizarItem(Items item)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Items SET nombre=@nombre,codigoUno=@codigoUno,codigoDos=@codigoDos,codigoTres=@codigoTres,codigoCuatro=@codigoCuatro,precioA=@precioA,precioB=@precioB,precioC=@precioC,precioD=@precioD,descripcion=@descripcion,unidadCaja=@unidadCaja,peso=@peso,comision=@comision,descMax=@descMax,stockMin=@stockMin,stockMax=@stockMax,costo=@costo,unidad=@unidad,bId=@bId,cId=@cId ,gId=@gId,mId=@mId,servicio=@servicio,aplicaSeries=@aplicaSeries,negativo=@negativo,combo=@combo,gasto=@gasto,ice=@ice,valorIce=@valorIce,imagen=@imagen,imagenUrl=@imagenUrl,iva=@iva,montoTotal=@montoTotal,HasIva=HasIva,categoriaA=@categoriaA,categoriaB=@categoriaB,categoriaC=@categoriaC,categoriaD=@categoriaD,categoriaE=@categoriaE  WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@Id", item.Id);
                cm.Parameters.AddWithValue("@nombre", item.nombre);
                cm.Parameters.AddWithValue("@codigoUno", item.codigoUno);
                cm.Parameters.AddWithValue("@codigoDos", item.codigoDos);
                cm.Parameters.AddWithValue("@codigoTres", item.codigoTres);
                cm.Parameters.AddWithValue("@codigoCuatro", item.codigoCuatro);
                cm.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                cm.Parameters.AddWithValue("@precioA", item.precioA);
                cm.Parameters.AddWithValue("@precioB", item.precioB);
                cm.Parameters.AddWithValue("@precioC", item.precioC);
                cm.Parameters.AddWithValue("@precioD", item.precioD);
                cm.Parameters.AddWithValue("@descripcion", item.descripcion);
                cm.Parameters.AddWithValue("@unidadCaja", item.unidadCaja);
                cm.Parameters.AddWithValue("@peso", item.peso);
                cm.Parameters.AddWithValue("@comision", item.comision);
                cm.Parameters.AddWithValue("@descMax", item.descMax);
                cm.Parameters.AddWithValue("@stockMax", item.stockMax);
                cm.Parameters.AddWithValue("@stockMin", item.stockMin);
                cm.Parameters.AddWithValue("@costo", item.costo);
                cm.Parameters.AddWithValue("@unidad", item.unidad);
                cm.Parameters.AddWithValue("@bId", item.bId);
                cm.Parameters.AddWithValue("@cId", item.cId);
                cm.Parameters.AddWithValue("@gId", item.gId);
                cm.Parameters.AddWithValue("@mId", item.mId);
                cm.Parameters.AddWithValue("@servicio", item.servicio);
                cm.Parameters.AddWithValue("@aplicaSeries", item.aplicaSeries);
                cm.Parameters.AddWithValue("@negativo", item.negativo);
                cm.Parameters.AddWithValue("@combo", item.combo);
                cm.Parameters.AddWithValue("@gasto", item.gasto);
                cm.Parameters.AddWithValue("@ice", item.ice);
                cm.Parameters.AddWithValue("@valorIce", item.valorIce);
                cm.Parameters.AddWithValue("@HasIva", item.HasIva);
                cm.Parameters.AddWithValue("@iva", item.iva);
                cm.Parameters.AddWithValue("@imagen", item.imagen);
                cm.Parameters.AddWithValue("@imagenUrl", item.descripcion);
                cm.Parameters.AddWithValue("@montoTotal", item.precioA * item.precioB);
                cm.Parameters.AddWithValue("@categoriaA", item.categoriaA);
                cm.Parameters.AddWithValue("@categoriaB", item.categoriaB);
                cm.Parameters.AddWithValue("@categoriaC", item.categoriaC);
                cm.Parameters.AddWithValue("@categoriaD", item.categoriaD);
                cm.Parameters.AddWithValue("@categoriaE", item.categoriaE);
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
                cm.Parameters.AddWithValue("@", idItem);
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
        //get Usuarios Id
        public Usuarios selectUsuariosPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Usuarios usuarios = new Usuarios();
            try
            {
                cm = new SqlCommand($"Select * from Usuarios Where Id = {Id}");
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
                cm.ExecuteNonQuery();
                return usuarios;

            }
            catch (Exception ex)
            {
                return usuarios;
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
                        usuario.Id = (int)r["Id"];
                        usuario.nombre = r["nombre"].ToString();
                        usuario.role = r["role"].ToString();
                        usuario.isactive = Convert.ToBoolean(r["isactive"].ToString());
                        usuarios.Add(usuario);
                    }

                }
                cm.ExecuteNonQuery();
                return usuarios;
            }

            catch (Exception ex)
            {
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
                cm = new SqlCommand("Insert into Usuarios (username,contraseña,role,nombre,isactive values(@username,@contraseña,@role,@nombre,@isactive))");
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
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //actualizar usuario 
        public string actualizarItem(Usuarios usuarios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Usuarios SET username=@username,contraseña=@contraseña,nombre=nombre,role=@role,isactive=@isactive WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", usuarios.Id);
                cm.Parameters.AddWithValue("@nombre", usuarios.nombre);
                cm.Parameters.AddWithValue("@contraseña", usuarios.contraseña);
                cm.Parameters.AddWithValue("@role", usuarios.role);
                cm.Parameters.AddWithValue("@nombre", usuarios.role);
                cm.Parameters.AddWithValue("@isactive", usuarios.isactive);
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
        //eliminar usuarios
        public string deleteUsers(int idUsuarios)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM usuarios WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idUsuarios);
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
        //get ajustamiento id
        public Ajustamiento selectAjustamientosPorId(int Id)
        {
            cn.ConnectionString = myConnection();
            Ajustamiento ajustamiento = new Ajustamiento();
            try
            {
                cm = new SqlCommand($"Select * from Ajustamiento Where Id = {Id}");
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
                cm.ExecuteNonQuery();
                return ajustamiento;

            }
            catch (Exception ex)
            {
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
                        ajustamiento.Id = (int)r["Id"];
                        ajustamiento.referenceno = r["referenceno"].ToString();
                        ajustamiento.pcode = r["pcode"].ToString();
                        ajustamiento.qty =Convert.ToInt32(r["qty"]);
                        ajustamiento.action=r["action"].ToString();
                        ajustamiento.remarks = r["remarks"].ToString();
                        ajustamiento.sdate = Convert.ToDateTime(r["sdate"]);
                        ajustamiento.user = r["[user]"].ToString();

                        ajustamientos.Add(ajustamiento);
                    }

                }
                cm.ExecuteNonQuery();
                return ajustamientos;
            }

            catch (Exception ex)
            {
                return ajustamientos;
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
                cm.ExecuteNonQuery();
                return bodegas;

            }
            catch (Exception ex)
            {
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
                        bodegas.Id = (int)r["Id"];
                        bodegas.Nombre = r["nombre"].ToString();
                         bodega.Add(bodegas);
                    }

                }
                cm.ExecuteNonQuery();
                return bodega;
            }

            catch (Exception ex)
            {
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
        //eliminar usuarios
        public string deleteBodegas(int idBodegas)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DETELE FROM Bodega WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idBodegas);
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

    }
}