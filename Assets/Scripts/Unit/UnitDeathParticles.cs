using System;
using UnityEngine;

public class UnitDeathParticles : MonoBehaviour
{
    [SerializeField] private DeathParticle[] _deathParts;
    [SerializeField] private float _particlesForce;

    public void OnDead() => SpawnParticles();

    private void Start()
    {
        foreach (var part in _deathParts) part.Start();
    }

    public void SpawnParticles()
    {
        foreach (var part in _deathParts) part.AddForce(transform.position, _particlesForce);
    }

    public void ResetParticles()
    {
        foreach (var part in _deathParts) part.ResetPosition();
    }
}

[Serializable]
public class DeathParticle
{
    [SerializeField] private Rigidbody _rigidBody;
    private Vector3 _startPosition;

    public void Start() => _startPosition = _rigidBody.transform.localPosition;

    public void ResetPosition()
    {
        _rigidBody.gameObject.SetActive(false);
        _rigidBody.transform.localPosition = _startPosition;
    }

    public void AddForce(Vector3 startPoint, float force)
    {
        _rigidBody.gameObject.SetActive(true);
        _rigidBody.velocity = (_rigidBody.transform.position - startPoint).normalized * force;
    }
}