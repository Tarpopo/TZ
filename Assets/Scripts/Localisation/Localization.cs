using System.Collections.Generic;
using System.Xml.Linq;
using DefaultNamespace;
using UnityEngine;


public class Localization : Singleton<Localization>
{
    [SerializeField] private int _currentLanguageID;
    [SerializeField] private List<TextAsset> _languageFiles = new List<TextAsset>();
    private List<Language> _languages = new List<Language>();


    private void Awake()
    {
        _currentLanguageID = Random.Range(0, 2);
        foreach (TextAsset languageFile in _languageFiles)
        {
            XDocument languageXMLData = XDocument.Parse(languageFile.text);
            Language language = new Language
            {
                languageID = System.Int32.Parse(languageXMLData.Element("Language").Attribute("ID").Value),
                languageString = languageXMLData.Element("Language").Attribute("LANG").Value
            };
            foreach (XElement textx in languageXMLData.Element("Language").Elements())
            {
                TextKeyValue textKeyValue = new TextKeyValue {key = textx.Attribute("key").Value, value = textx.Value};
                language.textKeyValueList.Add(textKeyValue);
            }

            _languages.Add(language);
        }
    }

    public string GetText(string key)
    {
        foreach (Language language in _languages)
        {
            if (language.languageID == _currentLanguageID)
            {
                foreach (TextKeyValue textKeyValue in language.textKeyValueList)
                {
                    if (textKeyValue.key == key)
                    {
                        return textKeyValue.value;
                    }
                }
            }
        }

        return "Undefined";
    }
}

[System.Serializable]
public class Language
{
    public string languageString;
    public int languageID;
    public List<TextKeyValue> textKeyValueList = new List<TextKeyValue>();
}

[System.Serializable]
public class TextKeyValue
{
    public string key;
    public string value;
}