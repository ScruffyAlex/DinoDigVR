using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "noiseSettings", menuName = "Data/BoneData")]
public class BoneData : ScriptableObject
{
    public string CreatureName;
    public string ScientificName;
    public string CreatureFact;
    public int PieceNum;

}