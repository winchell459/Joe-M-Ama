﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    
    public override bool ValidMove(Vector2Int moveSquare)
    {
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;

        


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
