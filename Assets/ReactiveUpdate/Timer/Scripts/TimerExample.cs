using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private SliderTimerView _sliderView;
    [SerializeField] private HeartsTimerView _heartsView;

    [SerializeField] private float _timeForSliderTimer;
    [SerializeField] private float _timeForHeartsTimer;

    private Timer _sliderTimer;
    private Timer _heartsTimer;

    private void Awake()
    {
        _sliderTimer = new Timer(_timeForSliderTimer, this);
        _heartsTimer = new Timer(_timeForHeartsTimer, this);

        _sliderView.Initialize(_sliderTimer);
        _heartsView.Initialize(_heartsTimer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _sliderTimer.Start();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _sliderTimer.Clear();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _sliderTimer.Paus();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            _heartsTimer.Start();

        if (Input.GetKeyDown(KeyCode.Alpha5))
            _heartsTimer.Clear();

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _heartsTimer.Paus();
    }
}