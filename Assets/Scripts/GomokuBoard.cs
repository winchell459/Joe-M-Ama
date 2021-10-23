using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuBoard : Board
{
    public bool gameOver = false;
    public Rock rockWhitePrefab, rockBlackPrefab;
    public override void squareClicked(BoardSquare square)
    {
        if(!gameOver && SelectedPiece.ValidMove(GetSquareIndex(square)))
        {
            square.PlacePiece(SelectedPiece);
            SelectedPiece.gameObject.SetActive(true);

            gameOver = check(square);
            if(SelectedPiece.pieceColor == BoardPiece.PieceColors.black)
            {
                SelectedPiece = Instantiate(rockWhitePrefab);

            }
            else
            {
                SelectedPiece = Instantiate(rockBlackPrefab);
            }
            SelectedPiece.gameObject.SetActive(false);

            
        }

        
    }

    bool check(BoardSquare square)
    {
        int isOverCount = 3;
        int hCount = 1;
        hCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), 1, 0);
        hCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), -1, 0);
        int vCount = 1;
        vCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), 0, 1);
        vCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), 0, -1);

        int upRightCount = 1;
        upRightCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), 1, 1);
        upRightCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), -1, -1);

        int downRightCount = 1;
        downRightCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), 1, -1);
        downRightCount += count(boardSquares, square.myPiece.pieceColor, GetSquareIndex(square), -1, 1);

        Debug.Log($"{square.myPiece.pieceColor} horizontal count: {hCount} vertical count: {vCount} upRight count: {upRightCount} downRight count: {downRightCount} ");

        

        return hCount >= isOverCount || vCount >= isOverCount || upRightCount >= isOverCount || downRightCount >= isOverCount;
    }

    int count(BoardSquare[,] boardSquares, BoardPiece.PieceColors pieceColor, Vector2Int start, int xStep, int yStep)
    {
        int count = 0;
        start = start + new Vector2Int(xStep, yStep);
        int width = boardWidth;
        int height = boardHeight;
        width = boardSquares.GetUpperBound(0);
        height = boardSquares.GetUpperBound(1);
        while (start.x >= 0 && start.x < width && start.y >= 0 && start.y < height && boardSquares[start.x, start.y].myPiece && boardSquares[start.x, start.y].myPiece.pieceColor == pieceColor)
        {
            count += 1;
            start = start + new Vector2Int(xStep, yStep);
        }

        return count;
    }

    protected override void setupBoardPieces()
    {
        SelectedPiece = Instantiate(rockBlackPrefab);
        SelectedPiece.gameObject.SetActive(false);
    }
 }
