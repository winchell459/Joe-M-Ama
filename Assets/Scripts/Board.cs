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
                placeBoardSquare(i * boardSquareSpacing, j * boardSquareSpacing);
            }
        }
    }

    private void placeBoardSquare(float x, float y)
    {
        BoardSquare newSquare = Instantiate(BoardSquarePrefab, transform).GetComponent<BoardSquare>();
        newSquare.PlaceBoardSquare(x, y);
    }
}
