using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour
{

    public GameObject brick;
    private int objectsByRow = 4;
    public float yOffset = 1;
    public int currentLevel = 2;

    private void Start()
    { 
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
                BrickIntegrityComponent brickIntegrity = brickObject.AddComponent<BrickIntegrityComponent>();
                brickIntegrity.Integrity = currentLevel;
            }
            currentX = initialX;
            currentY -= brick.transform.localScale.y;
        }
    }
}
