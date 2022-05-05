using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is the base class from which all pieces inherit.
 * We provide here useful basic attributes and functions common to all pieces:
 * 
 * ATTRIBUTES:
 * color[string] : 'w' or 'b'
 * legalMoves[List<Tile>] : list of all tiles the piece move go to at any given moment, whether empty or capturable
 * currentTile[Tile] : where it is on the board at any given moment
 * previuosTile[Tile] : where it was at the turn before. Init to null. Maybe not needed?
 * 
 * METHODS:
 * Setup(teamColor, Tile): assign color, place on Tile
 * 
 * MoveTo(Tile) : the idea is to just give one Tile object as argument, and the method will do a series of things autonomously:
 *              - update the previuosTile in the Piece: previousTile = currentTile;
 *              - update the currentTile in the Piece: currentTile = Tile
 *              - update the currentPiece in the Tile
 *              By doing, this the move action is completed only by calling piece.Move(someTile) and all attributes are updated at once.
 */

public abstract class Piece : MonoBehaviour
{
    // ATTRIBUTES:
    public string color = "";
    public List<Tile> legalMoves = new();
    public Tile currentTile;
    public Tile previousTile;


    // METHODS:
    public void Setup(string teamColor, Tile initialTile)
    {
        color = teamColor;
        MoveTo(initialTile);
    }

    public void MoveTo(Tile newTile)
    {
        // update this object attributes:
        previousTile = currentTile;
        currentTile = newTile;

        // update attributes of the argument Tile object:
        newTile.currentPiece = this;
    }

    public void Activate()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        // compute legal moves...
    }

    public void Deactivate()
    {
        transform.localScale = Vector3.one;

    }
}
