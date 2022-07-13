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
                    item.imagen = dt.Rows[0]["imagen"].ToString();
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
            decimal precioA = 0, precioB = 0, precioC = 0, precioD = 0, peso = 0, comision = 0, descMax = 0, costo = 0, ice = 0, valorIce = 0, iva = 0, montoTotal = 0;
            int Id = 0, unidadCaja = 0, stockMax = 0, stockMin = 0, bId = 0, cId = 0, gId = 0, mId = 0, unidad = 0;

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
                        item.codigoUno = r["codigoUno"].ToString();
                        item.codigoDos = r["codigoDos"].ToString();
                        item.codigoTres = r["codigoTres"].ToString();
                        item.codigoCuatro = r["codigoCuatro"].ToString();
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
                        int.TryParse(r["unidadCaja"].ToString(), out unidadCaja);
                        item.unidadCaja = unidadCaja;
                        decimal.TryParse(r["peso"].ToString(), out peso);
                        item.peso = peso;
                        decimal.TryParse(r["comision"].ToString(), out comision);
                        item.comision = comision;
                        decimal.TryParse(r["descMax"].ToString(), out descMax);
                        item.descMax = descMax;
                        int.TryParse(r["stockMax"].ToString(), out stockMax);
                        item.stockMax = stockMax;
                        int.TryParse(r["stockMin"].ToString(), out stockMin);
                        item.stockMin = stockMin;
                        item.costo = (decimal)r["costo"];
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
                        item.combo = (bool)r["combo"];
                        item.gasto = (bool)r["gasto"];
                        decimal.TryParse(r["ice"].ToString(), out ice);
                        item.ice = ice;
                        decimal.TryParse(r["valorIce"].ToString(), out valorIce);
                        item.valorIce = valorIce;
                        item.HasIva = bool.Parse(r["HasIva"].ToString());
                        decimal.TryParse(r["iva"].ToString(), out iva);
                        item.iva = iva;
                        item.imagen = r["imagen"].ToString();
                        item.descripcion = r["imagenUrl"].ToString();
                        decimal.TryParse(r["montoTotal"].ToString(), out montoTotal);
                        item.montoTotal = montoTotal;
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
                cm = new SqlCommand("Insert into Items (nombre,codigoUno,codigoDos,codigoTres,codigoCuatro,codigoBarras,precioA,precioB,precioC,precioD,descripcion,unidadCaja,peso,comision,descMax,stockMin,stockMax,costo,unidad,bId,cId,gId,mId,servicio,aplicaSeries,negativo,combo,gasto,ice,valorIce,imagen,imagenUrl,iva,montoTotal,HasIva,categoriaA,categoriaB,categoriaC,categoriaD,categoriaE values(@nombre,@codigoUno,@codigoDos,@codigoTres,@codigoCuatro,@codigoBarras,@precioA,@precioB,@precioC,@precioD,@descripcion,@unidadCaja,@peso,@comision,@descMax,@stockMin,@stockMax,@costo,@unidad,@bId,@cId,@gId,@mId,@servicio,@aplicaSeries,@negativo,@combo,@gasto,@ice,@valorIce,@imagen,@imagenUrl,@iva,@montoTotal,@HasIva,@categoriaA,@categoriaB,@categoriaC,@categoriaD,@categoriaE))", cn);
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
                cm = new SqlCommand("DELETE FROM Items WHERE Id = @Id  ", cn);
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
                cm = new SqlCommand("UPDATE Usuarios SET username=@username,contraseña=@contraseña,nombre=@nombre,role=@role,isactive=@isactive WHERE Id = @Id  ", cn);
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
                cm = new SqlCommand("DELETE FROM usuarios WHERE Id = @Id  ", cn);
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
                        ajustamiento.qty = Convert.ToInt32(r["qty"]);
                        ajustamiento.action = r["action"].ToString();
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
                Error = ex.ToString();
                return Error;
            }
            finally
            {
                cn.Close();
            }
        }
        //eliminar usuarios
        public string deleteItems(int idAjustamiento)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Ajustamiento WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idAjustamiento);
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
                cm = new SqlCommand("Insert into Bodega (nombre) values(@nombre)");
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
        //eliminar bodegas
        public string deleteBodegas(int idBodegas)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Bodega WHERE Id = @Id  ", cn);
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
                cm.ExecuteNonQuery();
                return cancel;

            }
            catch (Exception ex)
            {
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
                cm.ExecuteNonQuery();
                return cancel;
            }

            catch (Exception ex)
            {
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
        //eliminar cancel
        public string deleteCancel(int idCancel)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Bodega WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idCancel);
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
                cm.ExecuteNonQuery();
                return carrito;

            }
            catch (Exception ex)
            {
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
                        carritos.Id = (int)r["Id"];
                        carritos.trasnno = r["nombre"].ToString();
                        carritos.pcode = r["pcode"].ToString();
                        carritos.price = Convert.ToDecimal(r["price"].ToString());
                        carritos.cantidad = (int)r["cantidad"];
                        carritos.disc_percent = Convert.ToDecimal(r["disc_percent"].ToString());
                        carritos.disc = Convert.ToDecimal(r["disc"].ToString());
                        carritos.total = Convert.ToDecimal(r["total"].ToString());
                        carritos.sdate = Convert.ToDateTime(r["sdate"].ToString());
                        carritos.status = r["status"].ToString();
                        carritos.cashier = r["cashier"].ToString();

                        carrito.Add(carritos);
                    }

                }
                cm.ExecuteNonQuery();
                return carrito;
            }

            catch (Exception ex)
            {
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
        public string deleteCarrito(int idCarrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Carrito WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idCarrito);
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
                    categoria.Categoria = dt.Rows[0]["Categoria"].ToString();

                }
                cm.ExecuteNonQuery();
                return categoria;

            }
            catch (Exception ex)
            {
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
                        cat.Id = (int)r["Id"];
                        cat.Categoria = r["Categoria"].ToString();

                        categoria.Add(cat);
                    }

                }
                cm.ExecuteNonQuery();
                return categoria;
            }

            catch (Exception ex)
            {
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
                cm.Parameters.AddWithValue("@Categoria", categoria.Categoria);
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
        //actualizar una Categoria
        public string actualizarCategoria(Categorias categoria)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Categorias SET Categorias=@Categorias WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", categoria.Id);
                cm.Parameters.AddWithValue("@categoria", categoria.Categoria);
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
        //eliminar Categorias
        public string deleteCategorias(int idCarrito)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Categorias WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idCarrito);
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
            Clientes cliente = new Clientes();
            try
            {
                cm = new SqlCommand($"Select * from Clientes Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cliente.Id = (int)dt.Rows[0]["Id"];
                    cliente.nombre = dt.Rows[0]["nombre"].ToString();
                    cliente.comercio = dt.Rows[0]["comercio"].ToString();
                    cliente.codigo = dt.Rows[0]["codigo"].ToString();
                    cliente.fechaNacimiento = Convert.ToDateTime(dt.Rows[0]["fechaNacimiento"].ToString());
                    cliente.fechaRegistro = Convert.ToDateTime(dt.Rows[0]["fechaRegistro"].ToString());
                    cliente.ciudad = dt.Rows[0]["ciudad"].ToString();
                    cliente.tipo = dt.Rows[0]["tipo"].ToString();
                    cliente.ciRuc = dt.Rows[0]["ciRuc"].ToString();
                    cliente.pais = dt.Rows[0]["pais"].ToString();
                    cliente.estado = dt.Rows[0]["estado"].ToString();
                    cliente.direccion = dt.Rows[0]["direccion"].ToString();
                    cliente.telefono = dt.Rows[0]["telefono"].ToString();
                    cliente.celular = dt.Rows[0]["celular"].ToString();
                    cliente.fax = dt.Rows[0]["fax"].ToString();
                    cliente.cargo = dt.Rows[0]["cargo"].ToString();
                    cliente.email = dt.Rows[0]["email"].ToString();
                    cliente.tipoCliente = dt.Rows[0]["tipoCliente"].ToString();

                }
                cm.ExecuteNonQuery();
                return cliente;

            }
            catch (Exception ex)
            {
                return cliente;
            }
            finally
            {
                cn.Close();
            }
        }
        //obtener Clientes
        public List<Clientes> selectTodosLosClientes()
        {
            cn.ConnectionString = myConnection();
            List<Clientes> cliente = new List<Clientes>();

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
                        Clientes cli = new Clientes();
                        cli.Id = (int)r["Id"];
                        cli.nombre = r["nombre"].ToString();
                        cli.comercio = r["comercio"].ToString();
                        cli.codigo = r["codigo"].ToString();
                        cli.fechaNacimiento = Convert.ToDateTime(r["fechaNacimiento"].ToString());
                        cli.fechaRegistro = Convert.ToDateTime(r["fechaRegistro"].ToString());
                        cli.ciudad = r["ciudad"].ToString();
                        cli.tipo = r["tipo"].ToString();
                        cli.ciRuc = r["ciRuc"].ToString();
                        cli.pais = r["pais"].ToString();
                        cli.estado = r["estado"].ToString();
                        cli.direccion = r["direccion"].ToString();
                        cli.telefono = r["telefono"].ToString();
                        cli.celular = r["celular"].ToString();
                        cli.fax = r["fax"].ToString();
                        cli.cargo = r["cargo"].ToString();
                        cli.email = r["email"].ToString();
                        cli.tipoCliente = r["tipoCliente"].ToString();
                        cliente.Add(cli);
                    }

                }
                cm.ExecuteNonQuery();
                return cliente;
            }

            catch (Exception ex)
            {
                return cliente;
            }
            finally
            {
                cn.Close();
            }
        }
        //insertar clientes
        public string insertClientes(Clientes cliente)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Clientes (nombre,comercio,codigo,fechaNacimiento,fechaRegistro,ciudad,tipo,ciRuc,pais,estado,direccion,telefono,celular,fax,cargo,email,tipoCliente values(@nombre,@comercio,@codigo,@fechaNacimiento,@fechaRegistro,@ciudad,@tipo,@ciRuc,@pais,@estado,@direccion,@telefono,@celular,@fax,@cargo,@email,@tipoCliente))");
                cm.Parameters.AddWithValue("@nombre", cliente.nombre);
                cm.Parameters.AddWithValue("@comercio", cliente.comercio);
                cm.Parameters.AddWithValue("@codigo", cliente.codigo);
                cm.Parameters.AddWithValue("@fechaNacimiento", cliente.fechaNacimiento);
                cm.Parameters.AddWithValue("@fechaRegistro", cliente.fechaRegistro);
                cm.Parameters.AddWithValue("@ciudad", cliente.ciudad);
                cm.Parameters.AddWithValue("@tipo", cliente.tipo);
                cm.Parameters.AddWithValue("@ciRuc", cliente.ciRuc);
                cm.Parameters.AddWithValue("@pais", cliente.pais);
                cm.Parameters.AddWithValue("@estado", cliente.estado);
                cm.Parameters.AddWithValue("@direccion", cliente.direccion);
                cm.Parameters.AddWithValue("@telefono", cliente.telefono);
                cm.Parameters.AddWithValue("@celular", cliente.celular);
                cm.Parameters.AddWithValue("@fax", cliente.fax);
                cm.Parameters.AddWithValue("@cargo", cliente.cargo);
                cm.Parameters.AddWithValue("@email", cliente.email);
                cm.Parameters.AddWithValue("@tipoCliente", cliente.tipoCliente);
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
        //actualizar un Cliente
        public string actualizarCliente(Clientes cliente)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Clientes SET nombre=@nombre, comercio=@comercio ,codigo=@codigo, fechaNacimiento=@fechaNacimiento,fechaRegistro=@fechaRegistro,ciudad=@ciudad,tipo=@tipo,ciRuc=@ciRuc,pais=@pais,estado=@estado,direccion=@direccion,telefono=@telefono,celular=@celular,fax=@fax,cargo=@cargo,email=@email,tipoCliente=@tipoCliente  WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", cliente.Id);
                cm.Parameters.AddWithValue("@nombre", cliente.nombre);
                cm.Parameters.AddWithValue("@comercio", cliente.nombre);
                cm.Parameters.AddWithValue("@codigo", cliente.nombre);
                cm.Parameters.AddWithValue("@fechaNacimiento", cliente.nombre);
                cm.Parameters.AddWithValue("@fechaRegistro", cliente.nombre);
                cm.Parameters.AddWithValue("@ciudad", cliente.nombre);
                cm.Parameters.AddWithValue("@tipo", cliente.nombre);
                cm.Parameters.AddWithValue("@ciRuc", cliente.nombre);
                cm.Parameters.AddWithValue("@pais", cliente.nombre);
                cm.Parameters.AddWithValue("@estado", cliente.nombre);
                cm.Parameters.AddWithValue("@direccion", cliente.nombre);
                cm.Parameters.AddWithValue("@telefono", cliente.nombre);
                cm.Parameters.AddWithValue("@celular", cliente.nombre);
                cm.Parameters.AddWithValue("@fax", cliente.fax);
                cm.Parameters.AddWithValue("@cargo", cliente.cargo);
                cm.Parameters.AddWithValue("@email", cliente.email);
                cm.Parameters.AddWithValue("@tipoCliente", cliente.tipoCliente);

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
        //eliminar clientes
        public string deleteClientes(int idCliente)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("DELETE FROM Clientes WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", idCliente);
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
        //esto es un cambio 

    }
}