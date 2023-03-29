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

namespace Burbuja
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[,] mat1;
        private int[] arreglo;
        private int[,] mat2;
        int contador = 0;
        private void btmcargar_Click(object sender, RoutedEventArgs e)
        {

            Random num = new Random();
            mat1 = new int[5, 5];
            contador = 0;
            arreglo = new int[25];
            grid1.Children.Clear();
            grid2.Children.Clear();
            

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {

                    mat1[r, c] = num.Next(1, 100);
                    arreglo[contador] = mat1[r, c];
                    contador++;
                    Label lbl = new Label();
                    lbl.Content = mat1[r, c];
                    Grid.SetColumn(lbl, c);
                    Grid.SetRow(lbl, r);
                    grid1.Children.Add(lbl);

                }
            }
        }

        private void odenamientoburbuja()
        {
            // metodo de burbuja
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (arreglo[j] > arreglo[j + 1])
                    {
                        int temp = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = temp;
                    }
                }
            }
        }
            
        private void ordenamientoporseleccion()
        {
            int n = arreglo.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arreglo[j] < arreglo[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = arreglo[i];
                    arreglo[i] = arreglo[minIndex];
                    arreglo[minIndex] = temp;
                }
            }


        }
        private void ordenamientoxinsercion()
        {
            int n = arreglo.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arreglo[i];
                int j = i - 1;
                while (j >= 0 && arreglo[j] > key)
                {
                    arreglo[j + 1] = arreglo[j];
                    j--;
                }
                arreglo[j + 1] = key;

            }

        }
        private void ordenamientoxshell()
        {
            int n = arreglo.Length;
            int intervalo = 1;
            while (intervalo < n / 3)
            {
                intervalo = intervalo * 3 + 1;
            }
            while (intervalo >= 1)
            {
                for (int i = intervalo; i < n; i++)
                {
                    int key = arreglo[i];
                    int j = i - intervalo;
                    while (j >= 0 && arreglo[j] > key)
                    {
                        arreglo[j + intervalo] = arreglo[j];
                        j -= intervalo;
                    }
                    arreglo[j + intervalo] = key;
                }
                intervalo /= 3;

            }

        }
        private void ordenamientoxmezcla()
        {
            MergeSort(arreglo);
        }
        public static void MergeSort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            MergeSortHelper(arr, temp, 0, n - 1);
        }

        private static void MergeSortHelper(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortHelper(arr, temp, left, mid);
                MergeSortHelper(arr, temp, mid + 1, right);
                Merge(arr, temp, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }
            while (i <= mid)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            for (k = left; k <= right; k++)
            {
                arr[k] = temp[k];
            }
        }


        private void ordenamientoxrapido()
        {
            QuickSort(arreglo);
        }
        public static void QuickSort(int[] arr)
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        private static void QuickSortHelper(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSortHelper(arr, left, pivotIndex - 1);
                QuickSortHelper(arr, pivotIndex + 1, right);
            }
        }
        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void visualizamatrizordenada()
        {
            mat2 = new int[5, 5];
            int contador2 = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    mat2[r, c] = arreglo[contador2];
                    Label lbl1 = new Label();
                    lbl1.Content = mat2[r, c];
                    Grid.SetColumn(lbl1, c);
                    Grid.SetRow(lbl1, r);
                    grid2.Children.Add(lbl1);
                    contador2++;

                }
            }
        }
            private void btmordenar_Click(object sender, RoutedEventArgs e)
        {
            odenamientoburbuja();
            visualizamatrizordenada();

        }

        private void btmseleccion_Click(object sender, RoutedEventArgs e)
        {
            ordenamientoporseleccion();
            visualizamatrizordenada();
        }

        private void btminsercion_Click(object sender, RoutedEventArgs e)
        {
            ordenamientoxinsercion();
            visualizamatrizordenada();
        }

        private void btmshell_Click(object sender, RoutedEventArgs e)
        {
            ordenamientoxshell();
            visualizamatrizordenada();
        }

        private void btmmezcla_Click(object sender, RoutedEventArgs e)
        {
            ordenamientoxmezcla();
            visualizamatrizordenada();
        }

        private void btmrapido_Click(object sender, RoutedEventArgs e)
        {
            ordenamientoxrapido();
            visualizamatrizordenada();
        }

        private void busquedasecuencial_Click(object sender, RoutedEventArgs e)
        {
            busqueda_secuencial(int.Parse(txt1.Text), mat1);
        }
        private void busqueda_secuencial(int buscarvalor, int[,] array)
        {
            bool found = false;
            int rowIndex = -1, colIndex = -1;
            for (int i=0;i < array.GetLength(0); i++)
            {
                for(int j=0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == buscarvalor)
                    {
                        found = true;
                        rowIndex= i;
                        colIndex= j;
                        break;
                    }
                }
                if (found == true) break;
            }
            if (found)
            {
                MessageBox.Show(" Valor " + buscarvalor + " encontrado en el renglon " + rowIndex + " de la columna " + colIndex);
            }
            else
            {
                MessageBox.Show("Dato no encontrado en la Matriz");
            }
        }
        private void busquedabinaria_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

