using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager {
    public static void LoadScene(string sceneName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
