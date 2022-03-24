using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPPawn", menuName = "ASP/Piece/Pawn")]
public class ASPPawn : ASPChessPiece
{
    public override string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        return base.GetASPCode(predicate, landingTile, emptyTile, obstacleTile);
    }
}
