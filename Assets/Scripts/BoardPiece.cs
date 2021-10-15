using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardPiece : MonoBehaviour
{
    public enum PieceColors
    {
        white,
        black
    }
    public PieceColors pieceColor;

    public BoardSquare mySquare;
    public abstract bool ValidMove(Vector2Int moveSquare);
}
