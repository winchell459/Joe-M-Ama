using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ASPChessPiece : ASPPiece
{
    public Vector2Int Start;
    public string Target = "king";
    public BoardPiece.PieceColors PieceColor;

    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";

        
        aspCode += generateTargetASPCode();

        foreach (ASPPiece.Move move in Moves)
        {
            aspCode += $"{Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+{move.dx}, YY+{move.dy}), tile(XX,YY,{landingTile}).";
        }

        return aspCode;
    }
    protected virtual string generateTargetASPCode()
    {
        string aspCode = "";

        aspCode += $@" 

            {Name}_overlap(XX,YY) :- {Name}_path(XX,YY), {Target}_path(XX,YY).
            :- not {Name}_overlap(_,_).
        ";
        return aspCode;
    }

    protected virtual string generateDiagonalASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";

        aspCode += $@" 

            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+II, YY+II), tile(XX,YY,{landingTile}), width(II).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+II, YY-II), tile(XX,YY,{landingTile}), width(II).

        ";
        return aspCode;
    }

    protected virtual string generateRookMoveASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";

        aspCode += $@" 

            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+II, YY), tile(XX,YY,{landingTile}), width(II).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-II, YY), tile(XX,YY,{landingTile}), width(II).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX, YY+II), tile(XX,YY,{landingTile}), height(II).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX, YY-II), tile(XX,YY,{landingTile}), height(II).

        ";
        return aspCode;
    }
}
