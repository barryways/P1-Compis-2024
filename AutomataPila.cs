using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_P1_1040121
{
    public class AutomataPila
    {
        private Stack<string> pila;
        public AutomataPila()
        {
            pila = new Stack<string>();
        }
        public int parsear(List<string> tokens)
        {
            pila.Push("S");

            while (tokens.Count() != 0)
            {
                string lookahead = tokens[0];
                switch (pila.Peek())
                {
                    case "if":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "else_if":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "else":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "then":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "ID":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "Num":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;
                    case "eof":
                        {
                            if (pila.Peek() == lookahead)
                            {
                                tokens.Remove(tokens[0]);
                                pila.Pop();
                            }
                            else
                            {
                                throw new Exception("Se esperaba " + pila.Peek() + " y se encontro " + lookahead);
                            }
                        }
                        break;

                    case "if_stmt":
                        {
                            pila.Pop();
                            pila.Push("eof");
                            pila.Push("else_part");
                            pila.Push("else_if_part");
                            pila.Push("stmt");
                            pila.Push("then");
                            pila.Push("expr");
                            pila.Push("if");
                        }
                        break;
                    case "else_if_part":
                        {
                            if (lookahead == "else_if")
                            {
                                pila.Pop();
                                pila.Push("expr");
                                pila.Push("then");
                                pila.Push("stmt");
                                pila.Push("else_if_part");
                                pila.Push("else_if");
                            }
                            else
                            {
                                pila.Pop();
                            }
                        }
                        break;
                    case "else_part":
                        {
                            if (lookahead == "else")
                            {

                                pila.Pop();
                                pila.Push("stmt");
                                pila.Push("else");
                            }
                            else
                            {
                                pila.Pop();
                            }
                        }
                        break;
                    case "stmt":
                        {
                            if (lookahead == "ID")
                            {
                                pila.Pop();
                                pila.Push("ID");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("Num");
                            }

                        }
                        break;
                    case "expr":
                        {
                            if (lookahead == "ID")
                            {
                                pila.Pop();
                                pila.Push("ID");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("Num");
                            }
                        }
                        break;

                    case "S":
                        {
                            pila.Pop();
                            pila.Push("if_stmt");
                        }
                        break;

                }
            }
            if (pila.Count() > 0)
                return 0;
            else
                return 1;
        }
    }
}
