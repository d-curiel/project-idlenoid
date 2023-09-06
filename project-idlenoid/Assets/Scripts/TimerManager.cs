using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timeElapsed { get; private set; }
    private bool count = true;
    private int initialTime = 7200;

    public static TimerManager instance;
    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimerManager>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("TimerManager");
                    instance = manager.AddComponent<TimerManager>();
                }
            }

            return instance;
        }
    }

    private void Start()
    {
        timeElapsed = initialTime;
    }

    private void FixedUpdate()
    {
        if (count)
        {
            timeElapsed -= Time.fixedDeltaTime;
        }
    }
    void OnEnable()
    {
        StructureGenerator.GameOverReleased += StopCounting;
    }
    void OnDisable()
    {
        StructureGenerator.GameOverReleased -= StopCounting;
    }

    void StopCounting()
    {
        count = false;
    }
}
