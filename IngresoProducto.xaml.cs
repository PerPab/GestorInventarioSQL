using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace CRUDinventario
{
    /// <summary>
    /// Lógica de interacción para IngresoProducto.xaml
    /// </summary>
    public partial class IngresoProducto : Window
    {
        public IngresoProducto()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = ingresoCodigo.Text.Trim().ToUpper();
            string nombre = ingresoNombre.Text.Trim().ToUpper();
            string lote = ingresoLote.Text.Trim().ToUpper();
            string pais = ingresoPais.Text.Trim().ToUpper();
            string fechaF = fechaFabricacion.Text.Trim();
            string fechaV = fechaVencimiento.Text.Trim();
            string fechaI = DateTime.UtcNow.ToString("MM-dd-yyyy");
            string ubicacion = ingresoUbicacion.Text.Trim().ToUpper();

            if (codigo == "" & nombre == "" & lote == "" & ubicacion == "")
            {
                MessageBox.Show("Debe completar los campos obligatorios antes de Guardar un producto");
            }
            else
            {

                SQLiteConnection conexion = new SQLiteConnection("Data Source=D:\\inventario\\CRUDinventario\\InventarioDB.db");
                try
                {
                    string consulta = $"insert into producto (nombre_producto, lote_producto, pais_origen, fecha_fabricacion, fecha_vencimiento, fecha_ingreso, ubicacion, codigo_producto) values ('{nombre}','{lote}','{pais}','{fechaF}','{fechaV}','{fechaI}','{ubicacion}','{codigo}')";
                    conexion.Open();
                    SQLiteCommand comando = new SQLiteCommand(consulta, conexion);
                    comando.ExecuteNonQuery();


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

                ingresoCodigo.Text = string.Empty;
                ingresoLote.Text = string.Empty;
                ingresoNombre.Text = string.Empty;
                ingresoPais.Text = string.Empty;
                ingresoUbicacion.Text = string.Empty;
                fechaFabricacion.Text = string.Empty;
                fechaVencimiento.Text = string.Empty;

                MessageBox.Show("Producto ingresado con éxito");

            }







        }
    }
}
