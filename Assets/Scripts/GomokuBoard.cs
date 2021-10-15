using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuBoard : Board
{
    public Rock rockWhitePrefab, rockBlackPrefab;
    public override void squareClicked(BoardSquare square)
    {
        if(SelectedPiece.ValidMove(GetSquareIndex(square)))
        {
            square.PlacePiece(SelectedPiece);
            SelectedPiece.gameObject.SetActive(true);

            if(SelectedPiece.pieceColor == BoardPiece.PieceColors.black)
            {
                SelectedPiece = Instantiate(rockWhitePrefab);

            }
            else
            {
                SelectedPiece = Instantiate(rockBlackPrefab);
            }
            SelectedPiece.gameObject.SetActive(false);
        }
    }

    protected override void setupBoardPieces()
    {
        SelectedPiece = Instantiate(rockBlackPrefab);
        SelectedPiece.gameObject.SetActive(false);
    }
 }
