using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoard : ASPMap
{
    [SerializeField] Board board;

    override public void DisplayMap(Clingo.AnswerSet answerset, MapKey mapKey)
    {
        DisplayMap(answerset, mapKey.widthKey, mapKey.heightKey, mapKey.typeKey, mapKey.xIndex, mapKey.yIndex, mapKey.typeIndex, ((MapKeyPixel)mapKey).colorDict);
    }
    public void DisplayMap(Clingo.AnswerSet answerset, string widthKey, string heightKey, string tileKey, int xIndex, int yIndex, int pixelTypeIndex, MapObjectKey<Color> colorDict)
    {
        foreach (List<string> widths in answerset.Value[widthKey])
        {
            if (int.Parse(widths[0]) > width) width = int.Parse(widths[0]);
        }
        foreach (List<string> h in answerset.Value[heightKey])
        {
            if (int.Parse(h[0]) > height) height = int.Parse(h[0]);
        }

        

        foreach (List<string> tileASP in answerset.Value[tileKey])
        {
            int x = int.Parse(tileASP[xIndex]) - 1;
            int y = int.Parse(tileASP[yIndex]) - 1;

            string color = tileASP[pixelTypeIndex];

            board.boardSquares[x, y].gameObject.SetActive(true);
            board.boardSquares[x, y].GetComponent<SpriteRenderer>().color = colorDict[color];
        }
    }
}
