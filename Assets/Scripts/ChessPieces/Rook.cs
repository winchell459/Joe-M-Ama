using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    private bool firstMove = true;
    public bool FirstMove { get { return firstMove; } }

    
    public override bool ValidMove(Vector2Int moveSquare)
    {
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;
        bool valid = true;
        //check if moveSquare is on the horizontal line or vertical line

        //check if moveSquare is occupied or has the opposite piece color

        //check that the path is clear

        if (moveSquare.x == FindObjectOfType<ChessBoard>().GetSquareIndex(mySquare).x)
        {
            //horizontal (file)


        }else if(moveSquare.y == FindObjectOfType<ChessBoard>().GetSquareIndex(mySquare).y)
        {
            //vertical (rank)

        }
        else
        {
            valid = false;
        }
     
        if (valid) firstMove = false;
        return valid;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
