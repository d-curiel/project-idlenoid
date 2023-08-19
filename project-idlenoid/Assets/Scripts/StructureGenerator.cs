using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StructureGenerator : MonoBehaviour
{

    public GameObject brick;
    private int objectsByRow = 4;
    public float yOffset = 1;
    //TODO: Esta variable se debe de cambiar a una zona común
    public int currentLevel = 2;
    List<GameObject> createdBricks = new List<GameObject>();

    private void Start()
    { 
        //TODO: Toda esta estructura pasará a un método aislado
        float verticalMiddle = Camera.main.orthographicSize;
        float horizontalMiddle = verticalMiddle * 2;
        float initialX = horizontalMiddle - brick.transform.localScale.x * ((objectsByRow / 2) - brick.transform.localScale.x / 2);
        float initialY = (verticalMiddle * 2) - yOffset - brick.transform.localScale.y;
        float currentX = initialX;
        float currentY = initialY;
        while (currentY > yOffset)
        {
            for(int i = 0; i <= objectsByRow; i++)
            {
                Vector2 position = new Vector2(currentX, currentY);
                currentX += brick.transform.localScale.x;
                GameObject brickObject = Instantiate(brick, position, Quaternion.identity);
                createdBricks.Add(brickObject);
                ClickableComponent buttonBehaviour = brickObject.AddComponent<ClickableComponent>();
                buttonBehaviour.Initialize(currentLevel);
            }
            currentX = initialX;
            currentY -= brick.transform.localScale.y;
        }
    }

    private void Update()
    {
        //TODO: Esta estructura pasará a un conjunto de llamadas de evento
        if (AllDeactivatedBricks())
        {
            ReactivateBricks();
        }
    }

    private bool AllDeactivatedBricks()
    {
        return createdBricks.Find(createdBrick => createdBrick.activeInHierarchy) == null;
    }

    private void ReactivateBricks()
    {
        currentLevel++;
        foreach (GameObject brick in createdBricks)
        {
            ClickableComponent buttonBehaviour = brick.GetComponent<ClickableComponent>();
            buttonBehaviour.Initialize(currentLevel);
            brick.SetActive(true);
        }
    }
}
