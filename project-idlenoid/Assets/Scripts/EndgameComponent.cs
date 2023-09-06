using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndgameComponent : MonoBehaviour
{
    [SerializeField]
    GameObject endGamePanel;
    [SerializeField]
    TextMeshProUGUI finalScoreUIText;
    [SerializeField]
    Button mainMenuButton;
    private void OnEnable()
    {
        StructureGenerator.GameOverReleased += OnGameOverReleased;
    }

    private void OnDisable()
    {
        StructureGenerator.GameOverReleased -= OnGameOverReleased;
    }

    async void OnGameOverReleased()
    {
        endGamePanel.SetActive(true);
        await SaveScore();

    }

    private async Task SaveScore()
    {
        int finalScore = Mathf.RoundToInt(TimerManager.Instance.timeElapsed) + PlayerScoreComponent.Instance.GetCoins();
        finalScoreUIText.text = finalScore.ToString();
        await ScoreManager.Instance.SubmitScore(finalScore);
        mainMenuButton.gameObject.SetActive(true);
    }

}
