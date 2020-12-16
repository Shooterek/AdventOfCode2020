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
        throw new System.NotImplementedException();
    }
}