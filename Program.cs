using System;
using System.Text.RegularExpressions;

namespace Compiladores_P1_1040121
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string cadenaEntrada = "";
                do
                {
                    Console.WriteLine("Esciba la expresion a utilizar\nUn ejemplo puede ser \"if variable1 then 8\"\nEstas son las palabras reservadas \"if\", \"then\", \"else_if\", \"else\"");
                    cadenaEntrada = Console.ReadLine();
                } while (cadenaEntrada =="");


                AutomataPila automataPila = new AutomataPila();
                List<string> tokens = tokenizar(cadenaEntrada);

                int resultado = automataPila.parsear(tokens);

                if (resultado == 0)
                {
                    Console.WriteLine("El programa detecto que la Pila no esta vacia, por lo cual quedo mal la pila");
                }
                else
                {
                    Console.WriteLine("Todo salio bien, el automata pudo parsear la expresion");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            Console.ReadKey();
        }

        static private List<string> tokenizar(string cadenaEntada)
        {
            List<string> tokens = new List<string>();
            string[] palabras = cadenaEntada.Split(' ');
            foreach (string palabra in palabras)
            {
                if (palabra == "if" || palabra == "then" || palabra == "else_if" || palabra =="else")
                {
                    tokens.Add(palabra);
                }
                else
                {
                    if (Regex.IsMatch(palabra, "^[a-zA-Z_][a-zA-Z0-9_]*$"))
                    {
                        tokens.Add("ID");
                    }
                    else if (Regex.IsMatch(palabra, "^[0-9]*$"))
                    {
                        tokens.Add("Num");
                    }
                }

            }
            tokens.Add("eof");
            return tokens;

        }
    }
}
