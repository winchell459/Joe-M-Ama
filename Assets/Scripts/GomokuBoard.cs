using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuBoard : Board
{
    public override void squareClicked(BoardSquare square)
    {
        Debug.Log(GetSquareIndex(square));
    }

    protected override void setupBoardPieces()
    {

    }
 }
