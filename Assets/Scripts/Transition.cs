using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private int _frames;
    [SerializeField] private float _startDelay;
    [SerializeField] private UnityEvent _onBlack;
    private bool _isPlay;

    public void PlayTransition()
    {
        if (_isPlay) return;
        _isPlay = true;
        StartCoroutine(ChangeColor(true, () =>
        {
            _onBlack?.Invoke();
            StartCoroutine(ChangeColor(false, () => _isPlay = false));
        }));
    }

    private IEnumerator ChangeColor(bool toBlack, Action onTransitionEnd)
    {
        yield return new WaitForSeconds(_startDelay);
        Color color = _image.color;
        color.a = toBlack ? 0 : 1;

        float delta = 1f / _frames;
        if (toBlack == false) delta *= -1;

        _image.color = color;

        for (int i = 0; i < _frames; i++)
        {
            color.a += delta;
            _image.color = color;
            yield return null;
        }

        onTransitionEnd?.Invoke();
    }
}