﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardSquare : MonoBehaviour
{

    public abstract void PlaceBoardSquare(float x, float y);

    public BoardPiece myPiece = null;

    private void OnMouseDown()
    {
        FindObjectOfType<Board>().squareClicked(this);
    }

    public void PlacePiece(BoardPiece piece)
    {
        piece.transform.position = transform.position;
    }
}
