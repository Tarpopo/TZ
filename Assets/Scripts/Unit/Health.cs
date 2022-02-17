using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEvent _onDeath;
    [SerializeField] private UnityEvent _onTakeDamage;
    [SerializeField] private UnityEvent _onReset;
    [SerializeField] private int _health;
    [SerializeField] private bool _resetOnEnable;
    [SerializeField] private float _resetDelay;
    private float _currentHealth;
    public bool IsDeath => _currentHealth <= 0;

    public event UnityAction OnDeath
    {
        add => _onDeath.AddListener(value);
        remove => _onDeath.RemoveListener(value);
    }

    public event UnityAction OnTakeDamage
    {
        add => _onTakeDamage.AddListener(value);
        remove => _onTakeDamage.RemoveListener(value);
    }

    public void TakeDamage(int damage) => ReduceHealth(damage);
    public void ResetHealth() => _currentHealth = _health;
    public void DisableDamage() => _currentHealth = 0;

    private void ResetAll()
    {
        ResetHealth();
        _onReset?.Invoke();
    }

    private void ReduceHealth(int value)
    {
        if (IsDeath) return;
        _currentHealth -= value;
        _onDeath?.Invoke();
        Invoke(nameof(ResetAll), _resetDelay);
    }

    private void OnEnable()
    {
        if (_resetOnEnable) ResetHealth();
    }
}