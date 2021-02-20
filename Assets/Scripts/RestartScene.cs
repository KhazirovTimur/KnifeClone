using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public string sceneToLoad = "GameScene";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
