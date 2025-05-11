using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaoqueqeubra : MonoBehaviour

{
    public float checkRadius = 0.6f;      // Raio de detec��o do jogador
    public float checkHeight = 1f;        // Altura onde o jogador seria detectado
    public string playerTag = "Player";   // Tag do jogador

    private bool jogadorSobre = false;

    void Update()
    {
        // Posi��o no centro da plataforma, levemente acima
        Vector3 checkPosition = transform.position + Vector3.up * checkHeight;

        // Verifica se o jogador ainda est� em cima usando uma esfera invis�vel
        Collider[] hits = Physics.OverlapSphere(checkPosition, checkRadius);

        bool encontrouJogador = false;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(playerTag))
            {
                encontrouJogador = true;
                break;
            }
        }

        if (jogadorSobre && !encontrouJogador)
        {
            // O jogador saiu da plataforma -> destruir
            Destroy(gameObject);
        }

        jogadorSobre = encontrouJogador;
    }

    void OnDrawGizmosSelected()
    {
        // S� para visualiza��o no editor: mostra a �rea de checagem
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * checkHeight, checkRadius);
    }
}