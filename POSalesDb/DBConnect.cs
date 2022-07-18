using POSalesDb;
using System;
using System.Collections.Generic;
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
        string path = Directory.GetCurrentDirectory();
        private string con;
        public string myConnection()
        {
            con = @"Data Source=localhost;Initial Catalog=C:\USERS\AVSLA\DOCUMENTS\DBPOSALE.MDF;Integrated Security=True";
            return con;
        }

        public string  actualizarvalorStock(int qty , int idItem)
        {

            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand($"Update item set stock = stock + { qty } Where id = { idItem }",cn);
                return Error;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return Error;
            }

        }

        public DataTable SelectTodosLosProveedores()
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand("SELECT * FROM Proveedores", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        public DataTable LoadProduct(string txtSearch)
        {
            cn.ConnectionString = myConnection();
            cm = new SqlCommand($"SELECT p.id, p.Nombre, p.codigoBarras, p.descripcion, b.marca, c.Categoria, p.precioA, p.stock,negativo FROM items AS p left JOIN Marcas AS b ON b.Id = p.bid left JOIN Categorias AS c on c.Id = p.cid WHERE CONCAT(p.Nombre, b.marca, c.Categoria) LIKE '%{txtSearch}%' and (Stock > 0 or negativo = 1)", cn);
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
                cm = new SqlCommand($"SELECT * FROM vwEnStock WHERE refno = '{txtRefNo}' AND status = 'Pending'", cn);
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
                    "@descMax," +
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
                cm.Parameters.AddWithValue("@descMax", item.descMax);
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
                cm.Parameters.AddWithValue("@descMax", item.descMax);
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
                    categoria.Categoria = dt.Rows[0]["Categoria"].ToString();

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
                        cat.Categoria = dt.Rows[0]["Categoria"].ToString();

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
                cm.Parameters.AddWithValue("@Categoria", categoria.Categoria);
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
                cm.Parameters.AddWithValue("@categoria", categoria.Categoria);
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
                    descripcion.id_descripcion_venta = (int)dt.Rows[0][" Id_descripcion_venta"];
                    descripcion.producto = (int)dt.Rows[0]["producto"];
                    descripcion.cantidad = (int)dt.Rows[0]["cantidad"];
                    descripcion.venta = (int)dt.Rows[0]["venta"];
                    descripcion.precio = Convert.ToDecimal(dt.Rows[0]["precio"].ToString());
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
                        des.id_descripcion_venta = (int)dt.Rows[0][" Id_descripcion_venta"];
                        des.producto = (int)dt.Rows[0]["producto"];
                        des.cantidad = (int)dt.Rows[0]["cantidad"];
                        des.producto = (int)dt.Rows[0]["venta"];
                        des.venta = (int)dt.Rows[0]["venta"];
                        des.precio = Convert.ToDecimal(dt.Rows[0]["precio"].ToString());
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
        public string insertDescripcionVenta(DescripcionVenta descripcionVenta)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into DescripcipnVenta (producto,cantidad,venta,precio )values(@producto,@cantidad,@venta,@precio)");
                cm.Parameters.AddWithValue("@producto", descripcionVenta.producto);
                cm.Parameters.AddWithValue("@cantidad", descripcionVenta.cantidad);
                cm.Parameters.AddWithValue("@venta", descripcionVenta.venta);
                cm.Parameters.AddWithValue("@precio", descripcionVenta.precio);
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
        //actualizar una DescripcionVenta
        public string actualizarDescripcionVenta(DescripcionVenta descripcion)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE DescripcionVenta SET producto=@producto,cantidad=@cantidad,venta=@venta,precio=@precio WHERE Id_descripcion_venta = @Id  ", cn);
                cm.Parameters.AddWithValue("@", descripcion.id_descripcion_venta);
                cm.Parameters.AddWithValue("@producto", descripcion.producto);
                cm.Parameters.AddWithValue("@cantidad", descripcion.cantidad);
                cm.Parameters.AddWithValue("@venta", descripcion.venta);
                cm.Parameters.AddWithValue("@precio", descripcion.precio);
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
                        clientes.cargo = Convert.ToString(dt.Rows[0][15]);
                        clientes.email = Convert.ToString(dt.Rows[0]["email"]);
                        clientes.tipo = Convert.ToString(dt.Rows[0]["tipoCliente"]);
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
                cm = new SqlCommand("Insert into factura (numero,clienteId,usuario,fecha_venta,total,iva,subtotal,descuento,productoId)values(@numero,@clienteId,@usuario,@fecha_venta,@total,@iva,@subtotal,@descuento,@productoId)");
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
                    marca.Marca = Convert.ToString(dt.Rows[0]["marca"]);
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
                        marcas.Marca = Convert.ToString(dt.Rows[0]["marca"]);

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
        //insertar marca
        public string insertMarca(Marcas marca)
        {
            cn.ConnectionString = myConnection();
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("Insert into Marcas (marca)values(@marca)");
                cm.Parameters.AddWithValue("@marca", marca.Marca);
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
                cm.Parameters.AddWithValue("@marca", marca.Marca);
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
                cm = new SqlCommand($"Select * from Inventario Where Id_inventario = {Id}", cn);
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
                    venta.cliente = (int)dt.Rows[0]["cliente"];
                    venta.usuario = (int)dt.Rows[0]["usuario"];
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
                        venta.Id_venta = (int)dt.Rows[0]["Id_venta"];
                        venta.numero = (int)dt.Rows[0]["numero"];
                        venta.cliente = (int)dt.Rows[0]["cliente"];
                        venta.usuario = (int)dt.Rows[0]["usuario"];
                        venta.fecha_venta = Convert.ToDateTime(dt.Rows[0]["fecha_venta"]);
                        venta.total = Convert.ToDecimal(dt.Rows[0]["total"]);
                        venta.iva = Convert.ToDecimal(dt.Rows[0]["iva"]);
                        venta.subtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"]);
                        venta.descuento = Convert.ToDecimal(dt.Rows[0]["descuento"]);

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
                cm.Parameters.AddWithValue("@cliente", venta.cliente);
                cm.Parameters.AddWithValue("@usuario", venta.usuario);
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
                cm.Parameters.AddWithValue("@cliente", venta.cliente);
                cm.Parameters.AddWithValue("@usuario", venta.usuario);
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
                    items.Add(itemCombo);
                }

            }
            item.Combo = items;
            return items;
        }
    }
}