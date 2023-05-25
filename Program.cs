//En este documento está contenido 3 pasos de la prueba 1 (Valores Aleatorios, Números primos y Coincidencias).
//El paso Emulador de Cajero Automático de la prueba 1 está en otro repositorio. Ya que no tiene na que ver con este.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Valores Aleatorios
            Console.WriteLine("1. Valores Aleatorios");
            Console.Write("Ingrese la cantidad de elementos (por defecto 5): ");
            int cantidadElementos = ObtenerCantidadElementos();

            List<int> numerosAleatorios = GenerarNumerosAleatorios(cantidadElementos);
            Console.WriteLine("Listado de números aleatorios:");
            ImprimirListaNumeros(numerosAleatorios);

            // 2. Números primos
            Console.WriteLine("\n2. Números primos");
            Console.Write("Ingrese la cantidad de números primos a generar (por defecto 9): ");
            int cantidadPrimos = ObtenerCantidadPrimos();

            List<int> numerosPrimos = GenerarNumerosPrimos(cantidadPrimos);
            Console.WriteLine("Listado de números primos:");
            ImprimirListaNumeros(numerosPrimos);

            // 4. Coincidencias y Fibonacci
            Console.WriteLine("\n4. Coincidencias y Fibonacci");
            List<int> coincidencias = ObtenerCoincidencias(numerosPrimos, numerosAleatorios);
            Console.WriteLine("Listado de números primos encontrados en los números aleatorios:");
            ImprimirListaNumeros(coincidencias);

            if (coincidencias.Count > 0)
            {
                int mayorCoincidencia = coincidencias.Max();
                Console.WriteLine($"Mayor número del conjunto de coincidencias: {mayorCoincidencia}");

                List<int> numerosFibonacci = GenerarNumerosFibonacci(mayorCoincidencia);
                Console.WriteLine($"Listado de números Fibonacci con {mayorCoincidencia} elementos:");
                ImprimirListaNumeros(numerosFibonacci);
            }
        }

        static int ObtenerCantidadElementos()
        {
            int cantidadElementos = 5;
            int.TryParse(Console.ReadLine(), out cantidadElementos);
            cantidadElementos = Math.Clamp(cantidadElementos, 1, 20);
            return cantidadElementos;
        }

        static int ObtenerCantidadPrimos()
        {
            int cantidadPrimos = 9;
            int.TryParse(Console.ReadLine(), out cantidadPrimos);
            return cantidadPrimos;
        }

        static List<int> GenerarNumerosAleatorios(int cantidadElementos)
        {
            List<int> numerosAleatorios = new List<int>();
            Random random = new Random();

            while (numerosAleatorios.Count < cantidadElementos)
            {
                int numero = random.Next(1, 101);

                if (!numerosAleatorios.Contains(numero))
                {
                    numerosAleatorios.Add(numero);
                }
            }

            return numerosAleatorios;
        }

        static List<int> GenerarNumerosPrimos(int cantidadPrimos)
        {
            List<int> numerosPrimos = new List<int>();
            int numeroActual = 2;

            while (numerosPrimos.Count < cantidadPrimos)
            {
                if (EsPrimo(numeroActual))
                {
                    numerosPrimos.Add(numeroActual);
                }

                numeroActual++;
            }

            return numerosPrimos;
        }

        static bool EsPrimo(int numero)
        {
            if (numero < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> ObtenerCoincidencias(List<int> numerosPrimos, List<int> numerosAleatorios)
        {
            return numerosPrimos.Intersect(numerosAleatorios).ToList();
        }

        static List<int> GenerarNumerosFibonacci(int cantidadElementos)
        {
            List<int> numerosFibonacci = new List<int>();

            int numeroAnterior = 0;
            int numeroActual = 1;

            for (int i = 0; i < cantidadElementos; i++)
            {
                numerosFibonacci.Add(numeroAnterior);

                int temp = numeroAnterior;
                numeroAnterior = numeroActual;
                numeroActual = temp + numeroActual;
            }

            return numerosFibonacci;
        }

        static void ImprimirListaNumeros(List<int> numeros)
        {
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
