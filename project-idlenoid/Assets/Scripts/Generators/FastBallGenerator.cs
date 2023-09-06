using System.Collections.Generic;
using UnityEngine;

public class FastBallGenerator : UpgradeatorComponent
{
    [SerializeField]
    protected GameObject ball;
    [SerializeField]
    protected Transform initialPosition;
    protected List<GameObject> currentBalls = new List<GameObject>();

    public static FastBallGenerator instance;
    public static FastBallGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FastBallGenerator>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("FastBallGenerator");
                    instance = manager.AddComponent<FastBallGenerator>();
                }
            }

            return instance;
        }
    }

    public void GenerateBall()
    {
        BuyUpgrade();
        GameObject newBall = Instantiate(ball, initialPosition.position, Quaternion.identity);
        newBall.AddComponent<FastBouncerComponent>().Initialize(BallSpeedUpgraderComponent.Instance.GetCurrentSpeed());
        currentBalls.Add(newBall);
    }

    public List<GameObject> GetCurrentBalls()
    {
        return currentBalls;
    }
}
