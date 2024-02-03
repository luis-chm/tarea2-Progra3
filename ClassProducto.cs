using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarea2_Progra3
{
    internal class ClassProducto
    {
        // Atributos
        public int Codigo;
        public string Descripcion;
        public int Existencia;
        public int Minimo;
        public float Precio;
        public static List<ClassProducto> producto = new List<ClassProducto>();

        //Constructor
        public ClassProducto(int codigo, string descripcion, int existencia, int minimo, float precio)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Existencia = existencia;
            Minimo = minimo;
            Precio = precio;
        }

        // Constructor
        public ClassProducto(int codigo)
        {
            Codigo = codigo;
        }
        public ClassProducto() { }
        public static void AgregarProducto()
        {
            char respuesta = 'N';
            do
            {
                Console.Clear();
                Console.WriteLine("\n------------- Registro de inventario -------------");
                Console.WriteLine("\nDigite el codigo del producto:");
                int cod = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite la Descripcion del producto:");
                string descripcion = Console.ReadLine();
                Console.WriteLine("Digite la cantidad de existencia en inventario:");
                int existencia = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite el minimo en inventario:");
                int minimo = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite precio unitario($):");
                float precio = float.Parse(Console.ReadLine());
                Console.WriteLine("Desea ingresar otro producto (S/N):");
                respuesta = Char.Parse(Console.ReadLine().ToString().ToUpper());
                Console.Clear();

                producto.Add(new ClassProducto() { Codigo = cod, Descripcion = descripcion, Existencia = existencia, Minimo = minimo, Precio = precio });

            } while (respuesta != 'N');
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elementos añadidos con exito a la lista");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nRegresando al menu");
            Thread.Sleep(2000);
            Console.Clear();

        }//fin metodo agregar 

        public static void VentaProducto()
        {
            int cod = 0;
            int cantidadVendida = 0;
            bool productFound = false;

            Console.Clear();
            Console.WriteLine("\n------------- Venta de productos -------------");
            Console.WriteLine("\nListado de productos disponibles");
            foreach (var item in producto)
            {
                
                
                Console.WriteLine($"Codigo: {item.Codigo}, Descripcion: {item.Descripcion}, Precio: {item.Precio}");
            }

            Console.WriteLine("\nDigite el codigo del producto a comprar:");
            cod = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < producto.Count; i++)
            {
                if (cod == producto[i].Codigo)
                {
                    Console.WriteLine($"Producto seleccionado: Codigo: {producto[i].Codigo}, Descripcion: {producto[i].Descripcion}, Precio: {producto[i].Precio}");
                    Console.WriteLine("Digite la cantidad a comprar:");
                    cantidadVendida = Convert.ToInt32(Console.ReadLine());

                    if (cantidadVendida > 0 && cantidadVendida <= producto[i].Existencia)
                    {
                        producto[i].Existencia -= cantidadVendida;

                        if (producto[i].Existencia >= producto[i].Minimo)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Producto vendido con éxito");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nRegresando al menu");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Producto NO DISPONIBLE. La existencia después de la venta sería menor al mínimo.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\nRegresando al menu");
                            Thread.Sleep(3000);
                            Console.Clear();
                            //Rollback: Aumentar la existencia en caso de que no se pueda realizar la venta
                            producto[i].Existencia += cantidadVendida;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cantidad no válida o insuficiente en existencia.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nRegresando al menu");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    productFound = true;
                    break; 
                }
            }
            if (!productFound)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El producto no existe en la lista");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nRegresando al menu");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }//fin metodo venta
        public static void ActualizarProducto()
        {
            int cod = 0;
            Boolean productFound = false;
            Console.Clear();
            Console.WriteLine("\n------------- Actualizar productos -------------");
            Console.WriteLine("\nListado de productos:");
            foreach (var item in producto)
            {
                Console.WriteLine($"Codigo: {item.Codigo}, Descripcion: {item.Descripcion}");
            }

            Console.WriteLine("\nDigite el codigo del producto:");
            cod = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < producto.Count; i++)
            {
                if (cod == producto[i].Codigo)
                {
                    Console.Clear();
                    int opcion = 0;
                    //Console.Clear();

                    do
                    {
                        Console.WriteLine("Informacion del producto a actualizar");
                        Console.WriteLine($"Descripcion: {producto[i].Descripcion}, Existencia: {producto[i].Existencia}, Minimo: {producto[i].Minimo}, Precio: {producto[i].Precio}");
                        Console.WriteLine("\n");
                        Console.WriteLine($"-------------Actualizando Producto Codigo: {producto[i].Codigo} -------------\n");
                        Console.WriteLine("Opcion 1:  Actualizar Descripcion.");
                        Console.WriteLine("Opcion 2:  Actualizar Existencia.");
                        Console.WriteLine("Opcion 3:  Actualizar Minimo.");
                        Console.WriteLine("Opcion 4:  Actualizar Precio.");
                        Console.WriteLine("Opcion 5:  Regresar al Menu Principal.");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Seleccione su opcion: ");
                        int.TryParse(Console.ReadLine(), out opcion);// si ingresa una letra no va a dejar continuar
                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Digite la nueva Descripcion");
                                producto[i].Descripcion = Console.ReadLine();
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Descripcion actualizada\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Codigo: {producto[i].Codigo}, Nueva Descripcion: {producto[i].Descripcion}");
                                Console.WriteLine("\nPresione Enter para volver al menú.");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 2:
                                Console.WriteLine("Digite La nueva existencia");
                                producto[i].Existencia = int.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Existencia actualizada\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Codigo: {producto[i].Codigo}, Nueva Cant. Existencia: {producto[i].Existencia}");
                                Console.WriteLine("\nPresione Enter para volver al menú.");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 3:
                                Console.WriteLine("Digite el nuevo minimo");
                                producto[i].Minimo = int.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Minimo actualizada\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Codigo: {producto[i].Codigo}, Nuevo Cant. Minimo: {producto[i].Minimo}");
                                Console.WriteLine("\nPresione Enter para volver al menú.");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 4:
                                Console.WriteLine("Digite el nuevo precio");
                                producto[i].Precio = float.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Precio actualizada\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"Codigo: {producto[i].Codigo}, Nuevo Precio: {producto[i].Precio}");
                                Console.WriteLine("\nPresione Enter para volver al menú.");
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 5:
                                Console.WriteLine("Regresando...");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 5 |\r\n+------------------------------------------+");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                        }//fin switch

                    } while (opcion != 5);

                    productFound = true;
                    break;
                }
            }
            if (!productFound)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El producto no existe en la lista");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nRegresando al menu");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }//fin metodo actualizar
        public static void ConsultarProducto()
        {
            int cod = 0;
            Boolean productFound = false;
            Console.Clear();
            Console.WriteLine("\n------------- Consultar Producto -------------\n");
            Console.WriteLine("Digite el codigo del producto:");
            cod = Convert.ToInt32(Console.ReadLine());

            foreach (var product in producto)
            {
                if (product.Codigo.Equals(cod))
                {
                    Console.Clear();
                    Console.WriteLine($"\nCodigo: {product.Codigo}, Descripcion: {product.Descripcion}, Existencia: {product.Existencia}, Minimo: {product.Minimo}, Precio: {product.Precio}");
                    Console.WriteLine("\nPresione Enter para volver al menú principal.");
                    Console.ReadLine();
                    Console.Clear();
                    productFound = true;
                    break;

                }
            }
            if (!productFound)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El producto no existe en la lista");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nRegresando al menu");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }//fin metodo consultar
        public static void Borrar()
        {
            char respuesta = 'N';
            int cod = 0;
            Boolean productFound = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\n------------- Borrar Producto -------------\n");
                Console.WriteLine("Digite el codigo del producto:");
                cod = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < producto.Count; i++)
                {
                    if (cod == producto[i].Codigo)
                    {
                        Console.Clear();
                        Console.WriteLine("Informacion del producto a eliminar\n");
                        Console.WriteLine($"Codigo: {producto[i].Codigo}, Descripcion: {producto[i].Descripcion}, Existencia: {producto[i].Existencia}, Minimo: {producto[i].Minimo}, Precio: {producto[i].Precio}");
                        Console.WriteLine("\n");
                        Console.WriteLine("Desea eliminar el producto (S/N):");
                        respuesta = Char.Parse(Console.ReadLine().ToString().ToUpper());

                        if (respuesta == 'S')
                        {
                            Console.Clear();
                            producto.RemoveAt(i);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Producto eliminado correctamente.");
                            Console.ForegroundColor = ConsoleColor.White;
                            productFound = true;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Producto NO eliminado.");
                            Console.ForegroundColor = ConsoleColor.White;
                            productFound = true;
                        }
                    }
                }
                if (!productFound)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El producto no existe en la lista");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nRegresando al menu");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
                //Console.Clear();
                Console.WriteLine("\n\nRegresando al menu");
                Thread.Sleep(2000);
                Console.Clear();
                break;

            } while (productFound && respuesta != 'N');

        }//fin metodo borrar

        public static void Reporte()
        {
            Console.Clear();
            Console.WriteLine("\n-------------------------- Reporte General --------------------------\n");
            foreach (var item in producto)
            {
                Console.WriteLine($" Codigo: {item.Codigo}, Descripcion: {item.Descripcion}, Existencia: {item.Existencia}, Minimo: {item.Minimo}, Precio: {item.Precio}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------\n");
            Console.WriteLine("\nPresione Enter para volver al menú principal.");
            Console.ReadLine();
            Console.Clear();
        }//fin metodo reporte general

    }//fin clase
}//fin namespace
