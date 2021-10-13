using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busquedaBinariaApp
{
    class Program
    {
        /*
        *
        *Soluciona la busqueda de un item en una lista ordenada de manera ascendente e imprime su ubicación
        *dentro del arreglo.
        *
        *2 metodos de solución: 
        * binarySearch(): iterativo y con falencia de control cuando el item no existe.
        * recursiveBinarySearch(): usa la recursividad para resolver el problema, sin percances.
        * 
        * 
         * */

        static void Main(string[] args)
        {
            int[] array = { 1, 5, 10, 43, 101, 202, 321, 331, 509, 666 };
            int objective = 667;
            int sizeArray = array.Count();
            int result;

            result = binarySearch(array, 0, sizeArray, objective);

            Console.WriteLine($"La ubicación del item {objective} es en {result}");

            result = recursiveBinarySearch(array, 0, sizeArray - 1, objective);
            if (result != -1)
            {
                Console.WriteLine($"La ubicación del item {objective} es en {result}");
            }
            else
            {
                Console.WriteLine($"No existe ubicación del item {objective}");
            }
            

            Console.ReadKey();
        }

        public static int binarySearch(int[] items, int initItems, int size, int itemSearch)
        {
            int value = -1;
            int middlePosiion = positionSearch(size, size - 1, false);
            initItems = size - 1;

            do
            {
                if (items[middlePosiion] == itemSearch)
                {
                    value = middlePosiion + 1;
                }
                else if (items[middlePosiion] < itemSearch)
                {
                    middlePosiion = positionSearch(middlePosiion, initItems, true);
                }
                else
                {
                    middlePosiion = positionSearch(middlePosiion, initItems, false);
                }
            } while (value == -1);

            return value;
        }

        public static int positionSearch(int size, int lastSize, bool valueChange)
        {
            int position = 0;

            if (size / 2 > 0 && size > lastSize)
            {
                position = Convert.ToInt32(Math.Round(Convert.ToDouble(size) / 2, 0) - 1);
            }
            else
            {
                position = size;
                if (valueChange) position += 1;
                else position -= 1;
            }

            return position;

        }

        public static int recursiveBinarySearch(int[] items, int left, int right, int itemSearch)
        {
            if (right >= left)
            {
                int mid = Convert.ToInt32(Math.Round(Convert.ToDouble(left + (right - left) / 2), 0));

                if (items[mid] == itemSearch)
                {
                    return mid + 1;
                }
                else if (items[mid] < itemSearch)
                {
                    return recursiveBinarySearch(items, mid + 1, right, itemSearch);
                }
                else
                {
                    return recursiveBinarySearch(items, left, mid - 1, itemSearch);
                }
            }
            
            else return -1;

        }
    
    }
}
