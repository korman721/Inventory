using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    [SerializeField] private GameObject _view;

    protected Timer _timer;

    public virtual void Initialize(Timer timer)
    {
        _view.SetActive(true);

        _timer = timer;

        _timer.Started += OnStarted;
        _timer.Ended += OnEnded;
        _timer.CurrentTime.Changed += OnValueChanged;
        _timer.Paused += OnPaused;
    }

    protected void OnDestroy()
    {
        _timer.Started -= OnStarted;
        _timer.Ended -= OnEnded;
        _timer.CurrentTime.Changed -= OnValueChanged;
        _timer.Paused -= OnPaused;
    }

    protected abstract void OnStarted();

    protected abstract void OnEnded();

    protected abstract void OnValueChanged(float time);

    protected abstract void OnPaused(bool isPaused);

}