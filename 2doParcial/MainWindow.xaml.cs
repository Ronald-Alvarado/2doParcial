using _2doParcial.BLL;
using _2doParcial.Entidades;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2doParcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Llamadas llamadas = new Llamadas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = llamadas;
            LLamadaId_Text.Text = "0";
        }

        private void Limpiar()
        {
            LLamadaId_Text.Text = "0";
            Descripcion_Text.Text = string.Empty;
            llamadas = new Llamadas();
            Actualizar();
        }

        private bool ExisteBase()
        {
            Llamadas llamadas = LlamadasBLL.Buscar(Convert.ToInt32(LLamadaId_Text.Text));

            return (llamadas != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = llamadas;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas llamadasAnterior = LlamadasBLL.Buscar(llamadas.LlamadaId);

            if(llamadasAnterior != null)
            {
                llamadas = llamadasAnterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No se Encontro la Llamada");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(LLamadaId_Text.Text == "0")
            {
                paso = LlamadasBLL.Guardar(llamadas);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("No existe en la Base de Datos");
                    return;
                }
                paso = LlamadasBLL.Modificar(llamadas);
            }

            if (paso)
            {
                MessageBox.Show("Se ha guardado");
                Limpiar();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Se produjo un Error al Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(LlamadasBLL.Eliminar(llamadas.LlamadaId))
            {
                MessageBox.Show("Se Elimino Correctamente");
            }
            else
            {
                MessageBox.Show("Se produjo un Error al Eliminar");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            llamadas.LlamadasDetalle.Add(new LlamadasDetalle(Problema_Text.Text, Solucion_Text.Text));

            Actualizar();

            Problema_Text.Clear();
            Solucion_Text.Clear();

            Problema_Text.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(TelefonosDataGrid.Items.Count < 1 && TelefonosDataGrid.SelectedIndex > TelefonosDataGrid.Items.Count - 1)
            {
                llamadas.LlamadasDetalle.RemoveAt(TelefonosDataGrid.SelectedIndex);
                Actualizar();
            }
        }
    }
}
