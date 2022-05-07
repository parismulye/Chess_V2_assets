using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Piece", menuName = "New Piece")]
public class PieceType : ScriptableObject
{
    public string key;
    public Sprite sprite_w;
    public Sprite sprite_b;
}
