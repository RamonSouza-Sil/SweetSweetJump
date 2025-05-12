using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChamaCenaJogo : MonoBehaviour
{
    public string gameSceneName = "Game"; // Altere para o nome da sua cena principal

    [SerializeField] private GameObject scenerLoadUI;
    [SerializeField] private GameObject texto;
    [SerializeField] private GameObject texto2;
    [SerializeField] private Slider loadingBar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CarregarCenaAssincrona());
        }
    }

    // Corotita para carregar a proxima cena para não haver delays
    IEnumerator CarregarCenaAssincrona()
    {
        //ativando ui de loading
        if (scenerLoadUI != null)
        {
            scenerLoadUI.SetActive(true);
        }

        // esconde o texto "pressione espaço"
        if (texto != null)
        {
            texto.SetActive(false);
            texto2.SetActive(true);
        }

        // Começa a carregar a cena de forma assíncrona
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameSceneName);
        asyncLoad.allowSceneActivation = false;

        while(asyncLoad.progress < 0.9f)
        {
            if(loadingBar != null)
            {
                loadingBar.value = asyncLoad.progress;

            }
            yield return null;
        }

        if (loadingBar != null)
        {
            loadingBar.value = 1f;
        }

        // Aguarda um pouco antes de ativar a nova cena 
        yield return new WaitForSeconds(0.5f);

        asyncLoad.allowSceneActivation = true;
    }
}
