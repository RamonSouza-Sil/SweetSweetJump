using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixaquegira : MonoBehaviour
{
    public float rotationSpeed = 45f; // Graus 

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); 
    }
}