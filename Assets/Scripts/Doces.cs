using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doces : MonoBehaviour
{
    public float rotationSpeed = 30f; 
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1f;   

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z); //movimentaçao dos doces
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectItem(); 
            Destroy(gameObject);  //destruir os doces ao coletar

        }
    }
}
