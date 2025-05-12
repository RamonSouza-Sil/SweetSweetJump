using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaUI : MonoBehaviour
{
    public Image[] hearts; // arraste os 3 �cones aqui

    public void UpdateHearts(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Ativa os cora��es restantes
            hearts[i].gameObject.SetActive(i < currentLives);
        }
    }
}
