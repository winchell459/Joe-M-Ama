using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASPGomokuBoard : GomokuBoard
{
    protected override void setupBoardPieces()
    {
        transform.position = new Vector2(boardWidth / 2, boardHeight / 2);
        for (int i = 0; i < boardWidth; i+= 1)
        {
            for(int j = 0; j < boardHeight; j += 1)
            {
                boardSquares[i, j].gameObject.SetActive(false);
            }
        }
        base.setupBoardPieces();
    }
}
