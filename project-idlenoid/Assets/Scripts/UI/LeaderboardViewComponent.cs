using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardViewComponent : MonoBehaviour
{
    [SerializeField]
    GameObject leaderboardItemPrefab;

    [SerializeField]
    VerticalLayoutGroup content;

    List<PlayerScore> leaderboard;

    private async void OnEnable()
    {
        await LoadLeaderboard();
    }

    private async Task LoadLeaderboard()
    {
        await GetLeaderboard();
        foreach (PlayerScore playerScore in leaderboard)
        {
            GameObject lead = Instantiate(leaderboardItemPrefab, content.transform);
            PlayerScoreDataComponent playerData;
            lead.TryGetComponent<PlayerScoreDataComponent>(out playerData);
            if (playerData)
            {
                playerData.SetData(playerScore);
            }
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private async Task GetLeaderboard()
    {
        var leadearboardResult = await ScoreManager.Instance.GetLeaderboard();
        if (leadearboardResult.statusCode == 200)
        {
            leaderboard = leadearboardResult.items.
            ToList().
            Select(scoreData => new PlayerScore(scoreData.rank, scoreData.score)).
            ToList();
        }
        
    }
}
