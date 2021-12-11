using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{

    protected override bool checkValidMove(Vector2Int moveSquare)
    {
        if (mySquareIndex.x != moveSquare.x && mySquareIndex.y != moveSquare.y && ClearPath(FindObjectOfType<Board>().boardSquares, moveSquare))
        {
            return true;
        }
        else
            return false;
    }

    protected override bool checkValidAttack(Vector2Int moveSquare)
    {
        return checkValidMove(moveSquare);
    }
    
}
