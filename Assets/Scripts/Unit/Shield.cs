using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnable;
    [SerializeField] private UnityEvent _onDisable;
    [SerializeField] private float _activeTime;
    private readonly Timer _timer = new Timer();

    public void Enable()
    {
        _timer.StartTimer(_activeTime, Disable);
        _onEnable?.Invoke();
    }

    public void Disable() => _onDisable?.Invoke();

    private void Update() => _timer.UpdateTimer();
}