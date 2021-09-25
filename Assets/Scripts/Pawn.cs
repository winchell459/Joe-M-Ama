using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : BoardPiece
{
    private bool firstMove = true;
    public override bool ValidMove(Vector2Int moveSquare)
    {
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;

        //if(mySquare.x != moveSquare.x)
        //{

        //}
        //if (firstMove)
        //{

        //    firstMove = false;
        //}

        //if (boardSquares[moveSquare.x, moveSquare.y] == null) ;


        bool valid = true;
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
