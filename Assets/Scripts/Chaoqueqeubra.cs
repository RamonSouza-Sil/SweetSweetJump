using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaoqueqeubra : MonoBehaviour

{
    public float checkRadius = 0.6f;      // Raio de detecção do jogador
    public float checkHeight = 1f;        // Altura onde o jogador seria detectado
    public string playerTag = "Player";   // Tag do jogador

    private bool jogadorSobre = false;

    void Update()
    {
        // Posição no centro da plataforma, levemente acima
        Vector3 checkPosition = transform.position + Vector3.up * checkHeight;

        // Verifica se o jogador ainda está em cima usando uma esfera invisível
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
        // Só para visualização no editor: mostra a área de checagem
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * checkHeight, checkRadius);
    }
}