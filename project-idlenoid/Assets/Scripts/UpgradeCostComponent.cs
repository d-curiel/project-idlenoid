using UnityEngine;

public class UpgradeCostComponent : MonoBehaviour
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
        UpdateCost();
    }

    private void UpdateCost()
    {
        currentCost = Mathf.RoundToInt(currentCost * data.accumulator);
    }

}
