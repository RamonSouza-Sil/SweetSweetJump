using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float amplitude = 2f;       // Altura máxima do movimento
    public float velocidade = 1f;      // Velocidade de oscilação

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float deslocamento = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = posicaoInicial + new Vector3(0f, deslocamento, 0f);
    }
}