using System.Collections;
using System.Collections.Generic;
using Clingo;
using UnityEngine;

public class ChessLevelHandler : ASPLevelHandler
{
    [SerializeField] ChessGenerator generator;

    [SerializeField] MapTileRule mapTileRule;
    [SerializeField] MapKeyTileRule mapKeyTileRule;
    [SerializeField] MapBoard mapPixel;
    [SerializeField] MapKeyPixel mapKeyPixel;
    [SerializeField] MapBoardPiece mapBoardPiece;
    [SerializeField] MapKeyBoardPiece mapKeyBoardPiece;
    [SerializeField] int kingCount = 1, queenCount = 1, pawnCount = 4, bishopCount = 2, knightCount = 2, rookCount = 2;
    private void Start()
    {
        initializeGenerator(generator);
        generator.InitializeGenerator(kingCount, queenCount, pawnCount, bishopCount, knightCount, rookCount);
        generator.StartGenerator();
    }

    protected override void ERROR(string error, string jobID)
    {
        throw new System.NotImplementedException();
    }

    protected override void SATISFIABLE(AnswerSet answerSet, string jobID)
    {
        mapTileRule.DisplayMap(answerSet, mapKeyTileRule);
        mapTileRule.AdjustCamera();
        mapPixel.DisplayMap(answerSet, mapKeyPixel);
        mapBoardPiece.DisplayMap(answerSet, mapKeyBoardPiece);
    }

    protected override void TIMEDOUT(int time, string jobID)
    {
        throw new System.NotImplementedException();
    }

    protected override void UNSATISFIABLE(string jobID)
    {
        throw new System.NotImplementedException();
    }

   
}
