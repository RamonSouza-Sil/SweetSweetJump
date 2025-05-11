using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doces : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidade de rotação (graus por segundo)
    public float floatAmplitude = 0.5f; // Altura máxima da flutuação
    public float floatFrequency = 1f;   // Velocidade da flutuação

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotação contínua
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Flutuação suave (movimento senoidal)
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectItem(); // Informa ao GameManager
            Destroy(gameObject); // Destroi o coletável

        }
    }
}
