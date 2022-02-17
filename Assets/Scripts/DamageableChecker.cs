using UnityEngine;

public class DamageableChecker : MonoBehaviour
{
    [SerializeField] private int _damage;
    private IDamageable _damageable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _damageable) == false) return;
        _damageable.TakeDamage(_damage);
    }

    private void OnTriggerStay(Collider other) => _damageable?.TakeDamage(_damage);

    private void OnTriggerExit(Collider other) => _damageable = null;
}