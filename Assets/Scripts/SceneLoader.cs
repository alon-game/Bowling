using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
    [SerializeField] string sceneName;
        public void LoadNewScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
