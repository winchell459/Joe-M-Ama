using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGenerator : CheckeredPathGenerator
{

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
        string aspCode = $@"
            
            chess_pieces(king_black;king_white).
            0{{piece_start(XX,YY,Type): chess_pieces(Type)}}1 :- tile(XX,YY,{tile_types.filled}).
            piece_path(XX,YY) :- piece_start(XX,YY,_).

        ";

        return aspCode;
    }
}