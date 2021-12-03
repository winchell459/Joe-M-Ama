using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{

    public override bool ValidMove(Vector2Int moveSquare)
    {
        bool valid = true;
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;
        if (boardSquares[moveSquare.x, moveSquare.y].myPiece == null)
        {
            valid = ClearPath(boardSquares, moveSquare);
        }
        else if (boardSquares[moveSquare.x, moveSquare.y].myPiece != null && boardSquares[moveSquare.x, moveSquare.y].myPiece.pieceColor != pieceColor)
        {
            valid = ClearPath(boardSquares, moveSquare);
            if (valid) FindObjectOfType<ChessBoard>().RemovePiece(moveSquare);
            
        }
        else
        {
            valid = false;
        }


        return valid;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
