using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoardTools
{



    public static string CoordToName(Vector2Int coord)
    {
        string name = "C" + coord.x + "R" + coord.y;
        return name;
    }



}
