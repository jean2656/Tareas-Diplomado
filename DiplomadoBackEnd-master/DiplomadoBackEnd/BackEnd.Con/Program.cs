using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue; //Nos permite definir un color de fondo.

            //retorno aqui con un goto.
        inicio:
            Console.WriteLine("");


            Console.Clear();
            Console.WriteLine("********** MENU DE OPCIONES **********");
            Console.WriteLine("");

            Console.WriteLine("1.- Saludar usuario ");
            Console.WriteLine("2.- Realizar Suma, Resta, Multiplicacion y Division ");
            Console.WriteLine("3.- Determinar si un numero es PAR");
            Console.WriteLine("4.- Generar una matriz ");
            Console.WriteLine("5.- Multiplo de Tres ");


            Console.WriteLine("10.- Salir ");

            Console.Write("Seleccione una opción: ");
            int respuesta = int.Parse(Console.ReadLine()); //Podemos mejorar el parse, con int.TryParse.

            //Instaciamos clase.
            Utilitarios utilitarios = new Utilitarios();

            switch (respuesta)
            {
                case 1:
                    utilitarios.Saludar();
                    break;

                case 2:
                    utilitarios.OperacionesBasicas();
                    break;

                case 3:
                    Console.Write("Digite un numero entero ");
                    utilitarios.IsPar(int.Parse(Console.ReadLine()));
                    break;

                case 4:
                    utilitarios.GenerarMatriz();
                    break;

                case 5:
                    utilitarios.MuliploTres();
                    break;

                default:
                    Console.WriteLine("Opcion Invalida");
                    goto inicio;
                    //break;
            }
        }
    }
}

