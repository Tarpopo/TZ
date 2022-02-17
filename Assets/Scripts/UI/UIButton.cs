using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent _onButtonDown;
    [SerializeField] private UnityEvent _onButtonUp;
    [SerializeField] private Sprite _onPushSprite;
    [SerializeField] private Sprite _onUpSprite;
    private Image _image;
    private void Start() => _image = GetComponent<Image>();

    public void OnPointerDown(PointerEventData eventData)
    {
        _onButtonDown?.Invoke();
        _image.sprite = _onPushSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _onButtonUp?.Invoke();
        _image.sprite = _onUpSprite;
    }
}