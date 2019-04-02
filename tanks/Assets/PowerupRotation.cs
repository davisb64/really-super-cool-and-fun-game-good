using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRotation : MonoBehaviour
{
    private float rotationSpeed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(rotationSpeed, -2 * rotationSpeed, rotationSpeed);
        transform.Rotate(rotation);
    }
}