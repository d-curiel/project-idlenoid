public class ClickUpgraderComponent : UpgradeatorComponent
{
    public void UpgradeClick()
    {
        BuyUpgrade();
        PlayerClickComponent.Instance.UpgradeClickPower();
    }
}
