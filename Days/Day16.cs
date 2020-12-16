using System;
using System.Collections.Generic;
using System.Linq;

public class Day16 : Day
{
    public Day16(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        var input = _inputLoader.LoadTicketRules(_inputPath);

        var sumOfInvalidValues = 0;
        foreach(var ticket in input.NearbyTickets){
            foreach(var ticketValue in ticket){
                var canBeValid = false;
                foreach(var rule in input.TicketRules){
                    if(rule.CheckIfValueIsValid(ticketValue)){
                        canBeValid = true;
                        break;
                    }
                }
                if(canBeValid == false){
                    sumOfInvalidValues += ticketValue;
                }
            }
        }

        return sumOfInvalidValues.ToString();
    }

    public override string SecondTask()
    {
        var input = _inputLoader.LoadTicketRules(_inputPath);
        var invalidTickets = new List<List<int>>();
        foreach(var ticket in input.NearbyTickets){
            foreach(var ticketValue in ticket){
                var canBeValid = false;
                foreach(var rule in input.TicketRules){
                    if(rule.CheckIfValueIsValid(ticketValue)){
                        canBeValid = true;
                        break;
                    }
                }
                if(canBeValid == false){
                    invalidTickets.Add(ticket);
                }
            }
        }

        foreach(var ticket in invalidTickets){
            input.NearbyTickets.Remove(ticket);
        }

        long returnValue = 1;
        while(input.TicketRules.Count > 0){
            for(int i = 0; i < input.NearbyTickets[0].Count; i++){
                var validRulesCount = new Dictionary<int, int>();
                for(int b = 0; b < input.TicketRules.Count; b++){
                    validRulesCount[b] = 0;
                }
                for(int j = 0; j < input.TicketRules.Count; j++){
                    var rule = input.TicketRules[j];
                    for(int z = 0; z < input.NearbyTickets.Count; z++){
                        if(rule.CheckIfValueIsValid(input.NearbyTickets[z][i])){
                            validRulesCount[j] = validRulesCount[j] + 1; 
                        }
                    }
                }

                if(validRulesCount.Values.Where(v => v == input.NearbyTickets.Count).Count() == 1){
                    var rule = validRulesCount.First(x => x.Value == input.NearbyTickets.Count);
                    Console.WriteLine(input.TicketRules[rule.Key].PropertyName + " " + i);
                    if(input.TicketRules[rule.Key].PropertyName.Contains("departure")){
                        returnValue *= input.MyTicket[i];
                    }
                    input.TicketRules.RemoveAt(rule.Key);
                }
            }
        }


        return returnValue.ToString();
    }
}