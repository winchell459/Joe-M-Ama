using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : BoardPiece
{
    protected bool ClearPath(BoardSquare[,] boardSquares, Vector2Int destination)
    {
        bool valid = false;
        Vector2Int start = FindObjectOfType<Board>().GetSquareIndex(mySquare);
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
