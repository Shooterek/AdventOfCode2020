using System;
using System.Collections.Generic;
using System.Linq;

public class Day10 : Day
{
    public Day10(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        var input = _inputLoader.LoadIntListInput(_inputPath);
        input.Sort();

        return GetProductOfOneAndThreeJoltsAdapters(input).ToString();
    }

    public override string SecondTask()
    {
        var input = _inputLoader.LoadIntListInput(_inputPath);
        input.Add(0);
        input.Add(input.Max() + 3);
        input.Sort();

        return GetAllArrangements(input).ToString();
    }


    //One three jolts adapater difference comes from one adapter, which is always 3 jolts stronger than the strongest adapter from the list.
    private long GetProductOfOneAndThreeJoltsAdapters(List<int> adapters){
        
        int oneJoltDifferenceCounter = 0;
        int threeJoltsDifferenceCounter = 0;
        var currentJoltage = 0;

        for(int i = 0; i < adapters.Count; i++){
            if(adapters[i] - currentJoltage == 1){
                oneJoltDifferenceCounter++;
            }
            else if(adapters[i] - currentJoltage == 3){
                threeJoltsDifferenceCounter++;
            }

            currentJoltage = adapters[i];
        }

        return oneJoltDifferenceCounter * (threeJoltsDifferenceCounter + 1);
    }

    private long GetAllArrangements(List<int> adapters){
        long counter = 1;

        var requiredAdaptersIndexes = GetRequiredAdaptersIndexes(adapters);
        var lengthsOfSubsets = new List<int>();
        for(int i = 0; i < requiredAdaptersIndexes.Count - 1; i+= 2){
            lengthsOfSubsets.Add(requiredAdaptersIndexes[i + 1] - requiredAdaptersIndexes[i] + 1);
        }

        for(int j = 0; j < lengthsOfSubsets.Count; j++){
            if(lengthsOfSubsets[j] == 3){
                counter *= 2;
            }
            else if(lengthsOfSubsets[j] == 4){
                counter *= 4;
            }
            else if(lengthsOfSubsets[j] == 5){
                counter *= 7;
            }
        }
        return counter;
    }

    private List<int> GetRequiredAdaptersIndexes(List<int> adapters)
    {
        var indexes = new List<int>();
        var currentJoltage = -9999;
        
        for(int i = 0; i < adapters.Count - 1; i++){
            if(adapters[i + 1] - currentJoltage > 3){
                currentJoltage = adapters[i];
                indexes.Add(i);
                Console.WriteLine(adapters[i]);
            }
        }
        indexes.Add(adapters.Count - 1);

        return indexes;
    }
}