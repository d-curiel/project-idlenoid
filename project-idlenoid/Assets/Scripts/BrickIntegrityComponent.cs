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
        //TODO: Obtener del player o de algún sitio el "daño" actual de los objetos que colisionan
        CheckIntegrity(1);
    }

    private void OnEnable()
    {
        text = transform.GetComponentInChildren<TextMeshPro>();
    }

    public void CheckIntegrity(int intensity)
    {
        integrity -= intensity;
        if (integrity == 0)
        {
            gameObject.SetActive(false);
        }
        text.SetText(integrity.ToString());
    }
}
