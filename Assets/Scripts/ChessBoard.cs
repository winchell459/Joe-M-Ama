using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : Board
{
    public Pawn pawnPrefab;
    //public Knight knightPrefab;
    
    public override void squareClicked(BoardSquare square)
    {
        Debug.Log(GetSquareIndex(square));
    }

    protected override void setupBoardPieces()
    {
        GameObject pawn = Instantiate(pawnPrefab.gameObject);
        BoardSquare square = GetSquare(new Vector2Int(5, 2));
        square.PlacePiece(pawn.GetComponent<BoardPiece>());
    }
}
