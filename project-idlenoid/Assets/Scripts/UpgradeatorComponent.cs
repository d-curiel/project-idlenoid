using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeatorComponent : MonoBehaviour
{
    [SerializeField]
    protected UpgradeCostData upgradeCostData;
    [SerializeField]
    Button uiButton;
    [SerializeField]
    TextMeshProUGUI costUIText;
    UpgradeCostComponent _UpgradeCost;

    private void Start()
    {
        _UpgradeCost = gameObject.AddComponent<UpgradeCostComponent>();
        _UpgradeCost.Init(upgradeCostData);
    }
    private void Update()
    {
        uiButton.interactable = _UpgradeCost.CanBeUpgraded();
        costUIText.SetText(_UpgradeCost.CurrentCost().ToString());
    }

    protected void BuyUpgrade()
    {
        _UpgradeCost.BuyUpgrade();
    }
}
