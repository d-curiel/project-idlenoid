using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorInterface: MonoBehaviour
{
    [SerializeField]
    protected GameObject ball;
    [SerializeField]
    protected Transform initialPosition;
    protected List<GameObject> currentBalls = new List<GameObject>();
}
