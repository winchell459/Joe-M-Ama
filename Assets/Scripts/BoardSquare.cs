using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardSquare : MonoBehaviour
{
    public abstract void PlaceBoardSquare(float x, float y);

    private void OnMouseDown()
    {
        FindObjectOfType<Board>().squareClicked(this);
    }
}
