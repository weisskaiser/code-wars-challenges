using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars.Challenges3Kyu.Calculator
{
    public class Calculator
    {
        public double Evaluate(string expression)
        {
            var postfixNotation = ToPostfixNotation(expression.Replace(" ", ""));
            
            return EvaluatePostfix(postfixNotation);
        }

        protected double EvaluatePostfix(string postfix)
        {
            var evalStack = new Stack<double>();
            
            foreach (var token in postfix.Split(' '))
            {
                if (double.TryParse(token, out var n))
                {
                    evalStack.Push(n);
                }
                else
                {
                    if (token[0] == '!')
                    {
                        evalStack.Push(-evalStack.Pop());
                        continue;
                    }
                    
                    var n2 = evalStack.Pop();
                    var n1 = evalStack.Pop();
                    evalStack.Push(token[0] switch
                    {
                        '/' => n1 / n2,
                        '*' => n1 * n2,
                        '+' => n1 + n2,
                        '-' => n1 - n2,
                        _ => throw new ArgumentOutOfRangeException(nameof(token),$"Operator [ {token} ] is not supported"),
                    });
                }
            }

            return evalStack.Pop();
        }

        protected string ToPostfixNotation(string expression)
        {
            var builder = new StringBuilder();
            var operations = new Stack<char>();
            var precedenceByOperator = new Dictionary<char,int>
            {
                ['+']=1, 
                ['-']=1, 
                ['*']=2, 
                ['/']=2,
                ['!']=3,
            };

            for (var index = 0; index < expression.Length; index++)
            {
                var c = expression[index];
                var lstC = index > 0 ? (char?) expression[index-1] : null;
                
                if (char.IsDigit(c) || c == '.')
                {
                    builder.Append(c);
                }
                else if (precedenceByOperator.ContainsKey(c))
                {
                    if (c == '-' && 
                        (lstC is null ||
                         precedenceByOperator.ContainsKey(lstC.Value) ||
                         lstC is '(' 
                         ))
                    {
                        c = '!';
                    }

                    while (operations.Count != 0
                           && operations.Peek() != '('
                           && precedenceByOperator[operations.Peek()] >= precedenceByOperator[c]
                    )
                    {
                        if (builder.Length > 0 && builder[^1] != ' ') builder.Append(" ");
                        builder.Append(operations.Pop());
                    }

                    if (builder.Length > 0 && builder[^1] != ' ') builder.Append(" ");

                    operations.Push(c);
                    
                }
                else if (c == '(')
                {
                    operations.Push(c);
                }
                else if (c == ')')
                {
                    var matchFound = false;
                    while (operations.TryPop(out var op))
                    {
                        if (op == '(')
                        {
                            matchFound = true;
                            break;
                        }

                        builder.Append(" " + op);
                    }

                    if (!matchFound)
                    {
                    }
                }
            }

            while (operations.TryPop(out var op))
            {
                if(op == ')' || op == '(') throw new ArgumentException("Unbalanced parentheses on the given expression");
                
                builder.Append(" "+op);
            }

            return builder.ToString();
        }
    }
}