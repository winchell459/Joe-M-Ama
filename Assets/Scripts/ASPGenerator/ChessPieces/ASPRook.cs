using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPRook", menuName = "ASP/Piece/Rook")]
public class ASPRook : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";
        aspCode += generateTargetASPCode();
        aspCode += generateRookMoveASPCode(predicate, landingTile, emptyTile, obstacleTile);
        return aspCode;
    }
}
