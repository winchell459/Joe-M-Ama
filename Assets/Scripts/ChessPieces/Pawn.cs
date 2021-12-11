using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    

    protected override bool checkValidMove(Vector2Int moveSquare)
    {
        if(moveSquare.x == mySquareIndex.x && moveSquare.y == mySquareIndex.y + 1 && pieceColor == PieceColors.black)
        {
            return true;
        }else if (moveSquare.x == mySquareIndex.x && moveSquare.y == mySquareIndex.y - 1 && pieceColor == PieceColors.white)
        {
            return true;
        }else if (firstMove && ClearPath(FindObjectOfType<Board>().boardSquares, moveSquare) && moveSquare.x == mySquareIndex.x && moveSquare.y == mySquareIndex.y + 2 && pieceColor == PieceColors.black)
        {
            return true;
        }
        else if (firstMove && ClearPath(FindObjectOfType<Board>().boardSquares, moveSquare) && moveSquare.x == mySquareIndex.x && moveSquare.y == mySquareIndex.y - 2 && pieceColor == PieceColors.white)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected override bool checkValidAttack(Vector2Int moveSquare)
    {
        if ((moveSquare.x == mySquareIndex.x + 1 || moveSquare.x == mySquareIndex.x - 1) && moveSquare.y == mySquareIndex.y + 1 && pieceColor == PieceColors.black)
        {
            return true;
        }
        else if ((moveSquare.x == mySquareIndex.x + 1 || moveSquare.x == mySquareIndex.x - 1) && moveSquare.y == mySquareIndex.y - 1 && pieceColor == PieceColors.white)
        {
            return true;
        }
        
        else
        {
            return false;
        }
    }

   
}
