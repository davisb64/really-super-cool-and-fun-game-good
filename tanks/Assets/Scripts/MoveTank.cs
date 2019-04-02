using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MoveTank : MonoBehaviour
{
    public float moveSpeed = 300f;
    public float rotateSpeed = 60f;
    public float dead = .15f;
    public Rigidbody turretRB;
    public Rigidbody entireRB;
    private AudioSource ap;
    public static bool started1 = false;
    public static bool started2 = false;
    private int currentScene = 0;

    [SerializeField] private int playerNumber = 1;
    [SerializeField] private Text confText;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ap = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        confText.text = "Player " + playerNumber.ToString() + Environment.NewLine + "Press X";
        //started1 = false;
        //started2 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TankMove();
    }

    private void Update()
    {
        if (currentScene == 0)
        {
            startScreen();
            Debug.Log("Started 1: " + started1.ToString());
            Debug.Log("Started 2: " + started2.ToString());
            if (started1 == true && started2 == true)
            {
                SceneManager.LoadScene(currentScene + Random.Range(1, 3));
            }
        }
    }

    private void startScreen()
    {
        bool confirm = Input.GetButtonDown("P" + playerNumber.ToString() + "Confirm");
        if (confirm)
        {
            if (playerNumber == 1)
            {
                started1 = true;
            }
            else
            {
                started2 = true;
            }
            confText.text = "Ready!";
        }
    }

    private void TankMove()
    {
        float hMovement = Input.GetAxis("P" + playerNumber.ToString() + "LeftHorizontal");
        float vMovement = Input.GetAxis("P" + playerNumber.ToString() + "LeftVertical");    
        if(Mathf.Abs(vMovement) > .1f)
        {
            ap.volume = 1f;
        }
        else
        {
            ap.volume = .2f;
        }
        Vector3 movement = new Vector3(vMovement * moveSpeed * Time.deltaTime, 0f, 0f);
        Vector3 initRot = new Vector3(0f, hMovement * rotateSpeed * Time.deltaTime, 0f);
        Quaternion finalRot = Quaternion.Euler(initRot);
        rb.MovePosition(transform.position + transform.TransformDirection(movement));
        rb.MoveRotation(rb.rotation * finalRot);
        turretRB.MovePosition(transform.position + transform.TransformDirection(movement));
        turretRB.MoveRotation(turretRB.rotation * finalRot);
    }
}
