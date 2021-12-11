using System;
using System.Collections.Generic;                                 //Cifra mas alta traducida 999,999,999,999

namespace Transformador
{
    class Program
    {
        static void Main()//-metodo main----------------------------------------
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("Transformador de numeros a letras ( Transformer from numbers to letters )\n");
                Console.Write("1. Spanish\n2. English\n3. Leave\n\nOption: ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                if (option == 1)
                {
                    Spanish_Transform_Numbers_To_Letters.Tranform_And_Show_In_The_Console_The_Result();
                }
                else if (option == 2)
                {
                    Console.Write("Type the value to transform to letters (The max value transformed is 999,999,999,999 don't type a bigger number): ");
                    string input = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("The result of transform the value '{0}' to letters is, '{1}'",input,Inglish_Vertion_of_Transform_Numbers_To_Letters.Tranform_And_Return_The_Value_As_StringInglish(input));
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option");
                    Console.ReadKey();
                }

            } while (option != 3);
        }//-------------fin main-------------------------------------------------
    }
}