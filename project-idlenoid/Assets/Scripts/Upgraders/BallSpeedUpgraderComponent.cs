using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUpgraderComponent : UpgradeatorComponent
{
    //TODO: Sacar valores de inicialización a scriptables
    float speedIncrementation = 0.2f;
    float currentSpeed = 2.5f;
    private static BallSpeedUpgraderComponent instance;
    public static BallSpeedUpgraderComponent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BallSpeedUpgraderComponent>();

                if (instance == null)
                {
                    instance = new GameObject("BallSpeedUpgrader").AddComponent<BallSpeedUpgraderComponent>();
                }
            }

            return instance;
        }
    }
    public void IncrementSpeed()
    {
        BuyUpgrade();
        currentSpeed += speedIncrementation;
        List<GameObject> ballsActive = FastBallGenerator.Instance.GetCurrentBalls();
        foreach(GameObject ballActive in ballsActive)
        {
            FastBouncerComponent fastBouncer = ballActive.GetComponent<FastBouncerComponent>();
            if(fastBouncer != null)
            {
                fastBouncer.IncrementSpeed(speedIncrementation);
            }
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
