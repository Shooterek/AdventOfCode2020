using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Day23 : Day
{
    public Day23(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        var input = _inputLoader.LoadStringListInput(_inputPath);
        var line = input[0];

        var linkedList = new CircularLinkedList<int>();
        foreach(var ch in line.ToCharArray()){
            linkedList.Insert((int)Char.GetNumericValue(ch));
        }
        var f = linkedList.Head;
        var maxMoves = 100;
        for(int i = 0; i < maxMoves; i++){
            PlayOneRound(linkedList, f);
            f = f.Next;
        }

        while(f.Value != 1){
            f = f.Next;
        }

        f = f.Next;
        for(int j = 0; j < 8; j++){
            Console.Write(f.Value);
            f = f.Next;
        }
        Console.WriteLine();

        return "";
    }

    private void PlayOneRound(CircularLinkedList<int> linkedList, CircularLinkedListNode<int> f)
    {
        CircularLinkedListNode<int> dest = FindDestinationCup(f);
        // Console.WriteLine("VALUE: " + f.Value + "&&& DEST: " + dest.Value);
        var currentNode = f;
        var firstCupToSwap = f.Next;
        var lastCupToSwap = f.Next.Next.Next;
        var t = dest.Next;
        
        f.Next = lastCupToSwap.Next;
        f.Next.Previous = f;

        dest.Next = firstCupToSwap;
        firstCupToSwap.Previous = dest;

        lastCupToSwap.Next = t;
        t.Previous = lastCupToSwap;
    }

    private CircularLinkedListNode<int> FindDestinationCup(CircularLinkedListNode<int> f)
    {
        var sw = new Stopwatch();
        CircularLinkedListNode<int> destinationCup = null;
        var temp = f.Next;
        var currentCupValue = f.Value;
        var nextCupValue = f.Value - 1;
        var counter = 1;

        sw.Start();

        var t = f.Next.Next.Next.Next;
        var min = Int32.MaxValue;
        while(t.Value != f.Value){
            if(t.Value < min){
                min = t.Value;
            }
            t = t.Next;
        }

        sw.Stop();
        Console.WriteLine(sw.Elapsed.Milliseconds);

        sw.Reset();
        sw.Start();
        while(destinationCup == null && nextCupValue >= min){
            if(temp.Value == nextCupValue){
                if(counter <= 3){
                    nextCupValue--;
                    temp = f;
                    counter = 0;
                }
                else{
                    destinationCup = temp;
                }
            }
            counter++;
            temp = temp.Next;
        }
        
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Milliseconds);
        sw.Reset();
        sw.Start();
        if(nextCupValue < min){
            CircularLinkedListNode<int> maxNode = null;
            var max = -1;
            var t2 = f.Next.Next.Next.Next;
            while(t2.Value != f.Value){
                if(t2.Value > max){
                    max = t2.Value;
                    maxNode = t2;
                }
                t2 = t2.Next;
            }
            return maxNode;
        }
        
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Milliseconds);
        Console.WriteLine("NEXT");

        return destinationCup;
    }
    public override string SecondTask()
    {
        var input = _inputLoader.LoadStringListInput(_inputPath);
        var line = input[0];

        var linkedList = new CircularLinkedList<int>();
        foreach(var ch in line.ToCharArray()){
            linkedList.Insert((int)Char.GetNumericValue(ch));
        }
        for(int i = 10; i <= 1000000; i++){
            linkedList.Insert(i);
        }
        var f = linkedList.Head;
        var maxMoves = 10000000;
        for(int i = 0; i < maxMoves; i++){
           Console.WriteLine(i);
            PlayOneRound(linkedList, f);
            f = f.Next;
        }

        while(f.Value != 1){
            f = f.Next;
        }

        f = f.Next;
        for(int j = 0; j < 8; j++){
            Console.Write(f.Value);
            f = f.Next;
        }
        Console.WriteLine();

        return "";
    }
}