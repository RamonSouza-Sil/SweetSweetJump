using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Adicionado para usar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalToCollect = 11;
    private int collected = 0;

    public TextMeshProUGUI collectText;

    void Awake()
    {
        Instance = this;
        // Tiramos o DontDestroyOnLoad!
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
            SceneManager.LoadScene("Vitoria");
        }
    }

    void UpdateCollectText()
    {
        if (collectText != null)
        {
            collectText.text = "Doces Coletados: " + collected + "/" + totalToCollect;
        }
    }
}
