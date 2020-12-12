using System;

public class Day11 : Day
{
    private readonly char _occupiedSeat = '#';
    private readonly char _floor = '.';
    private readonly char _emptySeat = 'L';
    public Day11(string inputPath) : base(inputPath)
    {
    }

    public override string FirstTask()
    {
        var input = _inputLoader.LoadStringListInput(_inputPath);
        var lineLength = input[0].Length;
        var linesCount = input.Count;
        var seats = new char[input.Count][];

        for(int i = 0; i < linesCount; i++){
            seats[i] = input[i].ToCharArray();
        }


        bool isChange = true;

        while(isChange){
            var temp = new char[linesCount][];
            for(int i = 0; i < seats.Length; i++){
                temp[i] = new char[lineLength];
                for(int j = 0; j < lineLength; j++){
                    temp[i][j] = seats[i][j];
                }
            }

            isChange = false;
            for(int y = 0; y < linesCount; y++){
                for(int x = 0; x < lineLength; x++){
                    if(temp[y][x] != _floor){
                        int occupiedAdjacentSeats = CountOccupiedAdjacentSeats(temp, x, y);
                        if(occupiedAdjacentSeats == 0){
                            if(seats[y][x] != _occupiedSeat){
                                isChange = true;
                            }
                            seats[y][x] = _occupiedSeat;
                        }
                        else if(occupiedAdjacentSeats >= 4){
                            if(seats[y][x] != _emptySeat){
                                isChange = true;
                            }
                            seats[y][x] = _emptySeat;
                        }
                    }
                }
            }
        }

        var counter = 0;
        for(int i = 0; i < seats.Length; i++){
            for(int j = 0; j < lineLength; j++){
                if(seats[i][j] == _occupiedSeat){
                    counter++;
                }
            }
        }
        return counter.ToString();
    }


    public override string SecondTask()
    {
        var input = _inputLoader.LoadStringListInput(_inputPath);
        var lineLength = input[0].Length;
        var linesCount = input.Count;
        var seats = new char[input.Count][];

        for(int i = 0; i < linesCount; i++){
            seats[i] = input[i].ToCharArray();
        }


        bool isChange = true;
        while(isChange){
            var temp = new char[linesCount][];
            for(int i = 0; i < seats.Length; i++){
                temp[i] = new char[lineLength];
                for(int j = 0; j < lineLength; j++){
                    temp[i][j] = seats[i][j];
                }
            }

            isChange = false;
            for(int y = 0; y < linesCount; y++){
                for(int x = 0; x < lineLength; x++){
                    if(temp[y][x] != _floor){
                        int occupiedAdjacentSeats = CountOccupiedSeatsInAllDirections(temp, x, y);
                        if(occupiedAdjacentSeats == 0){
                            if(seats[y][x] != _occupiedSeat){
                                isChange = true;
                            }
                            seats[y][x] = _occupiedSeat;
                        }
                        else if(occupiedAdjacentSeats >= 5){
                            if(seats[y][x] != _emptySeat){
                                isChange = true;
                            }
                            seats[y][x] = _emptySeat;
                        }
                    }
                }
            }
        }

        var counter = 0;
        for(int i = 0; i < seats.Length; i++){
            for(int j = 0; j < lineLength; j++){
                if(seats[i][j] == _occupiedSeat){
                    counter++;
                }
            }
        }
        return counter.ToString();
    }
    private int CountOccupiedAdjacentSeats(char[][] seats, int x, int y)
    {
        var counter = 0;
        for(int i = x - 1; i < x + 2; i++){
            for(int j = y - 1; j < y + 2; j++){
                if(i == x && j == y){
                    continue;
                }
                counter += CheckIfSeatIsOccupied(seats, i, j);
            }
        }

        return counter;
    }

    private int CheckIfSeatIsOccupied(char[][] seats, int x, int y)
    {
        if(x < 0 || x >= seats[0].Length || y < 0 || y >= seats.Length){
            return 0;
        }

        return seats[y][x] == _occupiedSeat ? 1 : 0;
    }

    private int CountOccupiedSeatsInAllDirections(char[][] seats, int x, int y)
    {
        var counter = 0;
        counter += CheckDirection(seats, x, y, -1, -1);
        counter += CheckDirection(seats, x, y, -1, 0);
        counter += CheckDirection(seats, x, y, -1, 1);
        counter += CheckDirection(seats, x, y, 0, 1);
        counter += CheckDirection(seats, x, y, 0, -1);
        counter += CheckDirection(seats, x, y, 1, -1);
        counter += CheckDirection(seats, x, y, 1, 0);
        counter += CheckDirection(seats, x, y, 1, 1);

        return counter;
    }

    private int CheckDirection(char[][] seats, int x, int y, int xDir, int yDir)
    {
        for(int i = x + xDir, j = y + yDir; i < seats[0].Length && i >= 0 && j < seats.Length && j >= 0; i += xDir, j += yDir){
            if(seats[j][i] != _floor){
                return CheckIfSeatIsOccupied(seats, i, j);
            }
        }

        return 0;
    }
}