using TMPro;
using UnityEngine;

public class PlayerScoreDataComponent : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI rank;
    [SerializeField]
    TextMeshProUGUI score;

    public void SetData(PlayerScore scoreData)
    {
        rank.text = scoreData.rank.ToString();
        score.text = scoreData.score.ToString();
    }
}
