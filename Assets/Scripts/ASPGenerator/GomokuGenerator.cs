using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuGenerator : CheckeredPathGenerator
{
    int winningLength = 4;
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
        
            gomoku_pieces(white;black).
            0{{piece_start(XX,YY,Type): gomoku_pieces(Type)}}1 :- tile(XX,YY,{tile_types.filled}).
            piece_path(XX,YY) :- piece_start(XX,YY,_).

            0{{piece_path(XX,YY)}}1 :- tile(XX,YY,{tile_types.filled}).
        ";

        string winningASPCode = "winner(Type) :- gomoku_pieces(Type)";
        for(int i = 0; i < winningLength; i += 1)
        {
            winningASPCode += $", piece_start(XX+{i},YY,Type)";
        }
        winningASPCode += ".\n";
        aspCode += winningASPCode;

        winningASPCode = "winner(Type) :- gomoku_pieces(Type)";
        for (int i = 0; i < winningLength; i += 1)
        {
            winningASPCode += $", piece_start(XX,YY+{i},Type)";
        }
        winningASPCode += ".\n";
        aspCode += winningASPCode;

        winningASPCode = "winner(Type) :- gomoku_pieces(Type)";
        for (int i = 0; i < winningLength; i += 1)
        {
            winningASPCode += $", piece_start(XX+{i},YY+{i},Type)";
        }
        winningASPCode += ".\n";
        aspCode += winningASPCode;

        winningASPCode = "winner(Type) :- gomoku_pieces(Type)";
        for (int i = 0; i < winningLength; i += 1)
        {
            winningASPCode += $", piece_start(XX-{i},YY+{i},Type)";
        }
        winningASPCode += ".\n";
        aspCode += winningASPCode;

        aspCode += ":- winner(_).";

        return aspCode;
    }
}
