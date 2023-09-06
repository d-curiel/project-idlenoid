using System;
using TMPro;
using UnityEngine;

public class TimerComponent : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI secondsUIText;
    [SerializeField]
    TextMeshProUGUI minutesUIText;
    [SerializeField]
    TextMeshProUGUI hoursUIText;

    private void Update()
    {
        hoursUIText.SetText(TimeSpan.FromSeconds(TimerManager.Instance.timeElapsed).Hours.ToString());
        minutesUIText.SetText(TimeSpan.FromSeconds(TimerManager.Instance.timeElapsed).Minutes.ToString());
        secondsUIText.SetText(TimeSpan.FromSeconds(TimerManager.Instance.timeElapsed).Seconds.ToString());
    }
}
