using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsTimerView : TimerView
{
    private const string PauseMessage = "Hearts timer is paused: ";
    private const string StartMessage = "Hearts timer started";
    private const string EndMessage = "Hearts timer ended";

    private readonly Vector3 ImageOffset = new Vector3(100, 0, 0);

    [SerializeField] private Image _heartPrefab;
    [SerializeField] private GameObject _heartsViewContainer;

    private int _heartsCount;
    private int _currentHeart;

    private List<Image> _heartsList;

    protected override void OnStarted()
    {
        Debug.Log(StartMessage);

        _heartsList.Add(Instantiate(_heartPrefab, _heartsViewContainer.transform.position, Quaternion.identity, _heartsViewContainer.transform));

        _heartsCount = (int)_timer.GivenTime;
        _currentHeart = _heartsCount;

        for (int i = 1; i < _heartsCount; i++)
        {
            Image heartImage = Instantiate(_heartPrefab, _heartsList[i - 1].rectTransform.position + ImageOffset, Quaternion.identity, _heartsViewContainer.transform);
            _heartsList.Add(heartImage);
        }
    }

    protected override void OnEnded()
    {
        foreach (Image heart in _heartsList)
            Destroy(heart);

        _heartsList.Clear();

        Debug.Log(EndMessage);
    }

    protected override void OnPaused(bool isPaused) => Debug.Log(PauseMessage + isPaused);

    protected override void OnValueChanged(float time)
    {
        if (_currentHeart != (int)time)
        {
            if (_heartsList.Count > 0)
            {
                Destroy(_heartsList[_currentHeart - 1]);
                _heartsList.Remove(_heartsList[_currentHeart - 1]);
            }

            _currentHeart = (int)time;
        }
    }

    public override void Initialize(Timer timer)
    {
        base.Initialize(timer);

        _heartsList = new List<Image>();
    }
}

