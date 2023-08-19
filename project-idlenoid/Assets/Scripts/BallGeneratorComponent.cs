using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorComponent : MonoBehaviour
{
    //TODO: esta clase se tiene que convertir en un estático
    [SerializeField]
    GameObject ball;
    [SerializeField]
    Transform initialPosition;
    List<GameObject> currentBalls = new List<GameObject>();
    public void GenerateBall()
    {
        if(currentBalls.Count < 11)
        {
            currentBalls.Add(Instantiate(ball, initialPosition.position, Quaternion.identity));
        }
        
    }
}
