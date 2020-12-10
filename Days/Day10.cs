using System;
using System.Collections.Generic;

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
        input.Sort();

        return GetAllArrangements(input).ToString();
    }


    //One three jolts difference comes from one adapter, which is always 3 jolts stronger than the strongest adapter from the list.
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
        long counter = 0;

        for(int i = 0; i < adapters.Count; i+= 3){
            var possibleMoves = CountPossibleMoves(adapters, i);
            var posMOves2 = CountPossibleMoves(adapters, i + 1);
            Console.WriteLine(counter);
            counter += possibleMoves * posMOves2;
        }

        return counter;
    }

    private int CountPossibleMoves(List<int> adapters, int startingIndex){
        var temp = 0;
        for(int j = 0; j < 3 && startingIndex + j < adapters.Count; j++){
            if(adapters[startingIndex + j] - adapters[startingIndex] <= 3){
                temp++;
            }
        }

        return temp;
    }
}