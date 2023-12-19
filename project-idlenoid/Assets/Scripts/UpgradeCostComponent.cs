using UnityEngine;

public class UpgradeCostComponent : MonoBehaviour, IUpgradeable, IBuyable
{
    UpgradeCostData data;
    int currentCost;

    public void Init(UpgradeCostData data)
    {
        this.data = data;
        currentCost = data.initialCost;
    }

    public bool CanBeUpgraded()
    {
        return PlayerScoreComponent.Instance.GetCoins() >= currentCost;
    }

    public int CurrentCost()
    {
        return currentCost;
    }
    public void BuyUpgrade()
    {
        PlayerScoreComponent.Instance.SpendCoins(currentCost);
        Upgrade();
    }
    public void Upgrade()
    {
        UpdateCost();
    }

    private void UpdateCost()
    {
        currentCost = Mathf.RoundToInt(currentCost * data.accumulator);
    }

}
