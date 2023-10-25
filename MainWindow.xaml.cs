using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace CRUDinventario
{
    
    public partial class MainWindow : Window
    {
        string idProducto = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    this.Close();
        //}
        public void ListarProductos()
        {
            string path = Environment.CurrentDirectory;
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = "SELECT producto.id_producto, producto.nombre_producto, producto.codigo_producto, producto.lote_producto, producto.ubicacion FROM producto";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(comando);
                using (adaptador)
                {
                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);
                    //listadoPrincipal.DataContext = tabla;
                    listadoPrincipal.ItemsSource = tabla.DefaultView;
                    listadoPrincipal.SelectedValuePath = "id_producto";

                }
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


        public void BuscarPorCodigo(string codigo)
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT producto.id_producto, producto.nombre_producto, producto.codigo_producto, producto.lote_producto, producto.ubicacion FROM producto WHERE producto.codigo_producto = '{codigo}'";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(comando);
                using (adaptador)
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    //listadoPrincipal.DataContext = tabla;
                    listadoPrincipal.ItemsSource = tabla.DefaultView;
                }
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

        public void BuscarPorLote(string codigo)
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT producto.id_producto, producto.nombre_producto, producto.codigo_producto, producto.lote_producto, producto.ubicacion FROM producto WHERE producto.lote_producto = '{codigo}'";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(comando);
                using (adaptador)
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    //listadoPrincipal.DataContext = tabla;
                    listadoPrincipal.ItemsSource = tabla.DefaultView;
                }
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

        public void BuscarPorUbicacion(string codigo)
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
            try
            {
                string consulta = $"SELECT producto.id_producto, producto.nombre_producto, producto.codigo_producto, producto.lote_producto, producto.ubicacion FROM producto WHERE producto.ubicacion = '{codigo}'";
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(comando);
                using (adaptador)
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    //listadoPrincipal.DataContext = tabla;
                    listadoPrincipal.ItemsSource = tabla.DefaultView;
                }
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListarProductos();
            textboxcodigo.Text = string.Empty;
            textoLote.Text = string.Empty;
            textoUbicacion.Text = string.Empty;
        }

        private void listadoPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ListarProductos();
        }

        private void btncodigo_Click(object sender, RoutedEventArgs e)
        {
            string codigo = textboxcodigo.Text.Trim().ToUpper();

            if (codigo != "")
            {
                BuscarPorCodigo(codigo);
                textboxcodigo.Text = string.Empty;
                textoLote.Text = string.Empty;
                textoUbicacion.Text = string.Empty;
            }
        }

        private void btnLote_Click(object sender, RoutedEventArgs e)
        {
            string codigo = textoLote.Text.Trim().ToUpper();

            if (codigo != "")
            {
                BuscarPorLote(codigo);
                textboxcodigo.Text = string.Empty;
                textoLote.Text = string.Empty;
                textoUbicacion.Text = string.Empty;
            }
        }

        private void btnUbicacion_Click(object sender, RoutedEventArgs e)
        {
            string codigo = textoUbicacion.Text.Trim().ToUpper();

            if (codigo != "")
            {
                BuscarPorUbicacion(codigo);
                textboxcodigo.Text = string.Empty;
                textoLote.Text = string.Empty;
                textoUbicacion.Text = string.Empty;
            }

        }

        //private void listadoPrincipal_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    Modal modal = new Modal();
        //    modal.ShowDialog();
        //}

        private void listadoPrincipal_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            idProducto = listadoPrincipal.SelectedValue.ToString();
            Modal modal = new Modal(idProducto);
            modal.ShowDialog();
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IngresoProducto ingreso = new IngresoProducto();
            ingreso.Show();
            this.Close();

        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            idProducto = listadoPrincipal.SelectedValue.ToString();
            Modal modal = new Modal(idProducto);
            modal.ShowDialog();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            idProducto = listadoPrincipal.SelectedValue.ToString();
           

            var Result = MessageBox.Show("Seguro desea eliminar este registro?","Mood Test", MessageBoxButton.OKCancel);
            if (Result == MessageBoxResult.OK)
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
                try
                {
                    string consulta = $"DELETE FROM producto WHERE producto.id_producto =={idProducto} ";
                    conexion.Open();
                    SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                    comando.ExecuteNonQuery();
                    ListarProductos();
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
                btnEliminar.IsEnabled = false;
                MessageBox.Show("Registro Eliminado con exito");

                
            }
            else if (Result == MessageBoxResult.No)
            {
                Environment.Exit(0);
            }

            
        }

        private void listadoPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.IsEnabled = true;
        }
    }
}

