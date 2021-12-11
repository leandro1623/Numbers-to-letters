using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformador
{
    public static class TransformNumbersToLetters
    {
        //Cifra mas alta traducida 999,999,999,999

        public static void Tranform_And_Show_In_The_Console_The_Result()
        {
                        string resultado = "";//varible que almacenara el resultado
            Console.Write("Type the value to transform to letters (The max value to transform is 999,999,999,999 don't type a bigger number): ");
            string input = Console.ReadLine();//tomando el valor digitado 

            if (VerifyingNumberTyped(input))
            {
                if (input.Length <= 3)//si el tamano de input es menor o igual a tres
                {
                    resultado += ProcesarTresDigitos(input);//suma el resultado de la funcion a la variable resultado
                }
                else//si no es ni menor ni igual a tres
                {
                    List<string> Grupos = obtenerGruposDeTres(input);//crea una lista generica llamada Grupos y divide en grupos de tres el texto igresado desde la consola

                    if (input.Length > 3 && input.Length < 7)//Procesa digitos de miles
                    {

                        resultado += Mil(Grupos);

                    }
                    else if (input.Length > 6 && input.Length < 10)//Procesa digitos de millones
                    {
                        resultado += Millones(Grupos);
                    }
                    else if (input.Length > 9 && input.Length < 13)//procesa los miles de millones tambien llamados billones en EEUU
                    {
                        if (Grupos[0] != "1")
                        {
                            resultado += ProcesarTresDigitos(Grupos[0]);
                            resultado += " mil ";
                            List<string> _Millones = new List<string>();
                            _Millones.Add(Grupos[1]);
                            _Millones.Add(Grupos[2]);
                            _Millones.Add(Grupos[3]);
                            resultado += Millones(_Millones);
                            //resultado += milesMillones;
                        }
                        else
                        {
                            resultado += " mil ";
                            List<string> _Millones = new List<string>();
                            _Millones.Add(Grupos[1]);
                            _Millones.Add(Grupos[2]);
                            _Millones.Add(Grupos[3]);
                            resultado += Millones(_Millones);
                            //resultado += milesMillones;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry the typed number doesn't have the correct format to transform");
            }

            Console.Clear();
            Console.Write("The result of transform the value '{0}' to letters is, '{1}'",input, Tranform_And_Return_The_Value_As_String(input));//muestr el resultado
            Console.ReadKey();//no eja que la consola se cierre
        }//fin

        public static string Tranform_And_Return_The_Value_As_String(string input)
        {
            string resultado="";//aqui estara el resultado final

            if (VerifyingNumberTyped(input))
            {
                if (input.Length <= 3)//si el tamano de input es menor o igual a tres
                {
                    resultado += ProcesarTresDigitos(input);//suma el resultado de la funcion a la variable resultado
                }
                else//si no es ni menor ni igual a tres
                {
                    List<string> Grupos = obtenerGruposDeTres(input);//crea una lista generica llamada Grupos y divide en grupos de tres el texto igresado desde la consola

                    if (input.Length > 3 && input.Length < 7)//Procesa digitos de miles
                    {

                        resultado += Mil(Grupos);

                    }
                    else if (input.Length > 6 && input.Length < 10)//Procesa digitos de millones
                    {
                        resultado += Millones(Grupos);
                    }
                    else if (input.Length > 9 && input.Length < 13)//procesa los miles de millones tambien llamados billones en EEUU
                    {
                        if (Grupos[0] != "1")
                        {
                            resultado += ProcesarTresDigitos(Grupos[0]);
                            resultado += " mil ";
                            List<string> _Millones = new List<string>();
                            _Millones.Add(Grupos[1]);
                            _Millones.Add(Grupos[2]);
                            _Millones.Add(Grupos[3]);
                            resultado += Millones(_Millones);
                            //resultado += milesMillones;
                        }
                        else
                        {
                            resultado += " mil ";
                            List<string> _Millones = new List<string>();
                            _Millones.Add(Grupos[1]);
                            _Millones.Add(Grupos[2]);
                            _Millones.Add(Grupos[3]);
                            resultado += Millones(_Millones);
                            //resultado += milesMillones;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry the typed number doesn't have the correct format to transform");
            }
            return resultado;
        }//fin

        private static string[] unidades = new string[]//representa la unidades 0-9
        {
            "cero","uno","dos","tres","cuatro","cinco","seis","siete","ocho","nueve",
        };

        private static string[] Decenas = new string[]//representa las decenas 10-90
        {
            "cero","diez","vente","trenta","cuarenta","cincuenta","sesenta","setenta","ochenta","noventa"
        };

        private static string[] Onces = new string[]//representa los numero entre 10 y 20
        {
            "Diez","once","doce","trece","catorce","quince","Dieciseis","diesiciete","diesciocho","diescinueve"
        };

        private static string[] Centenas = new string[]//representa las centenas 100-900
        {
            "cero","cien","dociento ","treciento ","cuatrociento ","Quiniento ","seiciento ","seteciento ","ochociento ","noveciento "
        };

        private static bool VerifyingNumberTyped(string Number)
        {
            long number;
            return (long.TryParse(Number, out number) && number > -1 && number <= 999999999999) ? true : false;
        }

        private static List<string> obtenerGruposDeTres(string input)//Divide en grupos e tres el texto de entrada y devuelve un List<string>
        {
            List<string> Resultado = new List<string>();//crea el List<string>
            int Resto = input.Length % 3;//Busca si hay Gurpos incompletos
            int Inicio = 0;//variale que representa las posciciones de los grupos

            if (Resto != 0)//si hay grupos incompletos
            {
                Resultado.Add(input.Substring(0, Resto));// buscalo y agregalo
                Inicio = Resto;//toma la siguiente poscicion
            }
            for (int i = Inicio; i < input.Length; i += 3)//ve gurdando de grupo en grupo a Resultado (en este punto ya no hay grupos incompletos
            {
                Resultado.Add(input.Substring(i, 3));//Agrega de tres en tres
            }
            return Resultado;//retorna el resultado
        }

        private static string Mil(List<string> Grupos)//procesa los digitos de miles
        {
            if (Grupos[0].Substring(0, 1) != "0")
            {
                if (Grupos[0] != "1")//si la cifra es mas de mil (1000)
                {
                    string grupoMil = ProcesarTresDigitos(Grupos[0]);
                    grupoMil += " mil ";
                    grupoMil += ProcesarTresDigitos(Grupos[1]);
                    return grupoMil;
                }
                else //Si no lo es
                {
                    return "Mil " + ProcesarTresDigitos(Grupos[1]);
                }
            }
            return null;
        }

        private static string Millones(List<string> Grupos) //Procesa los millones
        {
            if (Grupos[0] != "1")//si la cifra es mas de 1 millon
            {
                string GrupoMillon = ProcesarTresDigitos(Grupos[0]);
                List<string> GrupoMil = new List<string>();
                GrupoMil.Add(Grupos[1]);
                GrupoMil.Add(Grupos[2]);
                GrupoMillon += " millones " + Mil(GrupoMil);
                return GrupoMillon;
            }
            else//si no lo es
            {
                List<string> miles = new List<string>();
                miles.Add(Grupos[1]);
                miles.Add(Grupos[2]);
                return "Un millon " + Mil(miles);
            }
        }

        private static string ProcesarTresDigitos(string input)//funcion principal que devuelve l transformacion de un numero de tres digitos
        {
            string resultado = ""; //variable que guarda el resultado final
            if (input != "000" && input != "00" && input != "0")//si los digitos no son ceros
            {

                if (input.Length == 3 && input[0].ToString() != "0")//--Procesando el 3er digito---------------3----------------------------------------
                {
                    int inputCentenaA = int.Parse(input[0].ToString());//lo combierte en un entero
                    resultado += Centenas[inputCentenaA];//busca su correspondiente significado
                    if (int.Parse(input[1].ToString()) == 0 && int.Parse(input[2].ToString()) == 0)//Si las sigtes cifras son cerros
                    {
                        return resultado;//retorna
                    }
                    else if (inputCentenaA == 1)//si no
                    {
                        resultado += "to ";//agrega 'to' al resultado
                    }
                }
                if (input.Length >= 2)//--Procesando el 2do digito------------------------------------2------------------------------------------
                {
                    if (input.Length > 2 && input[1] != '0')//--si el tamano es mayor a 2 y es diferente de cero (0)-----------------2.1---------------------------------------
                    {
                        int numero = int.Parse(input.Substring(1, 2));//obtiene la sub cadena y lo comvierte en un entero  
                        if (numero < 20 && numero > 10)//si es un numero entre 11 y 19
                        {
                            int inputCentenaB = int.Parse(input[2].ToString());//obtiene el numero a comparar
                            resultado += Onces[inputCentenaB];//compara y agrega a la variable resultado
                            return resultado;//retorna
                        }
                        else//si no lo es
                        {
                            int inputCentenaC = int.Parse(input[1].ToString()); ;//obtiene el numero a comparar
                            resultado += Decenas[inputCentenaC];//compara y agrega a la variable resultado
                            if (input[2] == '0')//si el ultimo digito es u cero
                            {
                                return resultado;//retornalo
                            }
                            else//si no
                            {
                                resultado += " y ";//agrega 'y'
                            }
                        }
                    }
                    if (input.Length == 2)//--si el tamano es igual a 2 --------------2.2----------------------------------------
                    {
                        int numero = int.Parse(input);//obtiene el cadena y lo combierte en un entero
                        if (numero < 20 && numero >= 10)//si es un numero entre 11 y 19
                        {
                            int inputint = int.Parse(input[1].ToString());//obtiene un digito de la cadena y lo combierte en un entero
                            resultado += Onces[inputint];//compara y agrega
                            return resultado;//retorna
                        }
                        else if (numero > 19)//si es mayor a 19
                        {
                            int inputint = int.Parse(input[0].ToString());//obtiene un digito de la cadena y lo combierte en un entero
                            resultado += Decenas[inputint];//compara y agrega

                            if (input[1] == '0')//si el caracter de igual a cero
                            {
                                return resultado;//retorna
                            }
                            else//si no
                            {
                                resultado += " y ";//agrega 'y'
                            }
                        }
                    }
                }
                if (input.Length >= 1)//--Procesa el ultimo digito---------------------------------------------unos------------------------------------
                {
                    if (input.Length == 3)//si el tamano es igual a tres
                    {
                        int inputInt = int.Parse(input[2].ToString());//combierte el caracte en un int
                        resultado += unidades[inputInt];//compara y agrega
                    }
                    else if (input.Length == 1)//si el tamano es igual a 1
                    {
                        int inputCentenaC = int.Parse(input.ToString());//combierte el caracte en un int
                        resultado += unidades[inputCentenaC];//compara y agrega
                    }
                    else//si no 
                    {
                        int inputInt = int.Parse(input[1].ToString());//combierte el caracte en un int
                        resultado += unidades[inputInt];//compara y agrega
                    }
                }
            }
            return resultado;//restorn el resultado
        }
    }
}
