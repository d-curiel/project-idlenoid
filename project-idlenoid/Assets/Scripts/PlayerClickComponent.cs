using UnityEngine;
public class PlayerClickComponent : MonoBehaviour
{
    int clickPower = 1;
    private static PlayerClickComponent instance;

    public static PlayerClickComponent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerClickComponent>();

                if (instance == null)
                {
                    instance = new GameObject("PlayerClick").AddComponent<PlayerClickComponent>();
                }
            }

            return instance;
        }
    }

    public void UpgradeClickPower()
    {
        clickPower++;
    }

    public int GetClickPower()
    {
        return clickPower;
    }
}
