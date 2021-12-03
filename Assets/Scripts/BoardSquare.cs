using System.Collections;
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
        myPiece = piece;
        if (piece.mySquare) piece.mySquare.myPiece = null; //removes piece from previous square
        piece.mySquare = this;

    }

    public void RemovePiece()
    {
        Debug.Log($"Destroy {myPiece.name}");
        Destroy(myPiece.gameObject);
        myPiece = null;
    }
}
