using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea2_Progra3
{
    internal class ClassMenu
    {
        public static int opcion;

        public static void menu()
        {
            do
            {
                Console.WriteLine("-------------Menu Principal-------------");
                Console.WriteLine("Opcion 1: Agregar Productos");
                Console.WriteLine("Opcion 2: Venta de Productos");
                Console.WriteLine("Opcion 3: Sub Menu Actualizar Productos");
                Console.WriteLine("Opcion 4: Consultar Producto ");
                Console.WriteLine("Opcion 5: Borrar Producto");
                Console.WriteLine("Opcion 6: Reporte General");
                Console.WriteLine("Opcion 7: Salir");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);//si ingresa una letra no va a dejar continuar

                switch (opcion)
                {
                    case 1: ClassProducto.AgregarProducto(); break;
                    case 2: ClassProducto.VentaProducto(); break;
                    case 3: ClassProducto.ActualizarProducto(); break;
                    case 4: ClassProducto.ConsultarProducto(); break;
                    case 5: ClassProducto.Borrar(); break;
                    case 6: ClassProducto.Reporte(); break;
                    case 7:
                        Console.WriteLine("¡Hasta pronto! Gracias");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 7 |\r\n+------------------------------------------+");
                        break;
                }

            } while (opcion != 7);
        }//fin metodo

    }//fin clase
}//fin namespace
