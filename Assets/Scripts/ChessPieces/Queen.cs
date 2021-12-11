using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{

    protected override bool checkValidMove(Vector2Int moveSquare)
    {

        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;

        return ClearPath(boardSquares, moveSquare);
    }

    protected override bool checkValidAttack(Vector2Int moveSquare)
    {
        return ClearPath(FindObjectOfType<Board>().boardSquares, moveSquare);
    }

   
}
