using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;
    [SerializeField, Range(0, 1)] private float _pauseTimeScale;
    [SerializeField] private bool _isPaused;
    private float _defaultPauseTimeScale;

    private void Start()
    {
        _defaultPauseTimeScale = _pauseTimeScale;
    }

    private void Update()
    {
        if (isTouchingOnScreen())
        {
            if (_isPaused)
            {
                ResumeGame();
            }
        }
        else
        {
            StopGame();
        }
    }

    private void ResumeGame()
    {
        StartCoroutine(WaitAndContinueGame());
    }
    private void StopGame()
    {
        this._panelPause.SetActive(true);
        _pauseTimeScale = _defaultPauseTimeScale;
        Time.timeScale = _pauseTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        _isPaused = true;
    }
    private bool isTouchingOnScreen()
    {
        return Input.touchCount > 0;
    }
    private IEnumerator WaitAndContinueGame()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        this._panelPause.SetActive(false);
        _pauseTimeScale = 1;
        Time.timeScale = _pauseTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        _isPaused = false;
    }
}
