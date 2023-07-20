using UnityEngine;
using System.Collections;
using System.IO;

public static class LanguageManager {
    private static Hashtable _textTable;
    private static int _nLanguages;

    public static void LoadLanguagesFile(string filename) {
        /* 1. FILE LOAD */
        TextAsset textFile = (TextAsset) Resources.Load(filename, typeof(TextAsset));
        if (textFile == null){
            Debug.LogWarning("LanguageManager: file '"+ filename +"' not found!.");
            return;
        }
     
        /* 2. FILE PARSING */
        _textTable = new Hashtable(); 
        StringReader reader = new StringReader(textFile.text);
     
        string line= reader.ReadLine(); // number of languages = first line in the file
        _nLanguages =  int.Parse(line); 
        string key;  
        while (( line= reader.ReadLine()) != null){
            key = line;
            if(_nLanguages==1){
                string val = reader.ReadLine(); 
                _textTable.Add(key,val);
            }
            else{
                string[] val = new string[_nLanguages];
                for(int i=0; i<_nLanguages; i++){
                    line= reader.ReadLine();
                    val[i] = line;
                }
                _textTable.Add(key,val);
            }
        }
        reader.Close();
    }

    public static string GetTextInLanguage(string key, int lang) {
        /* 1. CHECKS THAT THE TABLE ISN'T EMPTY */
        if(_textTable==null) {
            Debug.LogWarning("LanguageManager: Error: languages hashtable is empty!");
            return key; 
        }
        
        /* 2. CHECKS THE EXISTENCE OF THE KEYWORD IN THE TABLE */
        string val = ""; 
        if (_textTable.ContainsKey(key)) {
            if(_nLanguages==1) val = lang==0 ? key:(string)_textTable[key]; 
            else{
                string[] vals = (string[])_textTable[key];
                if(lang<_nLanguages) val = vals[lang];    
            }
        }
        else {
            Debug.LogWarning("LanguageManager: Error: Word '"+ key + "' not found!"); 
            return key;
        }
        return val;
    }
}
