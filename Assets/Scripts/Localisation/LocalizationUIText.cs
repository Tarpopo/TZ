using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationUIText : MonoBehaviour
{
    public string key;
    private void Start() => GetComponent<Text>().text = Localization.Instance.GetText(key);
}