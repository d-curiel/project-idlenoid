using LootLocker.Requests;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    string memberID;
    int count = 50;
    string leaderboardID = "17314";
    string leaderboardKey = "timelapse";
    public LootLockerLeaderboardMember[] leaderboardData { get; private set; }
    public static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("ScoreManager");
                    instance = manager.AddComponent<ScoreManager>();
                }
            }

            return instance;
        }
    }


    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        TaskCompletionSource<LootLockerGuestSessionResponse> initSesionTask = new TaskCompletionSource<LootLockerGuestSessionResponse>();

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            initSesionTask.SetResult(response);
        });
        LootLockerGuestSessionResponse response = await initSesionTask.Task;
        if (!response.success)
        {
            Debug.Log("error starting LootLocker session");
            return;
        } else
        {
            memberID = response.player_id.ToString();
        }
    }


    public async Task<LootLockerGetScoreListResponse> GetLeaderboard()
    {

        TaskCompletionSource<LootLockerGetScoreListResponse> tcs = new TaskCompletionSource<LootLockerGetScoreListResponse>();

        LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
        {
            tcs.SetResult(response);
        });

        return await tcs.Task;
    }

    public async Task<LootLockerSubmitScoreResponse> SubmitScore(int scoreTime)
    {
        TaskCompletionSource<LootLockerSubmitScoreResponse> tcs = new TaskCompletionSource<LootLockerSubmitScoreResponse>();
        LootLockerSDKManager.SubmitScore(memberID, scoreTime, leaderboardID, (response) =>
        {
            tcs.SetResult(response);
        });
        return await tcs.Task;
    }
}
