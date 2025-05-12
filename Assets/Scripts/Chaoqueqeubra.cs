using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaoqueqeubra : MonoBehaviour

{
    public float checkRadius = 0.6f;      
    public float checkHeight = 1f;        
    public string playerTag = "Player";   

    private bool jogadorSobre = false;

    void Update()
    {
        
        Vector3 checkPosition = transform.position + Vector3.up * checkHeight;

        
        Collider[] hits = Physics.OverlapSphere(checkPosition, checkRadius);

        bool encontrouJogador = false;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(playerTag)) //checar se o player encostou
            {
                encontrouJogador = true;
                break;
            }
        }

        if (jogadorSobre && !encontrouJogador)
        {
            
            Destroy(gameObject);
        }

        jogadorSobre = encontrouJogador;
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * checkHeight, checkRadius);
    }
}