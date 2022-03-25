using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPPawn", menuName = "ASP/Piece/Pawn")]
public class ASPPawn : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = $@"

        ";

        if(PieceColor == BoardPiece.PieceColors.black)
        {
            aspCode += $@"
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-1, YY), tile(XX,YY,{landingTile}).
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-1, YY+1), tile(XX,YY,{landingTile}).
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-1, YY-1), tile(XX,YY,{landingTile}).
            ";
        }
        else
        {
            aspCode += $@"
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+1, YY), tile(XX,YY,{landingTile}).
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+1, YY+1), tile(XX,YY,{landingTile}).
                {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+1, YY-1), tile(XX,YY,{landingTile}).
            ";
        }
        return aspCode;
    }
}
