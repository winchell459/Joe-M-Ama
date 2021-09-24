using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardPiece : MonoBehaviour
{
    public BoardSquare mySquare;
    public abstract bool ValidMove(Vector2 moveSquare);
}
