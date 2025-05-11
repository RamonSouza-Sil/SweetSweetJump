using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doces : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidade de rota��o (graus por segundo)
    public float floatAmplitude = 0.5f; // Altura m�xima da flutua��o
    public float floatFrequency = 1f;   // Velocidade da flutua��o

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rota��o cont�nua
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Flutua��o suave (movimento senoidal)
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectItem(); // Informa ao GameManager
            Destroy(gameObject); // Destroi o colet�vel

        }
    }
}
