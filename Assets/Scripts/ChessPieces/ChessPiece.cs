using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : BoardPiece
{
    public bool firstMove = true;
    protected Vector2Int mySquareIndex { get { return FindObjectOfType<Board>().GetSquareIndex(mySquare); } }
    protected abstract bool checkValidMove(Vector2Int moveSquare);
    protected abstract bool checkValidAttack(Vector2Int moveSquare);
    public override bool ValidMove(Vector2Int moveSquare)
    {
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;
        if (boardSquares[moveSquare.x, moveSquare.y].myPiece == null && checkValidMove(moveSquare))
        {
            FindObjectOfType<Board>().GetSquare(moveSquare).PlacePiece(this);
            firstMove = false;
            return true;
        }
        else if (boardSquares[moveSquare.x, moveSquare.y].myPiece != null && boardSquares[moveSquare.x, moveSquare.y].myPiece.pieceColor != pieceColor && checkValidAttack(moveSquare))
        {
            FindObjectOfType<ChessBoard>().RemovePiece(moveSquare);
            FindObjectOfType<Board>().GetSquare(moveSquare).PlacePiece(this);
            
            firstMove = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool ClearPath(BoardSquare[,] boardSquares, Vector2Int destination)
    {
        bool valid = false;
        Vector2Int start = mySquareIndex;//FindObjectOfType<Board>().GetSquareIndex(mySquare);
        if (start.y == destination.y)
        {
            if (start.x > destination.x)
            {
                valid = ClearPath(boardSquares, start, destination, -1, 0);
            }
            else
            {
                valid = ClearPath(boardSquares, start, destination, 1, 0);
            }
        }
        else if (start.x == destination.x)
        {
            if (start.y > destination.y)
            {
                valid = ClearPath(boardSquares, start, destination, 0, -1);
            }
            else
            {
                valid = ClearPath(boardSquares, start, destination, 0, 1);
            }
        }
        else if (Mathf.Abs(start.x - destination.x) == Mathf.Abs(start.y - destination.y))
        {
            if (start.y < destination.y && start.x < destination.x)
            {
                valid = ClearPath(boardSquares, start, destination, 1, 1);
            }
            else if (start.y > destination.y && start.x < destination.x)
            {
                valid = ClearPath(boardSquares, start, destination, 1, -1);
            }
            else if (start.y < destination.y && start.x > destination.x)
            {
                valid = ClearPath(boardSquares, start, destination, -1, 1);
            }
            else if (start.y > destination.y && start.x > destination.x)
            {
                valid = ClearPath(boardSquares, start, destination, -1, -1);
            }
        }

        return valid;
    }

    bool ClearPath(BoardSquare[,] boardSquares, Vector2Int start, Vector2Int destination, int xStep, int yStep)
    {
        bool clear = true;
        start.x += xStep;
        start.y += yStep;
        while (start != destination)
        {
            Debug.Log(start);
            if (boardSquares[start.x, start.y].myPiece != null) clear = false;
            start.x += xStep;
            start.y += yStep;
        }
        //do
        //{
        //    start.x += xStep;
        //    start.y += yStep;
        //    if (boardSquares[start.x, start.y].myPiece != null) clear = false;
        //} while (start != destination);
        return clear;
    }
}
