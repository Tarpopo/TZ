using UnityEngine;
using Random = UnityEngine.Random;

public class RandPoseSetter : MonoBehaviour
{
    [SerializeField] private Vector3[] _positions;

    private void OnEnable()
    {
        if (_positions.Length == 0) return;
        transform.localPosition = _positions[Random.Range(0, _positions.Length)];
    }
}