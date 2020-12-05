using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class InputLoader{
    public List<string> LoadStringListInput(string filepath){
        return File.ReadAllLines(filepath)
            .ToList();
    }

    public List<int> LoadIntListInput(string filepath){
        List<int> input = new List<int>();
        foreach(var line in File.ReadAllLines(filepath)){
            input.Add(int.Parse(line));
        }

        return input;
    }

    public List<string> LoadStringBatches(string filepath){
        var batches = File.ReadAllText(filepath)
            .Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(batch => batch.Replace('\n', ' '))
            .ToList();
        return batches;    
    }
}