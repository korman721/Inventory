using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action Started;
    public event Action Ended;
    public event Action<bool> Paused;

    private float _givenTime;

    private ReactiveVariable<float> _currentTime;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process = null;

    private bool _isPaused = false;

    public Timer(float givenTime, MonoBehaviour coroutineRunner)
    {
        _currentTime = new ReactiveVariable<float>(givenTime);
        _givenTime = givenTime;
        _coroutineRunner = coroutineRunner;
    }

    public float GivenTime => _givenTime;

    public IReadOnlyVariable<float> CurrentTime => _currentTime;

    public bool IsRunning => _coroutineRunner != null;

    public void Start()
    {
        _currentTime.Value = _givenTime;

        if (_process == null)
        {
            _process = _coroutineRunner.StartCoroutine(Process());
            Started?.Invoke();
        }
    }

    public void Clear()
    {
        if (_process != null)
        {
            _coroutineRunner.StopCoroutine(_process);
            _process = null;

            _currentTime.Value = _givenTime;

            Ended?.Invoke();
        }
    }

    public void Paus()
    {
        if (_isPaused)
            _isPaused = false;
        else
            _isPaused = true;

        Paused?.Invoke(_isPaused);
    }

    private IEnumerator Process()
    {
        while (_currentTime.Value > 0)
        {
            if (_isPaused == false)
            {
                _currentTime.Value -= Time.deltaTime;

                if (_currentTime.Value <= 0)
                    _currentTime.Value = 0;
            }

            yield return null;
        }

        _process = null;
        _currentTime.Value = _givenTime;
        Ended?.Invoke();
    }
}
