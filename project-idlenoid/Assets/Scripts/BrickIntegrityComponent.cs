using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrickIntegrityComponent : MonoBehaviour
{
    private int integrity;
    public int Integrity
    {
        get { return integrity; }
        set
        {
            integrity = value;
            text.SetText(integrity.ToString());
        }
    }
    [SerializeField]
    TextMeshPro text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIntegrity();
    }

    private void OnEnable()
    {
        text = transform.GetComponentInChildren<TextMeshPro>();
    }

    private void CheckIntegrity()
    {
        integrity--;
        if(integrity == 0)
        {
            gameObject.SetActive(false);
        }
        text.SetText(integrity.ToString());
    }
}
