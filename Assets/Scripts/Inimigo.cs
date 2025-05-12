using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float distancia = 5f;        
    public float velocidade = 2f;       
    public int dano = 1;                

    private Vector3 pontoInicial;
    private Vector3 destino;
    private bool indo = true;

    PlayerVida PlayerVida;
    void Start() //rota
    {
        pontoInicial = transform.position;
        destino = pontoInicial + transform.forward * distancia;
    }

    void Update()
    {
        Vector3 alvo = indo ? destino : pontoInicial;
        Vector3 direcao = (alvo - transform.position).normalized;

        
        transform.position += direcao * velocidade * Time.deltaTime;

        
        if (direcao != Vector3.zero)
        {
            transform.forward = direcao;
        }

        
        if (Vector3.Distance(transform.position, alvo) < 0.1f)
        {
            indo = !indo;
        }
    }

    void OnTriggerEnter(Collider other) //detecção de colisão
    {
        Debug.Log("Colidiu com: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("É o jogador!");
            PlayerVida health = other.GetComponent<PlayerVida>();
            if (health != null)
            {
                health.TakeDamage();
            }
        }
    }
}