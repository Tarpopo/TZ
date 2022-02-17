using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _nextMaterial;
    private MeshRenderer _meshRenderer;

    public void SetMaterial(bool nextMaterial) =>
        _meshRenderer.material = nextMaterial ? _nextMaterial : _startMaterial;

    private void Start() => _meshRenderer = GetComponent<MeshRenderer>();
}