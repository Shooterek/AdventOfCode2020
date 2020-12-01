using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InputLoader{
    public List<string> LoadStringListInput(string filepath){
        return File.ReadAllLines(filepath).ToList();
    }

    public List<int> LoadIntListInput(string filepath){
        List<int> input = new List<int>();
        foreach(var line in File.ReadAllLines(filepath)){
            input.Add(int.Parse(line));
        }

        return input;
    }
}