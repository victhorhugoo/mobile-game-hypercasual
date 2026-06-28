using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceManager> levelPiecesStart;
    public List<LevelPieceManager> levelPieces;
    public List<LevelPieceManager> levelPiecesEnd;

    public int pieceStartNumber = 3;
    public int pieceNumber = 5;
    public int pieceEndNumber = 1;
}
