using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamaCenaJogo : MonoBehaviour
{
    public string gameSceneName = "Game"; // Altere para o nome da sua cena principal

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
