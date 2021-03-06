using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace calculator
{
    class RPN 
    {
        static public double Calculate(string input)
        {
            try { return double.Parse(GetExpression(input));}
            catch (Exception) { return Counting(GetExpression(input));}
            
        }

        static private string GetExpression(string input)
        {
            string output = string.Empty; 
            string fun = string.Empty; 
            Stack<char> operStack = new Stack<char>();
            char k = ' '; string p = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (IsOperator(input[i]) || Char.IsDigit(input[i]))
                {
                    if (k == ' ')
                    k = input[i];
                    else
                        if (input[i] == '-' && !Char.IsDigit(k))
                            p += " 0 ";
                    k = input[i];
                }         
                p += input[i];
            }
            input = p;
            for (int i = 0; i < input.Length; i++) 
            {
                if (IsDelimeter(input[i]))
                    continue;
                if (Char.IsDigit(input[i])) 
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; 
                        i++;
                        if (i == input.Length) break; 
                    }
                    output += " "; 
                    i--; 
                }
                else
                    if (IsOperator(input[i])) 
                    {
                        if (input[i] == '(') 
                            operStack.Push(input[i]); 
                        else if (input[i] == ')')
                        {
                            char s = operStack.Pop();
                            while (s != '(')
                            {
                                output += s.ToString() + ' ';
                                s = operStack.Pop();
                            }
                        }
                        else
                        {
                            if (operStack.Count > 0) 
                                if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                    output += operStack.Pop().ToString() + " "; 

                            operStack.Push(char.Parse(input[i].ToString()));

                        }
                    }
                    else if (input[i] == '\u03C0')
                        output += " \u03C0 ";
                    else if (input[i] == 'e')
                        output += " e ";
                    else
                    {
                        fun = String.Empty;
                        while (input[i] != '(')
                        {
                            fun += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        i++;
                    }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";
            
                return output;
        }

        static private double Counting(string input)
        {
            double result = 0;
            double b = 0;
            Stack<double> temp = new Stack<double>(); 
            try { return double.Parse(input); }
            catch (Exception)
            {
                for (int i = 0; i < input.Length; i++) 
                {
                    if (Char.IsDigit(input[i]))
                    {
                        string a = string.Empty;

                        while (!IsDelimeter(input[i]) && !IsOperator(input[i])) 
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(double.Parse(a)); 
                        i--;
                    }
                    else if (input[i] == '\u03C0')
                        temp.Push(Math.PI);
                    else if (input[i] == 'e')
                        temp.Push(Math.E);
                    else if (IsOperator(input[i])) 
                    {
                        double a = temp.Pop();
                        try
                        { b = temp.Pop(); }
                        catch (Exception) { b = 0; }

                        switch (input[i])
                        {
                            case '!': result = factorial((int)a); break;
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '/': if (a == 0) throw new DividedByZeroException(); else result = b / a; break;
                        }
                        temp.Push(result);
                    }
                }
                try { return temp.Peek(); }
                catch (Exception) { throw new SyntaxException(); }
                
            }
            
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*^()PC!%".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '!': return 4;
                case '%': return 4;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 4;
            }
        }
        private static int factorial(int x)
        {
            int i = 1;
            for (int s = 1; s <= x; s++)
                i = i * s;
            if (x < 0) throw new NegativeFactorialException(x);
            return i;
        }
    }
    public class MyException : Exception
    {
        public string type;
    }
    public class NegativeFactorialException : MyException
    {
        public NegativeFactorialException(int x)
        {
            this.type = "Ошибка вычисления";
            MessageBox.Show("Факториал(" + x + ") не существует", type, MessageBoxButtons.OK);
        }
    }
    public class DividedByZeroException : MyException
    {
        public DividedByZeroException()
        {
            this.type = "Ошибка вычисления";
            MessageBox.Show("Деление на ноль невозможно", type, MessageBoxButtons.OK);
        }
    }
    public class SyntaxException : MyException
    {
        public SyntaxException()
        {
            this.type = "Ошибка синтаксиса";
            MessageBox.Show("Выражение введено неверно", type, MessageBoxButtons.OK);
        }
    }
}
