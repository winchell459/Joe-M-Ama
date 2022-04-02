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

    //string generatePiecePathRules()
    //{
    //    string aspCode = $@"

    //        chess_pieces(king_black;king_white).
    //        0{{piece_start(XX,YY,Type): chess_pieces(Type)}}1 :- tile(XX,YY,{tile_types.filled}).
    //        piece_path(XX,YY) :- piece_start(XX,YY,_).

    //    ";

    //    return aspCode;
    //}

    string generatePiecePathRules()
    {
        string aspCode = $@"
            
            piece_path(XX,YY) :- piece_start(XX,YY,_).

            1{{piece_start(XX,YY,king_black): tile(XX,YY,{tile_types.filled})}}1.
            1{{piece_start(XX,YY,king_white): tile(XX,YY,{tile_types.filled})}}1.

            king_white_path(XX,YY) :- piece_start(XX,YY,king_white).
            king_black_path(XX,YY) :- piece_start(XX,YY,king_black).

            piece_path(XX,YY) :- king_white_path(XX,YY).
            king_white_path(XX,YY) :- king_white_path(XX-1,YY), tile(XX,YY,{tile_types.filled}).
            king_white_path(XX,YY) :- king_white_path(XX+1,YY), tile(XX,YY,{tile_types.filled}).
            king_white_path(XX,YY) :- king_white_path(XX,YY-1), tile(XX,YY,{tile_types.filled}).
            king_white_path(XX,YY) :- king_white_path(XX,YY+1), tile(XX,YY,{tile_types.filled}).

            piece_path(XX,YY) :- king_black_path(XX,YY).
            king_black_path(XX,YY) :- king_black_path(XX-1,YY), tile(XX,YY,{tile_types.filled}).
            king_black_path(XX,YY) :- king_black_path(XX+1,YY), tile(XX,YY,{tile_types.filled}).
            king_black_path(XX,YY) :- king_black_path(XX,YY-1), tile(XX,YY,{tile_types.filled}).
            king_black_path(XX,YY) :- king_black_path(XX,YY+1), tile(XX,YY,{tile_types.filled}).

            8{{piece_start(XX,YY,pawn_black): tile(XX,YY,{tile_types.filled})}}8.
            8{{piece_start(XX,YY,pawn_white): tile(XX,YY,{tile_types.filled})}}8.

            piece_path(XX,YY) :- pawn_white_path(XX,YY).
            pawn_white_path(XX,YY) :- piece_start(XX,YY,pawn_white).
            pawn_white_path(XX,YY) :- pawn_white_path(XX,YY+1), tile(XX,YY,{tile_types.filled}).

            piece_path(XX,YY) :- pawn_black_path(XX,YY).
            pawn_black_path(XX,YY) :- piece_start(XX,YY,pawn_black).
            pawn_black_path(XX,YY) :- pawn_black_path(XX,YY-1), tile(XX,YY,{tile_types.filled}).


            :- piece_start(XX,YY, T1), piece_start(XX,YY, T2), T1 != T2.

            

        ";

        return aspCode;
    }
}