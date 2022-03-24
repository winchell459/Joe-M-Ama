using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGenerator : CheckeredPathGenerator
{
    [SerializeField] ASPChessPiece[] pieces;

    protected override string getASPCode()
    {
        return base.getASPCode() + piecePathRules;
    }

    protected override string getCheckeredTileRule(int x, int y, string tileColor)
    {
        return $" checkered({x},{y},{tileColor}) :- piece_path({x},{y}), tile({x},{y},{tile_types.filled}).\n";
    }

    string piecePathRules { get { return generatePiecePathRules(); } }

    string generatePiecePathRules()
    {
        //string aspCode = $@"

        //    piece_path(XX,YY) :- piece_path(XX+1, YY), tile(XX,YY,{tile_types.filled}).
        //    piece_path(XX,YY) :- piece_path(XX-1, YY), tile(XX,YY,{tile_types.filled}).
        //    piece_path(XX,YY) :- piece_path(XX, YY+1), tile(XX,YY,{tile_types.filled}).
        //    piece_path(XX,YY) :- piece_path(XX, YY-1), tile(XX,YY,{tile_types.filled}).

        //    :- checkered(XX,YY,_), not piece_path(XX,YY).

        //    piece_path(1,1) :- checkered(1,1,_).
        //";

        //return aspCode;


        //return generatePiecePathRules("king_white", new Vector2Int(2, 2)) + generatePiecePathRules("king_black", new Vector2Int(19, 19));
        string aspCode = $@"

            #show tile/3.
            #show checkered/3.
            #show piece_start/3.
            #show width/1.
            #show height/1.
        ";
        foreach (ASPChessPiece piece in pieces)
        {
            aspCode += generatePiecePathRules(piece, piece.Start);
        }

        
        return aspCode;
    }
    

    string generatePiecePathRules(ASPPiece piece, Vector2Int start)
    {
        string aspCode = $@"
            
            :- {piece.Name}_path(XX,YY), not checkered(XX,YY,_).
            piece_path(XX,YY) :- {piece.Name}_path(XX,YY).
            :- {piece.Name}_path(XX,YY), not tile(XX,YY,{tile_types.filled}).
            
            {piece.Name}_path({start.x},{start.y}).
            piece_start({start.x},{start.y},{piece.Name}).
        ";
        aspCode += piece.GetASPCode("path", "filled", "empty", "obstacle");
        

        return aspCode;
    }
}
