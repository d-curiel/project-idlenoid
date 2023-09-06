using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBallGenerator : UpgradeatorComponent
{
    [SerializeField]
    protected GameObject ball;
    [SerializeField]
    protected Transform initialPosition;
    protected List<GameObject> currentBalls = new List<GameObject>();
    public static PowerBallGenerator instance;
    public static PowerBallGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PowerBallGenerator>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("PowerBallGenerator");
                    instance = manager.AddComponent<PowerBallGenerator>();
                }
            }

            return instance;
        }
    }
    public void GenerateBall()
    {
        BuyUpgrade();
        GameObject newBall = Instantiate(ball, initialPosition.position, Quaternion.identity);
        newBall.AddComponent<HardBouncerComponent>().Initialize(BallStrengthUpgraderComponent.Instance.GetCurrentStrength());
        currentBalls.Add(newBall);
    }

    public List<GameObject> GetCurrentBalls()
    {
        return currentBalls;
    }
}
