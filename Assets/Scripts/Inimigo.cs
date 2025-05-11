using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float distancia = 5f;        // Distância até onde ele vai antes de voltar
    public float velocidade = 2f;       // Velocidade de movimento
    public int dano = 1;                // Dano que ele causa

    private Vector3 pontoInicial;
    private Vector3 destino;
    private bool indo = true;

    void Start()
    {
        pontoInicial = transform.position;
        destino = pontoInicial + transform.forward * distancia;
    }

    void Update()
    {
        Vector3 alvo = indo ? destino : pontoInicial;
        Vector3 direcao = (alvo - transform.position).normalized;

        // Move o inimigo
        transform.position += direcao * velocidade * Time.deltaTime;

        // Vira na direção do movimento
        if (direcao != Vector3.zero)
        {
            transform.forward = direcao;
        }

        // Quando chega perto do destino, inverte o sentido
        if (Vector3.Distance(transform.position, alvo) < 0.1f)
        {
            indo = !indo;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqui você pode chamar algum método de dano do player
            Debug.Log("Player levou dano!");

            // Exemplo: se o player tiver um script com função LevarDano()
            // other.GetComponent<SeuScriptDoPlayer>()?.LevarDano(dano);
        }
    }
}