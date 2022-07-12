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
            cm = new SqlCommand("SELECT password FROM tbUser WHERE username = '"+ username + "'", cn);
            dr= cm.ExecuteReader();
            dr.Read();
            if(dr.HasRows)
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
        ///   CRUD PARA CLASE ITEM
        ///------ SECCION PARA SELECT ITEMS --------------
        public Items selectItemPorId(int Id)
        {
            Items item = new Items();
            try
            {
                cm = new SqlCommand($"Select * from Items Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                //    item.Id = (int)dt.Rows[0]["Id"];
                //    item.nombre = dt.Rows["nombre"];
                //    item.codigoUno = dt.Rows["codigoUno"];
                //    item.codigoDos = dt.Rows["codigoDos"];
                //    item.codigoTres = dt.Rows["codigoTres"];
                //    item.codigoCuatro = dt.Rows["codigoCuatro"];
                //    item.codigoBarras = dt.Rows["codigoBarras"];
                //    item.precioA = dt.Rows["precioA"];
                //    item.precioB = dt.Rows["precioB"];
                //    item.precioC = dt.Rows["precioC"];
                //    item.precioD = dt.Rows["precioD"];
                //    item.descripcion = dt.Rows["descripcion"];
                //    item.unidadCaja = dt.Rows["unidadCaja"];
                //    item.peso = dt.Rows["peso"];
                //    item.comision = dt.Rows["comision"];
                //    item.descMax = dt.Rows["descMax"];
                //    item.stockMax = dt.Rows["stockMax"];
                //    item.stockMin = dt.Rows["stockMin"];
                //    item.costo = dt.Rows["costo"];
                //    item.unidad = dt.Rows["unidad"];
                //    item.bId = dt.Rows["bId"];
                //    item.cId = dt.Rows["cId"];
                //    item.gId = dt.Rows["gId"];
                //    item.mId = dt.Rows["mId"];
                //    item.servicio = dt.Rows["servicio"];
                //    item.aplicaSeries = dt.Rows["aplicaSeries"];
                //    item.negativo = dt.Rows["negativo"];
                //    item.combo = dt.Rows["combo"];
                //    item.gasto = dt.Rows["gasto"];
                //    item.ice = dt.Rows["ice"];
                //    item.valorIce = dt.Rows["valorIce"];
                //    item.HasIva = dt.Rows["HasIva"];
                //    item.iva = dt.Rows["iva"];
                //    item.imagen = dt.Rows["imagen"];
                //    item.descripcion = dt.Rows["imagenUrl"];
                //    item.montoTotal = dt.Rows["montoTotal"];
                }
                cm.ExecuteNonQuery();
                return item;

            }
            catch (Exception ex)
            {
                //Error = ex.ToString();
                return item;
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Items> selectTodosLosItems(int Id)
        {
            List<Items> items = new  List<Items>();

            try
            {
                cm = new SqlCommand($"Select * from Items Where Id = {Id}");
                SqlDataAdapter da = new SqlDataAdapter(cm.CommandText, cn);
                cn.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Items item = new Items();
                        //item.Id = (int)dt["Id"];
                        //item.nombre = dt["nombre"];
                        //item.codigoUno = dt["codigoUno"];
                        //item.codigoDos = dt["codigoDos"];
                        //item.codigoTres = dt["codigoTres"];
                        //item.codigoCuatro = dt["codigoCuatro"];
                        //item.codigoBarras = dt["codigoBarras"];
                        //item.precioA = dt["precioA"];
                        //item.precioB = dt["precioB"];
                        //item.precioC = dt["precioC"];
                        //item.precioD = dt["precioD"];
                        //item.descripcion = dt["descripcion"];
                        //item.unidadCaja = dt["unidadCaja"];
                        //item.peso = dt["peso"];
                        //item.comision = dt["comision"];
                        //item.descMax = dt["descMax"];
                        //item.stockMax = dt["stockMax"];
                        //item.stockMin = dt["stockMin"];
                        //item.costo = dt["costo"];
                        //item.unidad = dt["unidad"];
                        //item.bId = dt["bId"];
                        //item.cId = dt["cId"];
                        //item.gId = dt["gId"];
                        //item.mId = dt["mId"];
                        //item.servicio = dt["servicio"];
                        //item.aplicaSeries = dt["aplicaSeries"];
                        //item.negativo = dt["negativo"];
                        //item.combo = dt["combo"];
                        //item.gasto = dt["gasto"];
                        //item.ice = dt["ice"];
                        //item.valorIce = dt["valorIce"];
                        //item.HasIva = dt["HasIva"];
                        //item.iva = dt["iva"];
                        //item.imagen = dt["imagen"];
                        //item.descripcion = dt["imagenUrl"];
                        //item.montoTotal = dt["montoTotal"];
                        //item.categoriasA = dt["categoriaA"];
                        //item.categoriasB = dt["categoriaB"];
                        //item.categoriasC = dt["categoriaC"];
                        //item.categoriasD = dt["categoriaD"];
                        //item.categoriasE = dt["categoriaE"];
                        //items.Add(item);
                    }

                }
                cm.ExecuteNonQuery();
                return items;

            }
            catch (Exception ex)
            {
                //Error = ex.ToString();
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
            string Error = String.Empty;
            try
            {
                cm = new SqlCommand("UPDATE Items SET nombre=@nombre,codigoUno=@codigoUno,codigoDos=@codigoDos,codigoTres=@codigoTres,codigoCuatro=@codigoCuatro,precioA=@precioA,precioB=@precioB,precioC=@precioC,precioD=@precioD,descripcion=@descripcion,unidadCaja=@unidadCaja,peso=@peso,comision=@comision,descMax=@descMax,stockMin=@stockMin,stockMax=@stockMax,costo=@costo,unidad=@unidad,bId=@bId,cId=@cId ,gId=@gId,mId=@mId,servicio=@servicio,aplicaSeries=@aplicaSeries,negativo=@negativo,combo=@combo,gasto=@gasto,ice=@ice,valorIce=@valorIce,imagen=@imagen,imagenUrl=@imagenUrl,iva=@iva,montoTotal=@montoTotal,HasIva=HasIva,categoriaA=@categoriaA,categoriaB=@categoriaB,categoriaC=@categoriaC,categoriaD=@categoriaD,categoriaE=@categoriaE  WHERE Id = @Id  ", cn);
                cm.Parameters.AddWithValue("@", item.Id);
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

    }
}
