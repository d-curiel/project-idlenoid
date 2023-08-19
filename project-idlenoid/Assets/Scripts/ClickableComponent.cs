using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableComponent : MonoBehaviour, IPointerClickHandler
{
    BrickIntegrityComponent brickIntegrity;
    public void Initialize(int currentLevel)
    {
        brickIntegrity = gameObject.GetComponent<BrickIntegrityComponent>();
        if(brickIntegrity == null)
        {
            brickIntegrity = gameObject.AddComponent<BrickIntegrityComponent>();
        }
        brickIntegrity.Integrity = currentLevel;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO: Obtener del player o de algún sitio el "daño" actual de los clicks
        brickIntegrity.CheckIntegrity(1);
    }

}
