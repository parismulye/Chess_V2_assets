using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    public Board board;
    [SerializeField] InputSystem input;

    public Piece rook;

    private void Start()
    {
        // TEST LINE: PLACE ONE ROOK FOR TESTING
        rook.MoveTo(board.tiles[0, 0]);
    }
}
