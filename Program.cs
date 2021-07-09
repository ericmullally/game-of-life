//Conway's Game of Life

//rules:
/*
Any live cell with fewer than two live neighbours dies, as if by underpopulation.
Any live cell with two or three live neighbours lives on to the next generation.
Any live cell with more than three live neighbours dies, as if by overpopulation.
Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
 
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace game_of_life
{
    class Program
    {

        
        const int rowSize = 20;
        const int columnSize = 110;
        static void Main(string[] args)
        {
            List<List<char>>  world  = seed();
            display(world);

            List<List<char>> newWorld = evaluate(world);
            while (true)
            {
                display(newWorld);
                newWorld = evaluate(newWorld);

            }
            
        }
    
        static List<List<char>> seed()
        {
            //create the initial world with random numbers.
            List<List<char>> matrix = new List<List<char>>();

            for (int i = 0; i < rowSize + 1; i++)
            {
                matrix.Add(new List<char>());

                for(int j =0; j < columnSize + 1; j++)
                {
                    Random num = new Random();
                    int liveOrDead = num.Next(0, 2);
                    if (liveOrDead > 0)
                    {
                        matrix[i].Add('*');
                    }
                    else
                    {
                        matrix[i].Add(' ');
                    }

                }
                
            }
            return matrix;

        }

        static List<List<char>> evaluate(List<List<char>> world)
        {
            // create a new world based of the old world here by implementing the rules here.
            List<List<char>> newWorld =new  List<List<char>>();
            for (int i = 0; i <= rowSize; i++)
            {
                newWorld.Add(new List<char>(columnSize));
                for(int j = 0; j <= columnSize; j++)
                {
                    newWorld[i].Add(' ');
                }
            }
            
            
            for (int i = 1; i < rowSize; i++)
            {
                
                for (int j = 1; j < columnSize; j++)
                {
                    int numAlive = 0;

                    if (world[i - 1][j - 1] == '*') numAlive++;
                    if (world[i - 1][j] == '*') numAlive++;
                    if (world[i - 1][j + 1] == '*') numAlive++;
                    if (world[i][j - 1] == '*') numAlive++;
                    if (world[i][j + 1] == '*') numAlive++;
                    if (world[i + 1][j - 1] == '*') numAlive++;
                    if (world[i + 1][j] == '*') numAlive++;
                    if (world[i + 1][j + 1] == '*') numAlive++;

                    if (numAlive == 3 && newWorld[i][j] == ' ') 
                    {
                        //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                        newWorld[i][j] = '*';   
                    }
                    else if (numAlive == 2 || numAlive == 3)
                    {
                        //Any live cell with two or three live neighbours lives on to the next generation.
                        newWorld[i][j] = world[i][j];
                    }
                    else if (numAlive < 2)
                    {
                        //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                        newWorld[i][j] = ' ';
                    }
                    else if (numAlive > 3)
                    {
                        //Any live cell with more than three live neighbours dies, as if by overpopulation.
                        newWorld[i][j] = ' ';
                    }
                }
            }
            return newWorld;
        }

        

        static void display(List<List<char>> world)
        {
            for (int i = 0; i <= rowSize; i++)
            {
                for (int j = 0; j <= columnSize; j++)
                {
                    Console.Write(world[i][j]);
                }
                Console.Write("\n");
            }
            //wait .3 second to see pattern
            Thread.Sleep(300);
            Console.Clear();
        }

    }
}
