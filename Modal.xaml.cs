using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace CRUDinventario
{
    /// <summary>
    /// Lógica de interacción para Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        string datoID;






        public Modal()
        {

            InitializeComponent();

        }

        public Modal(string id)
        {
            //btnEliminar.Click += (s, e) => btnEliminar_Click(s, e, id);

            this.datoID = id;

            InitializeComponent();
            getProducto(id);
            getCodigo(id);
            getLote(id);
            getPais(id);
            getUbicacion(id);
            getFechaF(id);
            getFechaV(id);
            getFechaI(id);





        }




        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void getProducto(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT nombre_producto FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoTexto.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getCodigo(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT codigo_producto FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoCodigo.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getLote(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT lote_producto FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoLote.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getPais(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT pais_origen FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoPais.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getUbicacion(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT ubicacion FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoUbicacion.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getFechaF(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT fecha_fabricacion FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoFabricacion.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getFechaV(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT fecha_vencimiento FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoVencimiento.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void getFechaI(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT fecha_ingreso FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                productoIngreso.Content += $" {comando.ExecuteScalar()}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void Eliminar(string dato)
        {
            int id = int.Parse(dato);
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"DELETE FROM producto WHERE id_producto == {id}";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


        }



        //private void btnEliminar_Click(object s, RoutedEventArgs e, string id)
        //{
        //    Eliminar(id);

        //}
    }
}

