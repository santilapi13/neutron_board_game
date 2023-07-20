using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTranslation_Button : MonoBehaviour {
    public string textInKeyLanguage = "Cambiar idioma";
    private string buttonText;
    public Button button;
     
    void Start() {
        button.onClick.AddListener(TaskOnClick);
        buttonText = textInKeyLanguage;
        LoadTranslation(GameControl.GameLanguage);
    }
     
    void LoadTranslation(int lang){
        buttonText = LanguageManager.GetTextInLanguage(textInKeyLanguage, lang);
    }
    
    public delegate void ChangeLanguageDelegate(int lang);
    public static ChangeLanguageDelegate ChangeLanguage;

    private void TaskOnClick() {
        GameControl.GameLanguage = GameControl.GameLanguage == 1 ? 0 : 1;
        if (ChangeLanguage != null) {
            ChangeLanguage(GameControl.GameLanguage);
        }
    }

    void OnEnable() {
        ChangeLanguage += LoadTranslation;
    }
    
    void OnDisable(){
        ChangeLanguage -= LoadTranslation;
    }
    
}
