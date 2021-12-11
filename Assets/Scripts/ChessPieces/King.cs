using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    protected override bool checkValidMove(Vector2Int moveSquare)
    {
        bool valid = false;
        if (mySquareIndex.x == moveSquare.x && mySquareIndex.y == moveSquare.y + 1 || mySquareIndex.x == moveSquare.x && mySquareIndex.y == moveSquare.y - 1 || mySquareIndex.x == moveSquare.x + 1 && mySquareIndex.y == moveSquare.y || mySquareIndex.x == moveSquare.x - 1 && mySquareIndex.y == moveSquare.y)
        {
            valid = true;
        }else if(mySquareIndex.x == moveSquare.x + 1 && mySquareIndex.y == moveSquare.y + 1 || mySquareIndex.x == moveSquare.x + 1 && mySquareIndex.y == moveSquare.y - 1 || mySquareIndex.x == moveSquare.x - 1 && mySquareIndex.y == moveSquare.y + 1 || mySquareIndex.x == moveSquare.x - 1 && mySquareIndex.y == moveSquare.y - 1)
        {
            valid = true;
        }

        return valid;
    }

    protected override bool checkValidAttack(Vector2Int moveSquare)
    {
        return checkValidMove(moveSquare);
    }

   
}
