using System;

public class Day12 : Day
{
    public Day12(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        var instructions = _inputLoader.LoadStringListInput(_inputPath);
        
        var currentPosition = new FerryPosition();

        foreach(var instruction in instructions){
            ChangePosition(currentPosition, instruction);
        }

        var manhattanDistance = Math.Abs(currentPosition.NorthSouthPosition) + Math.Abs(currentPosition.EastWestPosition);

        return manhattanDistance.ToString();
    }

    private void ChangePosition(FerryPosition currentPosition, string instruction)
    {
        var action = instruction[0];
        var value = Int32.Parse(instruction.Substring(1, instruction.Length - 1));
        var currentDirectionValue = (int)currentPosition.FerryDirection;

        switch(action){
            case 'L':
                currentPosition.FerryDirection = (Direction)Mod(currentDirectionValue - value / 90, 4);
                Console.WriteLine(currentPosition.FerryDirection);
                break;

            case 'R':
                currentPosition.FerryDirection = (Direction)Mod(currentDirectionValue + value / 90, 4);
                Console.WriteLine(currentPosition.FerryDirection);
                break;

            case 'F':
                MoveInDirection(currentPosition, currentPosition.FerryDirection, value);
                break;
            
            case 'N':
            case 'S':
            case 'E':
            case 'W':
                var direction = ConverCharToDirection(action);
                MoveInDirection(currentPosition, direction, value);
                break;
        }
    }

    private Direction ConverCharToDirection(char action)
    {
        switch(action){
            case 'E':
                return Direction.East;

            case 'S':
                return Direction.South;

            case 'W':
                return Direction.West;

            case 'N':
                return Direction.North;
        }

        throw new ArgumentException("Incorrect direction");
    }

    private void MoveInDirection(FerryPosition currentPosition, Direction ferryDirection, int value)
    {
        switch(ferryDirection){
            case Direction.East:
                currentPosition.EastWestPosition += value;
                break;
                
            case Direction.West:
                currentPosition.EastWestPosition -= value;
                break;
                
            case Direction.North:
                currentPosition.NorthSouthPosition += value;
                break;
                
            case Direction.South:
                currentPosition.NorthSouthPosition -= value;
                break;
        }
    }

    private int Mod(int x, int m) {
        return (x%m + m)%m;
    }

    public override string SecondTask()
    {
        throw new System.NotImplementedException();
    }
}