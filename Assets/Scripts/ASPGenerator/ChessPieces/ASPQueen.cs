using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPQueen", menuName = "ASP/Piece/Queen")]
public class ASPQueen : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";
        aspCode += generateTargetASPCode();
        aspCode += generateDiagonalASPCode(predicate, landingTile, emptyTile, obstacleTile);
        aspCode += generateRookMoveASPCode(predicate, landingTile, emptyTile, obstacleTile);
        return aspCode;
    }
}
