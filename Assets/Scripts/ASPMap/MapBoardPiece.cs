using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoardPiece : ASPMap
{
    [SerializeField] ChessBoard board;

    override public void DisplayMap(Clingo.AnswerSet answerset, MapKey mapKey)
    {
        DisplayMap(answerset, mapKey.widthKey, mapKey.heightKey, mapKey.typeKey, mapKey.xIndex, mapKey.yIndex, mapKey.typeIndex, ((MapKeyBoardPiece)mapKey).dict);
    }
    public void DisplayMap(Clingo.AnswerSet answerset, string widthKey, string heightKey, string pieceKey, int xIndex, int yIndex, int pixelTypeIndex, MapObjectKey<BoardPiece> dict)
    {
        foreach (List<string> widths in answerset.Value[widthKey])
        {
            if (int.Parse(widths[0]) > width) width = int.Parse(widths[0]);
        }
        foreach (List<string> h in answerset.Value[heightKey])
        {
            if (int.Parse(h[0]) > height) height = int.Parse(h[0]);
        }

        Debug.Log("MapBoardPiece.DisplayMap");
        foreach (List<string> pieceStart in answerset.Value[pieceKey])
        {
            int x = int.Parse(pieceStart[xIndex]) - 1;
            int y = int.Parse(pieceStart[yIndex]) - 1;

            string pixelType = pieceStart[pixelTypeIndex];

            //BoardPiece piece = Instantiate(dict[pixelType], new Vector3(x, y, 0), Quaternion.identity);
            board.AddBoardPiece((ChessPiece)dict[pixelType], x, y);

        }
    }
}