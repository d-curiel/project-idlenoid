using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeCostData", menuName = "ScriptableObjects/UpgradeCostData", order = 1)]
public class UpgradeCostData : ScriptableObject
{
    public int initialCost;
    public float accumulator;
}
