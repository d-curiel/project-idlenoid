using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerScoreComponent : MonoBehaviour
{
    private int playerCoins = 0;
    [SerializeField]
    TextMeshProUGUI playerCoinsUIText;

    public static PlayerScoreComponent instance;
    public static PlayerScoreComponent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerScoreComponent>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("PlayerScore");
                    instance = manager.AddComponent<PlayerScoreComponent>();
                }
            }

            return instance;
        }
    }

    private void Start()
    {
        playerCoinsUIText = GetComponent<TextMeshProUGUI>();
        playerCoinsUIText.SetText(GetCoins().ToString());
    }

    private void OnEnable()
    {
        BrickIntegrityComponent.IntegrityDamagedReleased += EarnCoins;
    }

    private void OnDisable()
    {
        BrickIntegrityComponent.IntegrityDamagedReleased -= EarnCoins;
    }

    private void EarnCoins(int coins)
    {
        playerCoins += coins;
        playerCoinsUIText.SetText(GetCoins().ToString());
    }

    public void SpendCoins(int coins)
    {
        playerCoins -= coins;
        playerCoinsUIText.SetText(GetCoins().ToString());
    }

    public int GetCoins()
    {
        return playerCoins;
    }
}
