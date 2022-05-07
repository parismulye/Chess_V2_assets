using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    public Board board;
    [SerializeField] InputSystem input;

    public GameObject piece_p;



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


    public void CreatePieces(string[,] pieces, Board board)                      // COULD BE USEFUL TO STORE ALL CREATED PIECES IN A LIST?
    {
        for (int j = 0; j < board.height; j++)
        {
            for (int i = 0; i < board.width; i++)
            {
                var key = pieces[i, j];
                if (key != null)
                {
                    // create a GameObject for the piece
                    GameObject newPieceObject = Instantiate(piece_p);
                    newPieceObject.transform.SetParent(transform);

                    // set initial scale and rotation
                    newPieceObject.transform.localRotation = Quaternion.identity;
                    newPieceObject.transform.localScale = new Vector3(1, 1, 1);

                    // give name to prefab
                    newPieceObject.name = key;
                    Piece piece = newPieceObject.GetComponent<Piece>();

                    // HERE assign now the right SO file
                    piece.Initialize("w", board.tiles[i, j]);
                }
            }
        }
    }
}
