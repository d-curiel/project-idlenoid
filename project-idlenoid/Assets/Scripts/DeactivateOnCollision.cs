using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.SetActive(false);
    }
}
