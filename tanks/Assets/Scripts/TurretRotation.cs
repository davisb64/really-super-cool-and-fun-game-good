using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    [SerializeField] private int playerNumber = 1;
    public float rotateSpeed = 120f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rotTurret();
    }

    void rotTurret()
    {
        float rotTur = Input.GetAxis("P" + playerNumber.ToString() + "RightHorizontal");
        Vector3 initRot = new Vector3(0f, rotTur * rotateSpeed * Time.deltaTime, 0f);
        Quaternion finalRot = Quaternion.Euler(initRot);
        rb.MoveRotation(rb.rotation * finalRot);
    }
}
