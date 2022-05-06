using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Board")]
    public Board board;

    void Start()
    {
        // run the Setup function of the board: create the board
        board.Setup();
    }
}
