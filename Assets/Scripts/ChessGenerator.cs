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
        
           chess_pieces(black;white).
            #const max_king = 1.
            #const max_queen = 1.
            #const max_rook = 1.
            #const max_knight = 1.
            #const max_bishop = 1.
            #const max_pawn = 1.

           1{{piece_start(XX,YY,king_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_king).
           1{{piece_start(XX,YY,queen_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_queen).
           1{{piece_start(XX,YY,rook_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_rook).
           1{{piece_start(XX,YY,knight_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_knight).
           1{{piece_start(XX,YY,bishop_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_bishop).
           1{{piece_start(XX,YY,pawn_white,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_pawn).
           
           1{{piece_start(XX,YY,king_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_king).
           1{{piece_start(XX,YY,queen_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_queen).
           1{{piece_start(XX,YY,rook_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_rook).
           1{{piece_start(XX,YY,knight_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_knight).
           1{{piece_start(XX,YY,bishop_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_bishop).
           1{{piece_start(XX,YY,pawn_black,ID): tile(XX,YY,{tile_types.filled})}}1 :-  ID = (1..max_pawn).

            :-piece_start(XX,YY,T1,TD1), piece_start(XX,YY,T2,TD2), T1 != T2.
            :-piece_start(XX,YY,T1,TD1), piece_start(XX,YY,T2,TD2), TD1 != TD2.

            piece_path(XX,YY) :- piece_start(XX,YY,_,_).
            piece_path(XX,YY) :- piece_path(XX,YY,_,_).

            piece_path(XX,YY,pawn_black,ID) :- piece_start(XX,YY,pawn_black,ID).
            piece_path(XX,YY,pawn_black,ID) :- piece_start(XX,YY-1,pawn_black,ID), tile(XX,YY,{tile_types.filled}).

            piece_path(XX,YY,pawn_whiteID) :- piece_start(XX,YY,pawn_black,ID).
            piece_path(XX,YY,pawn_white,ID) :- piece_start(XX,YY+1,pawn_black,ID), tile(XX,YY,{tile_types.filled}).

            piece_path(XX,YY,Queen,ID) :- piece_start(XX,YY,Queen,ID), Queen = (queen_white;queen_black).
            piece_path(XX,YY,Queen,ID) :- piece_start(XX - II,YY,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(II).
            piece_path(XX,YY,Queen,ID) :- piece_start(XX + II,YY,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(II).
        
        ";

        return aspCode;
    }
}