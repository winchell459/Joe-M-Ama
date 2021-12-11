using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{

    protected override bool checkValidMove(Vector2Int moveSquare)
    {
        if ((moveSquare.x == mySquareIndex.x + 1 || moveSquare.x == mySquareIndex.x - 1) && (moveSquare.y == mySquareIndex.y + 2 || moveSquare.y == mySquareIndex.y - 2))
        {
            return true;
        }
        else if ((moveSquare.x == mySquareIndex.x + 2 || moveSquare.x == mySquareIndex.x - 2) && (moveSquare.y == mySquareIndex.y + 1 || moveSquare.y == mySquareIndex.y - 1))
        {
            return true;
        }
        else return false;
    }

    protected override bool checkValidAttack(Vector2Int moveSquare)
    {
        return checkValidMove(moveSquare);
    }

}
