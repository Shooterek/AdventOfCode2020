using System;

public class Day18 : Day
{
    public Day18(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        long result = 0;
        var input = _inputLoader.LoadStringListInput(_inputPath);

        foreach(var line in input){
            result += EvaluateExpression(line.RemoveWhitespaceCharacters());
        }

        return result.ToString();
    }

    private long EvaluateExpression(string line)
    {
        long result = 0;
        var value = 0;
        for(int i = 0; i < line.Length;){
            if(line[i] == '('){
                var level = 1;
                var parenthesisLength = 1;
                while(level > 0){
                    if(line[i + parenthesisLength] == '('){
                        level++;
                    }
                    else if(line[i + parenthesisLength] == ')'){
                        level--;
                    }
                    parenthesisLength++;
                }
                if(i == 0 || line[i - 1] == '+'){   
                    result += EvaluateExpression(line.Substring(i + 1, parenthesisLength - 2));
                }
                else{
                    result *= EvaluateExpression(line.Substring(i + 1, parenthesisLength - 2));
                }
                i += parenthesisLength;
            }
            else if(char.IsDigit(line[i])){
                var length = 0;
                while(i + length < line.Length && char.IsDigit(line[i + length])){
                    length++;
                }
                value = Int32.Parse(line.Substring(i, length));
                if(i == 0 || line[i - 1] == '+'){
                    result += value;
                }
                else{
                    result *= value;
                }
                i += length;
            }
            else{
                i++;
            }
        }

        return result;
    }

    public override string SecondTask()
    {
        throw new System.NotImplementedException();
    }
}