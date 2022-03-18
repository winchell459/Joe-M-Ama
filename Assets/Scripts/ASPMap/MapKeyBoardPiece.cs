using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapKeyBoardPiece", menuName = "ASPMap/MapKey/MapKeyBoardPiece")]
public class MapKeyBoardPiece : MapKey
{
    public MapObjectKey<BoardPiece> dict;
}
