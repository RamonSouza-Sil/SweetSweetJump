using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Queda : MonoBehaviour


{
    public float fallLimitY = -10f;
    public string defeatSceneName = "Derrota"; // nome da cena de derrota

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            SceneManager.LoadScene(defeatSceneName);
        }
    }
}