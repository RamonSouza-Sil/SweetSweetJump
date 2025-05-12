using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChamaCenaJogo : MonoBehaviour
{
    public string gameSceneName = "Game"; 

    [SerializeField] private GameObject scenerLoadUI;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject texto2;
    [SerializeField] private Slider loadingBar;
    private Coroutine piscarTexto;
    private void Start()
    {
        if (texto != null)
        {
            piscarTexto = StartCoroutine(PiscarTexto());  //animação do texto
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CarregarCenaAssincrona());
        }
    }

    
    IEnumerator CarregarCenaAssincrona()
    {
        
        if (scenerLoadUI != null)
        {
            scenerLoadUI.SetActive(true);
        }

        
        if (texto != null)
        {
            texto.gameObject.SetActive(false);
            texto2.SetActive(true);
        }

        
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

        
        yield return new WaitForSeconds(0.5f);

        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator PiscarTexto()
    {
        Color cor = texto.color;

        while (true)
        {
            while (cor.a > 0f)
            {
                cor.a -= Time.deltaTime * 2f;
                texto.color = cor;
                
                yield return null;
            }

            while (cor.a < 1f)
            {
                cor.a += Time.deltaTime * 2f;
                texto.color = cor;
                yield return null;
            }
        }
    }


}
