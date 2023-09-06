using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStrengthUpgraderComponent : UpgradeatorComponent
{
    //TODO: Sacar valores de inicialización a scriptables
    int strengthIncrementation = 1;
    int currentStrength = 1;
    private static BallStrengthUpgraderComponent instance;
    public static BallStrengthUpgraderComponent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BallStrengthUpgraderComponent>();

                if (instance == null)
                {
                    instance = new GameObject("BallStrengthUpgrader").AddComponent<BallStrengthUpgraderComponent>();
                }
            }

            return instance;
        }
    }
    public void IncrementStrength()
    {
        BuyUpgrade();
        currentStrength += strengthIncrementation;
        List<GameObject> ballsActive = PowerBallGenerator.Instance.GetCurrentBalls();
        foreach (GameObject ballActive in ballsActive)
        {
            HardBouncerComponent hardBouncer = ballActive.GetComponent<HardBouncerComponent>();
            if (hardBouncer != null)
            {
                hardBouncer.IncrementStrength(strengthIncrementation);
            }
        }
    }

    public int GetCurrentStrength()
    {
        return currentStrength;
    }
}
