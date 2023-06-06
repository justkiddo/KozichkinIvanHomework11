using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace root
{
    public static class StartSceneController 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void onAppLoaded()
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.buildIndex != 0)
                SceneManager.LoadScene(0);
        }
    }
}
