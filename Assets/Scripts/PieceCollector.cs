using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCollector : MonoBehaviour
{

    [SerializeField]
    private PieceType missingPiece;

    public PieceType[] pieceTypes;
    public Dictionary<string, string> pieceDictionary = new Dictionary<string, string>()
    {
        {"p", "Pawn"},
        {"r", "Rook"},
        {"b", "Bishop"},
        {"k", "King"},
        {"n", "Knight"},
        {"q", "Queen"},
    };

    public PieceType FetchPieceType(string key)
    {
        string pieceName = pieceDictionary[key];
        foreach (PieceType piece in pieceTypes)
        {
            if (piece.name == pieceName)
            {
                return piece;
            }
        }
        return missingPiece;
    }
}
