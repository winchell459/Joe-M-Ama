using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPBishop", menuName = "ASP/Piece/Bishop")]
public class ASPBishop : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";
        aspCode += generateTargetASPCode();
        aspCode += generateDiagonalASPCode(predicate, landingTile, emptyTile, obstacleTile);
        return aspCode;
    }
}