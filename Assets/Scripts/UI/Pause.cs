using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private Transform _continueButton;
    [SerializeField] private int _frames;
    [SerializeField] private int _scaleFrames;

    public void SetPause(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
        StartCoroutine(ChangeColor(isPause, () => gameObject.SetActive(isPause)));
        StartCoroutine(ScaleAnimation(_continueButton, isPause ? Vector3.one : Vector3.zero));
    }

    private IEnumerator ChangeColor(bool isPause, Action onTransitionEnd)
    {
        Color color = _bg.color;
        color.a = isPause ? 0 : 0.5f;

        float delta = 0.5f / _frames;
        if (isPause == false) delta *= -1;

        _bg.color = color;

        for (int i = 0; i < _frames; i++)
        {
            color.a += delta;
            _bg.color = color;
            yield return null;
        }

        onTransitionEnd?.Invoke();
    }

    private IEnumerator ScaleAnimation(Transform transform, Vector3 endScale)
    {
        var delta = (endScale - transform.localScale) / _scaleFrames;
        for (int i = 0; i < _scaleFrames; i++)
        {
            transform.localScale += delta;
            yield return null;
        }
    }
}