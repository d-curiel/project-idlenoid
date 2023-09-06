using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject brick;
    [SerializeField]
    int currentLevel = 1;
    [SerializeField]
    AudioClip brickIntegrityAudioClip;
    int maxLevel = 50;
    List<List<GameObject>> createdBricks = new List<List<GameObject>>();
    List<GameObject> activeBricks;
    Vector2[,] structuresSkeleton;
    private bool gameEnd = false;

    public delegate void GameOverDelegate();
    public static event GameOverDelegate GameOverReleased;

    private void Start()
    {
        InitializeSctructureSkeleton();
        InitializeAllBricksStructures();
        ActivateBricks();
    }

    private void Update()
    {
       if(currentLevel == maxLevel && !gameEnd)
        {
            gameEnd = true;
            GameOverReleased?.Invoke();
        }
    }

    private void OnEnable()
    {
        BrickIntegrityComponent.BrickDestroyedReleased += CheckDestroyedActivatedBricks;
    }

    private void OnDisable()
    {
        BrickIntegrityComponent.BrickDestroyedReleased -= CheckDestroyedActivatedBricks;
    }

    private void CheckDestroyedActivatedBricks()
    {
        if (AllDeactivatedBricks())
        {
            currentLevel++;
            ActivateBricks();
        }
    }
    private bool AllDeactivatedBricks()
    {
        return activeBricks.Find(activeBrick => activeBrick.activeInHierarchy) == null;
    }
    private void ActivateBricks()
    {
        activeBricks = createdBricks[UnityEngine.Random.Range(0, createdBricks.Count)];
        foreach (GameObject brick in activeBricks)
        {
            brick.SetActive(true);
            ClickableComponent buttonBehaviour = brick.GetComponent<ClickableComponent>();
            buttonBehaviour.Initialize(currentLevel, brickIntegrityAudioClip);
        }
    }
    private void InitializeSctructureSkeleton()
    {
        float verticalMiddle = Camera.main.orthographicSize;
        float horizontalMiddle = verticalMiddle * 2;

        //Cálculo del esqueleto del playground
        Vector2 sprite_size = brick.GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / brick.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        float initialX = horizontalMiddle - Mathf.FloorToInt((StructureStaticData.rows * world_size.x) / 2);
        float initialY = (verticalMiddle + Mathf.FloorToInt((StructureStaticData.cols * world_size.y) / 2) + world_size.y);

        structuresSkeleton = new Vector2[StructureStaticData.rows, StructureStaticData.cols];

        float currentCol;
        float currentRow = initialY;

        for (int row = 0; row < StructureStaticData.rows; row++)
        {
            currentCol = initialX;
            for (int col = 0; col < StructureStaticData.cols; col++)
            {
                structuresSkeleton[row, col] = new Vector2(currentCol, currentRow);
                currentCol += world_size.x;
            }
            currentRow -= world_size.y;
        }
    }
    private void InitializeAllBricksStructures()
    {
        for (int currentStructure = 0; currentStructure < StructureStaticData.structures.Count; currentStructure++)
        {
            List<GameObject> newGround = new List<GameObject>();
            for (int i = 0; i < structuresSkeleton.GetLength(0); i++)
            {
                for (int j = 0; j < structuresSkeleton.GetLength(1); j++)
                {
                    if (StructureStaticData.structures[currentStructure][i, j] == 1)
                    {
                        GameObject brickObject = Instantiate(brick, structuresSkeleton[i, j], Quaternion.identity);
                        brickObject.AddComponent<ClickableComponent>();
                        brickObject.SetActive(false);
                        newGround.Add(brickObject);
                    }
                }
            }
            createdBricks.Add(newGround);
        }
    }
}
