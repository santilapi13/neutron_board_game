using TMPro;
using UnityEngine;

public class LoadTranslation_TMP : MonoBehaviour {
    public string textInKeyLanguage; // Spanish default
    public TextMeshProUGUI textComp;
    
    // Start is called before the first frame update
    void Start() {
        LoadTranslation(GameControl.GameLanguage);
    }

    void LoadTranslation(int lang) {
        textComp.text = LanguageManager.GetTextInLanguage(textInKeyLanguage, lang);
    }
    
    void OnEnable(){
        LoadTranslation_Button.ChangeLanguage += LoadTranslation;
    }
    
    void OnDisable(){
        LoadTranslation_Button.ChangeLanguage -= LoadTranslation;
    }

    public void SetTextInKeyLanguage(string text) {
        textInKeyLanguage = text;
        LoadTranslation(GameControl.GameLanguage);
    }
    
}
