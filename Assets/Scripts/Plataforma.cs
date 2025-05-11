using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float amplitude = 2f;       // Altura m�xima do movimento
    public float velocidade = 1f;      // Velocidade de oscila��o

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