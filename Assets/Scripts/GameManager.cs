using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalToCollect = 11;
    private int collected = 0;

    public TextMeshProUGUI collectText;

    void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {
        UpdateCollectText();
    }

    public void CollectItem()
    {
        collected++;
        UpdateCollectText();

        if (collected >= totalToCollect)
        {
            SceneManager.LoadScene("Vitoria");  //chama cena
        }
    }

    void UpdateCollectText()
    {
        if (collectText != null)
        {
            collectText.text = "Doces Coletados: " + collected + "/" + totalToCollect; //contagem dos doces
        }
    }
}
