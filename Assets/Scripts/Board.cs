using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Board : MonoBehaviour
{
    public GameObject BoardSquarePrefab;
    public int boardWidth = 12, boardHeight = 12;
    public float boardSquareSpacing = 1;

    public BoardSquare[,] boardSquares;

    public BoardPiece SelectedPiece;
    public bool GameOver;
    public BoardPiece.PieceColors winningColor;
    // Start is called before the first frame update
    void Start()
    {
        buildBoard();
        setupBoardPieces();
    }

    protected abstract void setupBoardPieces();

    private void buildBoard()
    {
        boardSquares = new BoardSquare[boardWidth, boardHeight];
        for(int j = 0; j < boardHeight; j += 1)
        {
            for(int i = 0; i < boardWidth; i += 1)
            {
                //placeBoardSquare((i - boardWidth/2) * boardSquareSpacing, (j - boardHeight/2) * boardSquareSpacing);
                BoardSquare newSquare = placeBoardSquare(i,j);
                boardSquares[i, j] = newSquare;
            }
        }
    }
    private BoardSquare placeBoardSquare(int x, int y)
    {
        BoardSquare newSquare = Instantiate(BoardSquarePrefab, transform).GetComponent<BoardSquare>();
        newSquare.gameObject.name += " " + x + "," + y;
        newSquare.PlaceBoardSquare((x - boardWidth/2)*boardSquareSpacing, (y - boardHeight/2)*boardSquareSpacing);
        return newSquare;
    }

    private BoardSquare placeBoardSquare(float x, float y)
    {
        BoardSquare newSquare = Instantiate(BoardSquarePrefab, transform).GetComponent<BoardSquare>();
        newSquare.gameObject.name +=  " " + x + "," + y;
        newSquare.PlaceBoardSquare(x,y);
        return newSquare;
    }

    public Vector2Int GetSquareIndex(BoardSquare square)
    {
        Vector2Int index = new Vector2Int(-1,-1);
        for (int j = 0; j < boardHeight; j += 1)
        {
            for (int i = 0; i < boardWidth; i += 1)
            {
                if (boardSquares[i, j] == square) index = new Vector2Int(i, j);
            }
        }
        return index;
    }

    public BoardSquare GetSquare(Vector2Int index)
    {
        return boardSquares[index.x, index.y];
    }

    public abstract void squareClicked(BoardSquare square);
}
