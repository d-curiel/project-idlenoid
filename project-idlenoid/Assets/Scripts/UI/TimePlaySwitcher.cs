using UnityEngine;
using UnityEngine.SceneManagement;

public class TimePlaySwitcher : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
