using UnityEngine;
using Random = UnityEngine.Random;

public class RandomActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    private GameObject _currentObject;

    private void Start()
    {
        if (_gameObjects.Length == 0) return;
        ActiveObject();
    }

    public void ActiveObject()
    {
        if (_currentObject != null) _currentObject.SetActive(false);
        _currentObject = _gameObjects[Random.Range(0, _gameObjects.Length)];
        _currentObject.SetActive(true);
    }
}