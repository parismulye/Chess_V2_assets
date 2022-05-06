using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Board")]
    public Board board;

    [TextArea]
    [Tooltip("Provide initial position in FEN format")]
    public string FEN;

    void Start()
    {
        // run the Setup function of the board: create the board
        board.Setup();

        // generate a 2D array of strings of the current initial position
        string[,] pieces = BoardTools.ReadFEN(FEN, board);
    }
}
