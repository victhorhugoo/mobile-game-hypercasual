using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //publics
    public Transform container;

    public List<GameObject> levels;

    public List<LevelPieceBasedSetup> levelPieceBasedSetup;
    
    public float timeBetweenPieces = .3f;

    //Privates
    [SerializeField] private int _index;
    private GameObject _currentLevel;

    private List<LevelPieceManager> _spawnedPieces = new List<LevelPieceManager>();
    private LevelPieceBasedSetup _currSetup;

    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region
    private void CreateLevelPieces()
    {
        
        CleanSpawnedPieces();

        if (_currSetup != null)
        {
            _index++;
            if(_index >= levelPieceBasedSetup.Count)
            {
                ResetLevelIndex() ;
            }
        }

        _currSetup = levelPieceBasedSetup[_index];

        for (int i = 0; i < _currSetup.pieceStartNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }
        for (int i = 0; i < _currSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }
        for (int i = 0; i < _currSetup.pieceEndNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }
        //StartCoroutine(CreateLevelPiecesCoroutine());

        ColorManager.Instance.ChangeColorByType(_currSetup.artType);
    }

    private void CreateLevelPiece(List<LevelPieceManager> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[ _spawnedPieces.Count - 1];
            spawnPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnPiece.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnPiece);
    }

    private void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceManager>();
        for (int i = 0; i < _currSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }

    #endregion
}
