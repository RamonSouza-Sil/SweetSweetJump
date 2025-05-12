using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboqueGira : MonoBehaviour
{
    public float rotationSpeed = 45f;  //velocidade

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);  
    }
}

