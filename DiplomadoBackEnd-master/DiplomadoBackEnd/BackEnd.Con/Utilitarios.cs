using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Con
{
    public class Utilitarios
    {
        //propiedad.
              
        public Utilitarios()
        {
            //constructor....
            //Podemos definir mas de un constructor, haciendo sobrecarga.
        }

       
        /// <summary>
        /// Este metodo permite saludar una persona.
        /// </summary>
        public void Saludar()
        {
            Console.WriteLine("Favor digitar su nombre ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Hola {0}", nombre);
            Console.ReadKey();
        }

        /// <summary>
        /// Permite realizar las operaciones basicas de dos numeros interos.
        /// </summary>
        public void OperacionesBasicas()
        {
            Console.WriteLine("Favor digitar el primer numero ");
            int primerNumero = int.Parse(Console.ReadLine());
            Console.WriteLine("Favor digitar el segundo numero ");
            int segundoNumero = int.Parse(Console.ReadLine());

            //Operaciones basicas.
            int suma = primerNumero + segundoNumero;
            int resta = primerNumero - segundoNumero;
            int multiplicacion = primerNumero * segundoNumero;
            int division = primerNumero / segundoNumero;

            //Concatenando....
            Console.WriteLine("La suma de {0} + {1} es: {2} ", primerNumero, segundoNumero, suma); //Pasando argumentos.
            Console.WriteLine($"La resta de {primerNumero} + {segundoNumero} es: {resta}"); //interpolation
            Console.WriteLine("La Multiplicacion de " + primerNumero + " * " + segundoNumero + " es: " + multiplicacion);

            //Usado StringBuilder
            StringBuilder miCadena = new StringBuilder();
            miCadena.Append("La división de ");
            miCadena.Append(primerNumero);
            miCadena.Append(" / ");
            miCadena.Append(segundoNumero + " es ");
            miCadena.Append(division);

            Console.WriteLine(miCadena.ToString());
            Console.ReadKey();
        }


        /// <summary>
        /// Determinar si un numero es par.
        /// </summary>
        /// <param name="numero">Numero a determinar si es par</param>
        /// <returns>bool</returns>
        public bool IsPar(int numero)
        {
            if (numero % 2 == 0)
                return true;
            else
                return false;
        }

        public void MuliploTres()
        {
            int i = 1;
            while (i <= 300)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }

                i++;
            }
            Console.ReadKey();
        }

        public void GenerarMatriz()
        {
            Console.WriteLine("Favor digitar cantidad filas ");
            int filas = int.Parse(Console.ReadLine());
            Console.WriteLine("Favor digitar cantidad columnas ");
            int columnas = int.Parse(Console.ReadLine());

            Console.Clear();
            int[,] miMatriz = new int[filas, columnas];

            for (int f = 0; f < filas; f++)
            {
                for(int c =0; c<columnas; c++)
                {
                    Console.Write("Cantidad en la fila {0} columna {1} ", f, c);
                    miMatriz[f, c] = int.Parse(Console.ReadLine());
                }
            }

            //Mosrar Matriz
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    Console.Write(miMatriz[f, c] + " ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
