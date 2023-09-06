using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableComponent : MonoBehaviour, IPointerClickHandler
{
    BrickIntegrityComponent brickIntegrity;
    public void Initialize(int currentLevel, AudioClip audioClip)
    {
        brickIntegrity = gameObject.GetComponent<BrickIntegrityComponent>();
        if (brickIntegrity == null)
        {
            brickIntegrity = gameObject.AddComponent<BrickIntegrityComponent>();
        }
        brickIntegrity.Init(audioClip);
        brickIntegrity.Integrity = currentLevel;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        brickIntegrity.CheckIntegrity(PlayerClickComponent.Instance.GetClickPower());
    }

}
