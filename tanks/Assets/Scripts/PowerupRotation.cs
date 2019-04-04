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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touching Something");
        if (other.CompareTag("Player"))
        {
            FireControl hit = other.transform.root.GetComponent<FireControl>();
            Debug.Log("It's a powerup");
            hit.count = 5f;
            Destroy(this.gameObject);
        }
    }
}