using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMover : MonoBehaviour
{
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _startDelay;
    [SerializeField] private float _moveSpeed;
    private NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.speed = _moveSpeed;
        Invoke(nameof(StartMove), _startDelay);
    }

    public void ResetPosition()
    {
        EndMove();
        _navMesh.enabled = false;
        transform.position = _startPoint.position;
        _navMesh.enabled = true;
        Invoke(nameof(StartMove), _startDelay);
    }

    public void StartMove() => _navMesh.SetDestination(_finishPoint.position);
    public void EndMove() => _navMesh.ResetPath();
}