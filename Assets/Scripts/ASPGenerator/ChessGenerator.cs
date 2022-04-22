using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGenerator : CheckeredPathGenerator
{
    [SerializeField] bool hasKings, hasQueens,  hasPawns,  hasBishops,  hasKnights,  hasRooks;
    public void InitializeGenerator(bool hasKings, bool hasQueens, bool hasPawns, bool hasBishops, bool hasKnights, bool hasRooks)
    {
        this.hasKings = hasKings;
        this.hasQueens = hasQueens;
        this.hasPawns = hasPawns;
        this.hasKnights = hasKnights;
        this.hasBishops = hasBishops;
        this.hasRooks = hasRooks;
    }
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

            
            colors(black; white).
            white(king_white;queen_white;pawn_white;rook_white;bishop_white;knight_white).
            black(king_black;queen_black;pawn_black;rook_black;bishop_black;knight_black).
            #const max_king = 1.
            #const max_queen = 1.
            #const max_pawn = 8.
            #const max_knight = 2.
            #const max_rook = 2.
            #const max_bishop = 2.
            
            :- piece_start(XX,YY, T1,ID1), piece_start(XX,YY,T2,ID2), T1 != T2.
            :- piece_start(XX,YY, T1,ID1), piece_start(XX,YY,T2,ID2), ID1 != ID2.

            piece_path(XX,YY) :- piece_start(XX,YY,_,_).
            piece_path(XX,YY) :- piece_path(XX,YY,_,_).
            
        ";
        aspCode += hasKings ? kingRules : "";
        aspCode += hasQueens ? queenRules : "";
        aspCode += hasPawns ? pawnRules : "";
        aspCode += hasKnights ? knightRules : "";
        aspCode += hasBishops ? bishopRules : "";
        aspCode += hasRooks ? rookRules : "";

        return aspCode;
    }

    string kingRules { get { return generateKingPathRules(); } }
    string pawnRules { get { return generatePawnPathRules(); } }
    string queenRules { get { return generateQueenPathRules(); } }
    string bishopRules { get { return generateBishopPathRules(); } }
    string rookRules { get { return generateRookPathRules(); } }
    string knightRules { get { return generateKnightPathRules(); } }

    string generateQueenPathRules()
    {
        string aspCode = $@"

            1{{piece_start(XX,YY,queen_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_queen).
            1{{piece_start(XX,YY,queen_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_queen).

            %% queen movement
            piece_path(XX,YY,Queen,ID) :- piece_start(XX,YY,Queen,ID), Queen = (queen_white;queen_black).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX + II,YY,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(II).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX - II,YY,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(II).

            piece_path(XX,YY,Queen,ID) :- piece_path(XX,YY + JJ,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), height(JJ).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX,YY - JJ,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), height(JJ).

            piece_path(XX,YY,Queen,ID) :- piece_path(XX + Offset,YY + Offset,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX - Offset,YY + Offset,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX + Offset,YY - Offset,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Queen,ID) :- piece_path(XX - Offset,YY - Offset,Queen,ID), Queen = (queen_white;queen_black), tile(XX,YY,{tile_types.filled}), width(Offset).

            :- not piece_path(XX,YY,queen_white,ID), piece_start(XX,YY,king_black,_), ID = (1..max_queen).
            :- not piece_path(XX,YY,queen_black,ID), piece_start(XX,YY,king_white,_), ID = (1..max_queen).
        ";
        return aspCode;
    }

    
    string generatePawnPathRules()
    {
        string aspCode = $@"
            1{{piece_start(XX,YY,pawn_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_pawn).
            1{{piece_start(XX,YY,pawn_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_pawn).
            
            %% pawn movement
            piece_path(XX,YY,pawn_black,ID) :- piece_start(XX,YY,pawn_black,ID).
            piece_path(XX,YY,pawn_black,ID) :- piece_path(XX,YY-1,pawn_black,ID), tile(XX,YY,{tile_types.filled}).
            piece_path(XX,YY,pawn_black,ID) :- piece_path(XX+1,YY-1,pawn_black,ID), tile(XX,YY,{tile_types.filled}), piece_path(XX,YY,Enemy,_), white(Enemy).
            piece_path(XX,YY,pawn_black,ID) :- piece_path(XX-1,YY-1,pawn_black,ID), tile(XX,YY,{tile_types.filled}), piece_path(XX,YY,Enemy,_), white(Enemy).

            valid_pawn(pawn_black,ID) :- piece_start(XX,YY,king_white,_), piece_path(XX+(-1;1),YY-1, pawn_black,ID).
            :- piece_start(_,_,pawn_black,ID), not valid_pawn(pawn_black,ID). 

            piece_path(XX,YY,pawn_white,ID) :- piece_start(XX,YY,pawn_white,ID).
            piece_path(XX,YY,pawn_white,ID) :- piece_path(XX,YY+1,pawn_white,ID), tile(XX,YY,{tile_types.filled}).
            piece_path(XX,YY,pawn_white,ID) :- piece_path(XX+1,YY+1,pawn_white,ID), tile(XX,YY,{tile_types.filled}), piece_path(XX,YY,Enemy,_), black(Enemy).
            piece_path(XX,YY,pawn_white,ID) :- piece_path(XX-1,YY+1,pawn_white,ID), tile(XX,YY,{tile_types.filled}), piece_path(XX,YY,Enemy,_), black(Enemy).

            valid_pawn(pawn_white,ID) :- piece_start(XX,YY,king_black,_), piece_path(XX+(-1;1),YY+1, pawn_white,ID).
            :- piece_start(_,_,pawn_white,ID), not valid_pawn(pawn_white,ID). 

        ";
        return aspCode;
    }

    
    string generateKingPathRules()
    {
        string aspCode = $@"
            1{{piece_start(XX,YY,king_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_king).
            1{{piece_start(XX,YY,king_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_king).

            king(king_white;king_black).
            piece_path(XX,YY,King,ID) :- piece_start(XX,YY,King,ID), king(King).
            piece_path(XX,YY,King,ID) :- tile(XX,YY,{tile_types.filled}), piece_path(XX+II,YY+JJ,King,ID), king(King), II = (-1;0;1), JJ=(-1;0;1).
            
        ";
        aspCode += $@"
            king_border(XX,YY,king_black,ID) :- piece_start(XX+II, YY+JJ, king_black,ID), piece_start(XX,YY,Friend, _), black(Friend), II = (-1;0;1), JJ=(-1;0;1).
            %king_border(XX,YY,king_black,ID) :- piece_start(XX+II, YY+JJ, king_black,ID), XX > max_width, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_black,ID) :- piece_start(XX+II, YY+JJ, king_black,ID), XX < 1, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_black,ID) :- piece_start(XX+II, YY+JJ, king_black,ID), YY > max_height, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_black,ID) :- piece_start(XX+II, YY+JJ, king_black,ID), YY < 1, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).

            king_border(XX,YY,king_white,ID) :- piece_start(XX+II, YY+JJ, king_white,ID), piece_start(XX,YY,Friend, _), white(Friend), II = (-1;0;1), JJ=(-1;0;1).
            %king_border(XX,YY,king_white,ID) :- piece_start(XX+II, YY+JJ, king_white,ID), XX > max_width, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_white,ID) :- piece_start(XX+II, YY+JJ, king_white,ID), XX < 1, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_white,ID) :- piece_start(XX+II, YY+JJ, king_white,ID), YY > max_height, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).
            %king_border(XX,YY,king_white,ID) :- piece_start(XX+II, YY+JJ, king_white,ID), YY < 1, II = (-1;0;1), JJ=(-1;0;1), width(XX+II), height(YY+JJ).

            king_protected(XX,YY,King,ID) :- king(King), piece_start(XX,YY,King,ID), 
                king_border(XX+1,YY,King,ID), 
                king_border(XX-1,YY,King,ID), 
                king_border(XX,YY+1,King,ID), 
                king_border(XX,YY-1,King,ID), 
                king_border(XX+1,YY+1,King,ID), 
                king_border(XX-1,YY-1,King,ID), 
                king_border(XX+1,YY-1,King,ID), 
                king_border(XX-1,YY+1,King,ID).

            :- piece_start(XX,YY,King,ID), not king_protected(XX,YY,King,ID), king(King).
        ";
        return aspCode;
    }

    
    string generateRookPathRules()
    {
        string aspCode = $@"
            1{{piece_start(XX,YY,rook_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_rook).
            1{{piece_start(XX,YY,rook_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_rook).

            rook(rook_white;rook_black).
            piece_path(XX,YY,Rook,ID) :- piece_start(XX,YY,Rook,ID), rook(Rook).
            piece_path(XX,YY,Rook,ID) :- piece_path(XX + II,YY,Rook,ID), rook(Rook), tile(XX,YY,{tile_types.filled}), width(II).
            piece_path(XX,YY,Rook,ID) :- piece_path(XX - II,YY,Rook,ID), rook(Rook), tile(XX,YY,{tile_types.filled}), width(II).

            piece_path(XX,YY,Rook,ID) :- piece_path(XX,YY + JJ,Rook,ID), rook(Rook), tile(XX,YY,{tile_types.filled}), height(JJ).
            piece_path(XX,YY,Rook,ID) :- piece_path(XX,YY - JJ,Rook,ID), rook(Rook), tile(XX,YY,{tile_types.filled}), height(JJ).
            
            :- not piece_path(XX,YY,rook_white,(1..max_rook)), piece_start(XX,YY,king_black,_).
            :- not piece_path(XX,YY,rook_black,(1..max_rook)), piece_start(XX,YY,king_white,_).
        ";
        return aspCode;
    }

    
    string generateKnightPathRules()
    {
        string aspCode = $@"
            1{{piece_start(XX,YY,knight_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_knight).
            1{{piece_start(XX,YY,knight_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_knight).

            knight(knight_white;knight_black).
            piece_path(XX,YY,Knight,ID) :- piece_start(XX,YY,Knight,ID), knight(Knight).
            piece_path(XX,YY,Knight,ID) :- tile(XX,YY,{tile_types.filled}), piece_path(XX + II, YY + JJ, Knight,ID), knight(Knight), II = (2;-2), JJ = (1;-1).
            piece_path(XX,YY,Knight,ID) :- tile(XX,YY,{tile_types.filled}), piece_path(XX + II, YY + JJ, Knight,ID), knight(Knight), II = (1;-1), JJ = (2;-2).
            
            :- not piece_path(XX,YY,knight_white,(1..max_knight)), piece_start(XX,YY,king_black,_).
            :- not piece_path(XX,YY,knight_black,(1..max_knight)), piece_start(XX,YY,king_white,_).
        ";
        return aspCode;
    }

    
    string generateBishopPathRules()
    {
        string aspCode = $@"
            1{{piece_start(XX,YY,bishop_white,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_bishop).
            1{{piece_start(XX,YY,bishop_black,ID): tile(XX,YY,{tile_types.filled})}}1 :- ID = (1..max_bishop).
            
            bishop(bishop_white;bishop_black).
            
            piece_path(XX,YY,Bishop,ID) :- piece_start(XX,YY,Bishop,ID), bishop(Bishop).
            piece_path(XX,YY,Bishop,ID) :- piece_path(XX + Offset,YY + Offset,Bishop,ID), bishop(Bishop), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Bishop,ID) :- piece_path(XX - Offset,YY + Offset,Bishop,ID), bishop(Bishop), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Bishop,ID) :- piece_path(XX + Offset,YY - Offset,Bishop,ID), bishop(Bishop), tile(XX,YY,{tile_types.filled}), width(Offset).
            piece_path(XX,YY,Bishop,ID) :- piece_path(XX - Offset,YY - Offset,Bishop,ID), bishop(Bishop), tile(XX,YY,{tile_types.filled}), width(Offset).

            :- not piece_path(XX,YY,bishop_white,(1..max_bishop)), piece_start(XX,YY,king_black,_).
            :- not piece_path(XX,YY,bishop_black,(1..max_bishop)), piece_start(XX,YY,king_white,_).
        ";
        return aspCode;
    }
}