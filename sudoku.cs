using System;
using System.IO;
using System.Collections.Generic;

class Sudoku
{
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //

    private static int[,][] blockforfield = new int[10,10][];
    private static int globalcnt = 0;
    private static List<int>[,] furtherinfluencingblocks = new List<int>[10,10];

    public static void Main()
    {       
        var fields = new Field[10, 10];

        for (int i=1; i<=9; i++)
            for (int j=1; j<=9; j++)
                fields[i, j] = new Field();

    
        int twotimesnothing = 0;

        new InputData.Sudoku().ReadOut(fields, ref globalcnt);
        new Strategies.Preparation().Run(blockforfield, fields, potentialblock, fieldsperblock, furtherinfluencingblocks);
        //Sudoku.PrintFurtherInfluencingBlocks();
        //Sudoku.PrintBlockForField();
        new OutputData.Sudoku().Print(fields);
        Console.WriteLine();

        while(globalcnt <81 && twotimesnothing < 2)
        {
            // foreach (int test in potential[7,5] as List<int>)
            //     Console.Write(test + " ");
            // Console.WriteLine();
            if (!Sudoku.ReducePot(fields)) 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }   
            else
            {
                twotimesnothing = 0;
            }
        
            //Sudoku.PrintSudokuField();
            //Console.WriteLine();
            //Console.ReadLine();        
        }
        //Sudoku.PrintPotential();
        //Sudoku.PrintPotentialBlock();
        new OutputData.Sudoku().Print(fields);

        //while(!Sudoku.PrintPotentialFlexible());

        Console.ReadLine(); 
    }

    public static bool ReducePot(Field[,] fields)
    {
        List<int[]> IntListArr = new List<int[]>();     

        new Strategies.Strategy1().Run(blockforfield, fields, potentialblock);
        new Strategies.Strategy2().Run(fields, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(blockforfield, fields, fieldsperblock, IntListArr);
        if (new Strategies.Strategy4().Run(fields, ref globalcnt))
            return true;

        if (new Strategies.Strategy5().Run(fields, potentialblock, furtherinfluencingblocks, ref globalcnt))
            return true;

        if (new Strategies.Strategy6().Run(blockforfield, fields, fieldsperblock, ref globalcnt))
            return true;
        
        if (new Strategies.Strategy7().Run(fields, fieldsperblock, ref globalcnt))
            return true;

        return false;
    }
}