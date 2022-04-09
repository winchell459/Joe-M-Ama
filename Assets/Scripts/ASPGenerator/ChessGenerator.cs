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

            chess_pieces_white(king_white).
            chess_pieces_white(king_black).

            %piece_path(XX,YY) :- piece_start(XX,YY,_).

        %% Kings
            :- piece_start(XX,YY,P1), piece_start(XX,YY,P2), P1 != P2.
            1{{piece_start(XX,YY,king_black): tile(XX,YY,{tile_types.filled})}}1.
            1{{piece_start(XX,YY,king_white): tile(XX,YY,{tile_types.filled})}}1.

            king_black(XX,YY) :- piece_start(XX,YY,king_black).
            king_black(XX,YY) :- tile(XX,YY,{tile_types.filled}), king_black(XX + I, YY + J), I = (-1..1), J = (-1..1).
            piece_path(XX,YY) :- king_black(XX,YY).

            king_white(XX,YY) :- piece_start(XX,YY,king_white).
            king_white(XX,YY) :- tile(XX,YY,{tile_types.filled}), king_white(XX + I, YY + J), I = (-1..1), J = (-1..1).
            piece_path(XX,YY) :- king_white(XX,YY).

            
            
        %% Pawns
            #const max_pawn = 8.
            pawns(1..max_pawn).

            1{{pawn_start(XX,YY,Color,ID) : tile(XX,YY,{tile_types.filled})}}1 :- pawns(ID), Color = (black;white).
            :- pawn_start(XX,YY,C1,ID1), pawn_start(XX,YY,C2,ID2), C1 != C2.
            :- pawn_start(XX,YY,C1,ID1), pawn_start(XX,YY,C2,ID2), ID1 != ID2.
            pawn_path(XX,YY,Color,ID) :- pawn_start(XX,YY,Color,ID).
            piece_start(XX,YY, pawn_white) :- pawn_start(XX,YY,white,ID), pawns(ID).
            piece_start(XX,YY, pawn_black) :- pawn_start(XX,YY,black,ID), pawns(ID).
            piece_path(XX,YY) :- pawn_path(XX,YY,_,_).

            pawn_path(XX,YY,black,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX,YY-1,black,ID).
            pawn_path(XX,YY,black,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX+1,YY-1,black,ID).
            pawn_path(XX,YY,black,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX-1,YY-1,black,ID).

            pawn_path(XX,YY,white,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX,YY+1,white,ID).
            pawn_path(XX,YY,white,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX+1,YY+1,white,ID).
            pawn_path(XX,YY,white,ID) :- tile(XX,YY,{tile_types.filled}), pawn_path(XX-1,YY+1,white,ID).


        %% Starting move rules
            :- not king_black(XX,YY), piece_start(XX,YY,king_white).
            :- not king_white(XX,YY), piece_start(XX,YY,king_black).
            :- piece_start(XX,YY,king_black), piece_start(XX+(-1..1),YY+(-1..1),king_white).

            :- piece_start(XX,YY,king_white), not pawn_path(XX,YY,black,ID), pawns(ID).
            :- piece_start(XX,YY,king_black), not pawn_path(XX,YY,white,ID), pawns(ID).
            :- pawn_start(XX,YY,white,_), piece_start(XX+(-1;1),YY-1,king_black).
            :- pawn_start(XX,YY,black,_), piece_start(XX+(-1;1),YY+1,king_white).
            

        ";

        return aspCode;
    }

    
}