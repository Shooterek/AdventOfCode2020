using System;
using System.Collections.Generic;
using System.Text;

public class StringToFormula
{
    private string[] _operators = { "-", "+", "/", "*","^"};
    private  Func<long, long, long>[] _operations = {
        (a1, a2) => a1 - a2,
        (a1, a2) => a1 + a2,
        (a1, a2) => a1 / a2,
        (a1, a2) => a1 * a2
    };

    public long Eval(string expression)
    {
        List<string> tokens = getTokens(expression);
        Stack<long> operandStack = new Stack<long>();
        Stack<string> operatorStack = new Stack<string>();
        int tokenIndex = 0;

        while (tokenIndex < tokens.Count) {
            string token = tokens[tokenIndex];
            if (token == "(") {
                string subExpr = getSubExpression(tokens, ref tokenIndex);
                operandStack.Push(Eval(subExpr));
                continue;
            }
            if (token == ")") {
                throw new ArgumentException("Mis-matched parentheses in expression");
            }
            //If this is an operator  
            if (Array.IndexOf(_operators, token) >= 0) {
                while (operatorStack.Count > 0 && Array.IndexOf(_operators, token) < Array.IndexOf(_operators, operatorStack.Peek())) {
                    string op = operatorStack.Pop();
                    long arg2 = operandStack.Pop();
                    long arg1 = operandStack.Pop();
                    operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
                }
                operatorStack.Push(token);
            } else {
                operandStack.Push(long.Parse(token));
            }
            tokenIndex += 1;
        }

        while (operatorStack.Count > 0) {
            string op = operatorStack.Pop();
            long arg2 = operandStack.Pop();
            long arg1 = operandStack.Pop();
            operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
        }
        return operandStack.Pop();
    }

    private string getSubExpression(List<string> tokens, ref int index)
    {
        StringBuilder subExpr = new StringBuilder();
        int parenlevels = 1;
        index += 1;
        while (index < tokens.Count && parenlevels > 0) {
            string token = tokens[index];
            if (tokens[index] == "(") {
                parenlevels += 1;
            }

            if (tokens[index] == ")") {
                parenlevels -= 1;
            }

            if (parenlevels > 0) {
                subExpr.Append(token);
            }

            index += 1;
        }

        if ((parenlevels > 0)) {
            throw new ArgumentException("Mis-matched parentheses in expression");
        }
        return subExpr.ToString();
    }

    private List<string> getTokens(string expression)
    {
        string operators = "()^*/+-";
        List<string> tokens = new List<string>();
        StringBuilder sb = new StringBuilder();

        foreach (char c in expression.Replace(" ", string.Empty)) {
            if (operators.IndexOf(c) >= 0) {
                if ((sb.Length > 0)) {
                    tokens.Add(sb.ToString());
                    sb.Length = 0;
                }
                tokens.Add(c.ToString());
            } else {
                sb.Append(c);
            }
        }

        if ((sb.Length > 0)) {
            tokens.Add(sb.ToString());
        }
        return tokens;
    }
}