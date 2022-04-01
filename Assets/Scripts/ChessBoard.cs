using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : Board
{
    public Pawn pawnBlackPrefab, pawnWhitePrefab;
    public Queen queenBlackPrefab, queenWhitePrefab;
    public Rook rookBlackPrefab, rookWhitePrefab;
    public Knight knightBlackPrefab, knightWhitePrefab;
    public King kingBlackPrefab, kingWhitePrefab;
    public Bishop bishopBlackPrefab, bishopWhitePrefab;

    //public Knight knightPrefab;

    public BoardPiece.PieceColors colorTurn = BoardPiece.PieceColors.white;

    public override void squareClicked(BoardSquare square)
    {


        if (GameOver) return;
        //if no SelectedPiece and selected square has a piece
        if (!SelectedPiece && square.myPiece && square.myPiece.pieceColor == colorTurn) SelectedPiece = square.myPiece;
        //if there is a SelectedPiece
        else if (SelectedPiece && SelectedPiece.ValidMove(GetSquareIndex(square)))
        {
            //square.PlacePiece(SelectedPiece);
            SelectedPiece = null;
           
            colorTurn = (BoardPiece.PieceColors)((int)(colorTurn + 1) % 2);
        }
        else if (SelectedPiece && !SelectedPiece.ValidMove(GetSquareIndex(square)))
        {

            SelectedPiece = null;
            
        }
        checkGameEnding();
    }
    
    
    private void checkGameEnding()
    {
        King[] kings = FindObjectsOfType<King>();
        if(kings.Length < 2)
        {
            GameOver = true;
            winningColor = kings[0].pieceColor;
            Debug.Log($"Game over! {winningColor} wins.");
        }
    }

    protected override void setupBoardPieces()
    {
        for (int i = 0; i < boardWidth; i += 1)
        {
            addBoardPiece(pawnBlackPrefab, i, 1);
            addBoardPiece(pawnWhitePrefab, i, 6);
        }
        addBoardPiece(rookBlackPrefab, 0, 0);
        addBoardPiece(rookBlackPrefab, 7, 0);
        addBoardPiece(rookWhitePrefab, 0, 7);
        addBoardPiece(rookWhitePrefab, 7, 7);

        addBoardPiece(knightBlackPrefab, 1, 0);
        addBoardPiece(knightBlackPrefab, 6, 0);
        addBoardPiece(knightWhitePrefab, 1, 7);
        addBoardPiece(knightWhitePrefab, 6, 7);

        addBoardPiece(bishopBlackPrefab, 2, 0);
        addBoardPiece(bishopBlackPrefab, 5, 0);
        addBoardPiece(bishopWhitePrefab, 2, 7);
        addBoardPiece(bishopWhitePrefab, 5, 7);

        addBoardPiece(kingBlackPrefab, 3, 0);
        addBoardPiece(queenBlackPrefab, 4, 0);
        addBoardPiece(queenWhitePrefab, 3, 7);
        addBoardPiece(kingWhitePrefab, 4, 7);
    }

    private void addBoardPiece(ChessPiece prefab, int x, int y)
    {
        GameObject piece = Instantiate(prefab.gameObject);
        BoardSquare square = GetSquare(new Vector2Int(x, y));
        square.PlacePiece(piece.GetComponent<BoardPiece>());
    }

    public override void AddBoardPiece(BoardPiece prefab, int x, int y)
    {
        addBoardPiece((ChessPiece)prefab, x, y);
    }

    public void RemovePiece(Vector2Int boardPosition)
    {
        boardSquares[boardPosition.x, boardPosition.y].RemovePiece();
    }
}
