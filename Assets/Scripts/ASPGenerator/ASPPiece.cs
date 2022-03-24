using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ASPPiece", menuName = "ASP/Piece")]
public class ASPPiece : ScriptableObject
{
    public string Name;
    public Move[] Moves { get { return generateMoves(); } }
    [SerializeField] Move[] moves;
    
    [System.Serializable]
    public struct Move
    {
        public int dx, dy;
    }
    protected virtual Move[] generateMoves()
    {
        return moves;
    }

    public virtual string GetASPCode(string predicate, string landingTile, string emptyTile, string obstacleTile)
    {
        string aspCode = "";


        

        return aspCode;
    }
}
