using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuLevelHandler : ASPLevelHandler
{
    [SerializeField] ASPGenerator generator;

    [SerializeField] MapTileRule mapTileRule;
    [SerializeField] MapKeyTileRule mapKeyTileRule;
    [SerializeField] MapPixel mapPixel;
    [SerializeField] MapKeyPixel mapKeyPixel;

    private void Start()
    {
        initializeGenerator(generator);
        generator.StartGenerator();
    }

    protected override void ERROR(string error, string jobID)
    {
        throw new System.NotImplementedException();
    }

    protected override void SATISFIABLE(Clingo.AnswerSet answerSet, string jobID)
    {
        mapTileRule.DisplayMap(answerSet, mapKeyTileRule);
        mapTileRule.AdjustCamera();
        mapPixel.DisplayMap(answerSet, mapKeyPixel);
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
