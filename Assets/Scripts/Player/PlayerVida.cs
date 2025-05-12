using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 1.5f;

    public VidaUI lifeUI; // Referência ao HUD


    private Renderer[] renderers;

    void Start()
    {
        currentLives = maxLives;
        renderers = GetComponentsInChildren<Renderer>();
        lifeUI.UpdateHearts(currentLives);
    }

    public void TakeDamage()
    {
        Debug.Log("Dano");
        if (isInvulnerable) return;

        currentLives--;
        
        lifeUI.UpdateHearts(currentLives);

        if (currentLives <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(Invulnerability());
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float elapsed = 0f;
        while (elapsed < invulnerabilityDuration)
        {
            SetRenderersVisible(false);
            yield return new WaitForSeconds(0.1f);
            SetRenderersVisible(true);
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }

        isInvulnerable = false;
    }

    private void SetRenderersVisible(bool visible)
    {
        foreach (var r in renderers)
        {
            r.enabled = visible;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("Derrota");
    }
}
