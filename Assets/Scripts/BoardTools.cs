using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class BoardTools
{

    public static string CoordToName(Vector2Int coord)
    {
        string name = "C" + coord.x + "R" + coord.y;
        return name;
    }

    public static Vector2Int NameToCoord(string name)
    {
        string[] nameSplit = name.Split('R');
        string x_str = nameSplit[0].Substring(1);
        string y_str = nameSplit[1];
        int x = int.Parse(x_str);
        int y = int.Parse(y_str);
        return new Vector2Int(x, y);
    }

    public static string[,] ReadFEN(string FEN, Board board)
    {
        string teamColor = "_w";
        string[,] pieces = new string[board.width, board.height];
        string[] FENsplit = FEN.Split('/');
        int Nlines = FENsplit.Length;
        if (Nlines != board.height)
        {
            Debug.Log("FEN Reader ERROR: check FEN format");
        }
            // parse through lines:
            for (int j = 0; j < Nlines; j++)
        {
            int i = 0;
            foreach (char c in FENsplit[j])
            {
                if (c + "" == "-")
                {
                    teamColor = "_b";
                    continue;
                }
                try
                {
                    int add = int.Parse(c + "");
                    i += add;
                }
                catch (FormatException)
                {
                    string pieceName = c + teamColor;
                    try
                    {
                        pieces[i, j] = pieceName;
                        i += 1;
                        
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Debug.Log("FEN Reader ERROR: check FEN format");
                    }                    
                }
            }
            
        }
        return pieces;
    }
}
