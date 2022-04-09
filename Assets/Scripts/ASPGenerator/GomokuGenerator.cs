using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuGenerator : CheckeredPathGenerator
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
        
            gomoku_pieces(black;white).
            0{{piece_start(XX,YY,Type): gomoku_pieces(Type)}}1 :- tile(XX,YY,{tile_types.filled}).
            piece_path(XX,YY) :- piece_start(XX,YY,_).

            :- BlackCount = {{piece_start(_,_,black)}}, WhiteCount = {{piece_start(_,_,white)}}, WhiteCount != BlackCount.

            :- Count = {{piece_start(_,_,black)}}, Count == 0.

            playable(XX,YY,Color) :- piece_path(XX,YY), not piece_start(XX,YY,Color2), Color2 != Color, gomoku_pieces(Color), gomoku_pieces(Color2).
            winnable_rock(XX,YY,Color) :- piece_start(XX,YY, Color), playable(XX+1,YY,Color), playable(XX+2,YY,Color), playable(XX+3,YY,Color), playable(XX+4,YY,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-1,YY,Color),piece_start(XX,YY, Color),  playable(XX+1,YY,Color), playable(XX+2,YY,Color), playable(XX+3,YY,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-2,YY,Color), playable(XX-1,YY,Color),piece_start(XX,YY, Color),  playable(XX+1,YY,Color), playable(XX+2,YY,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-3,YY,Color), playable(XX-2,YY,Color), playable(XX-1,YY,Color),piece_start(XX,YY, Color),  playable(XX+1,YY,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-4,YY,Color),playable(XX-3,YY,Color), playable(XX-2,YY,Color), playable(XX-1,YY,Color), piece_start(XX,YY, Color).

            winnable_rock(XX,YY,Color) :- piece_start(XX,YY, Color), playable(XX+1,YY+1,Color), playable(XX+2,YY+2,Color), playable(XX+3,YY+3,Color), playable(XX+4,YY+4,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-1,YY-1,Color),piece_start(XX,YY, Color),  playable(XX+1,YY+1,Color), playable(XX+2,YY+2,Color), playable(XX+3,YY+3,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-2,YY-2,Color), playable(XX-1,YY-1,Color),piece_start(XX,YY, Color),  playable(XX+1,YY+1,Color), playable(XX+2,YY+2,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-3,YY-3,Color), playable(XX-2,YY-2,Color), playable(XX-1,YY-1,Color),piece_start(XX,YY, Color),  playable(XX+1,YY+1,Color).
            winnable_rock(XX,YY,Color) :- playable(XX-4,YY-4,Color),playable(XX-3,YY-3,Color), playable(XX-2,YY-2,Color), playable(XX-1,YY-1,Color), piece_start(XX,YY, Color).

            :- piece_start(XX,YY,Color), not winnable_rock(XX,YY,Color).

            :- piece_start(XX,YY, Color), piece_start(XX+1,YY, Color), piece_start(XX+2,YY, Color), piece_start(XX+3,YY, Color), piece_start(XX+4,YY, Color), gomoku_pieces(Color).

            0{{piece_path(XX,YY)}}1 :- tile(XX,YY,{tile_types.filled}).
        ";

        return aspCode;
    }
}
