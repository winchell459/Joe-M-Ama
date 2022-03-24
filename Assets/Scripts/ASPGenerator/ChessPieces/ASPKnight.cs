using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPPiece/Knight", menuName = "ASP/Piece/Knight")]
public class ASPKnight : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = $@"

            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+1, YY+2), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+2, YY+1), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-1, YY+2), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-2, YY+1), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+1, YY-2), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX+2, YY-1), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-1, YY-2), tile(XX,YY,{landingTile}).
            {Name}_{predicate}(XX,YY) :- {Name}_{predicate}(XX-2, YY-1), tile(XX,YY,{landingTile}).


        ";

        aspCode += generateTargetASPCode();

        return aspCode;
    }
}
