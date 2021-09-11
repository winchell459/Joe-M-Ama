using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject BoardSquarePrefab;
    public int boardWidth = 12, boardHeight = 12;
    public float boardSquareSpacing = 1;

    // Start is called before the first frame update
    void Start()
    {
        buildBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void buildBoard()
    {
        for(int j = 0; j < boardHeight; j += 1)
        {
            for(int i = 0; i < boardWidth; i += 1)
            {
                //placeBoardSquare((i - boardWidth/2) * boardSquareSpacing, (j - boardHeight/2) * boardSquareSpacing);
                placeBoardSquare(i,j);
            }
        }
    }
    private void placeBoardSquare(int x, int y)
    {
        BoardSquare newSquare = Instantiate(BoardSquarePrefab, transform).GetComponent<BoardSquare>();
        newSquare.gameObject.name += " " + x + "," + y;
        newSquare.PlaceBoardSquare((x - boardWidth/2)*boardSquareSpacing, (y - boardHeight/2)*boardSquareSpacing);
    }

    private void placeBoardSquare(float x, float y)
    {
        BoardSquare newSquare = Instantiate(BoardSquarePrefab, transform).GetComponent<BoardSquare>();
        newSquare.gameObject.name +=  " " + x + "," + y;
        newSquare.PlaceBoardSquare(x,y);
    }

    public void squareClicked(BoardSquare square)
    {
        Debug.Log(square.name);
    }
}
