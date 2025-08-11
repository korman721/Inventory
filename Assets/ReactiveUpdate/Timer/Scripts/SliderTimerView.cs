using UnityEngine;
using UnityEngine.UI;

public class SliderTimerView : TimerView
{
    private const string PauseMessage = "Slider timer is paused: ";
    private const string StartMessage = "Slider timer started";
    private const string EndMessage = "Slider timer ended";

    [SerializeField] private Slider _slider;

    protected override void OnStarted()
    {
        Debug.Log(StartMessage);
        _slider.value = 1;
    }

    protected override void OnEnded()
    {
        Debug.Log(EndMessage);
        _slider.value = 0;
    }
    protected override void OnPaused(bool isPaused) => Debug.Log(PauseMessage + isPaused);

    protected override void OnValueChanged(float newtime) => _slider.value = newtime / _timer.GivenTime;
}
