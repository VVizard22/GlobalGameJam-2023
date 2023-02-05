using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ
{
    public class SceneManagement : MonoBehaviour
    {
        string currentSceneName = "";

        public void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            currentSceneName = SceneManager.GetActiveScene().name; 
        }

        public void LoadScene(string sceneName)
        {
            currentSceneName = sceneName;
            SceneManager.LoadScene(sceneName);
        }

        public void ReloadScene() =>
            LoadScene(currentSceneName);

        public void Exit() =>
            Application.Quit();
    }
}
