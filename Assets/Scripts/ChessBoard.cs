using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : Board
{
    public Pawn pawnPrefab, pawnWhitePrefab;
    public Queen queenBlackPrefab, queenWhitePrefab;
    public Rook rookBlackPrefab, rookWhitePrefab;
    public Knight knightBlackPrefab, knightWhitePrefab;
    public King kingBlackPrefab, kingWhitePrefab;
    public Bishop bishopBlackPrefab, bishopWhitePrefab;

    //public Knight knightPrefab;
    
    public override void squareClicked(BoardSquare square)
    {
        //if no SelectedPiece and selected square has a piece
        if (!SelectedPiece && square.myPiece) SelectedPiece = square.myPiece;
        //if there is a SelectedPiece
        else if(SelectedPiece && SelectedPiece.ValidMove(GetSquareIndex(square))){
            square.PlacePiece(SelectedPiece);
            SelectedPiece = null;
        }
    }

    protected override void setupBoardPieces()
    {
        GameObject pawn = Instantiate(pawnPrefab.gameObject);
        BoardSquare square = GetSquare(new Vector2Int(0, 1));
        square.PlacePiece(pawn.GetComponent<BoardPiece>());
    }
}
