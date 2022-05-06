using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    public Board board;
    [SerializeField] InputSystem input;

    public Piece rook1;
    public Piece rook2;


    public void ComputeAction(Piece activePiece, Tile targetTile)
    {
        // first, check if the target tile is in the set of legal moves


        // if (!activePiece.legalTiles.Contains(targetTile))                     TEMPORARY!!!!

        if (!true)
        {
            activePiece.CancelMovement();
            return;
        }
        else
        {
            // check if the target tile contains a piece
            Piece targetPiece = targetTile.currentPiece;
            if (targetPiece == null)
            {
                activePiece.MoveTo(targetTile);
                return;
            }
            else
            {
                EvaluateOccupiedTile(activePiece, targetPiece);
                return;
            }
        }
        
    }



    private void EvaluateOccupiedTile(Piece activePiece, Piece targetPiece)
    {
        bool sameTeam = targetPiece.color == activePiece.color;
        if (!sameTeam)
        {
            activePiece.Capture(targetPiece);
        }
        else
        {
            activePiece.CancelMovement();
        }
    }


    private void Start()
    {
        // TEST LINES: PLACE ROOKS FOR TESTING
        rook1.Initialize("w", board.tiles[0, 0]);
        rook2.Initialize("b", board.tiles[4, 4]);
    }
}
