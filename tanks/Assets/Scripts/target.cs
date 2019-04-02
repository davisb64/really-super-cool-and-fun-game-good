using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class target : MonoBehaviour
{

    public float health = 50f;
    public GameObject brokenWall;
    public float explForce = 15f;
    private int playerNumber = 0;

    public void Start()
    {
        playerNumber = this.GetComponent<FireControl>().playerNumber;
    }

    public void TakeDmg (float dmgAmt)
    {
        health -= dmgAmt;
        Debug.Log("Health: " + health.ToString());
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (this.gameObject.tag == "breakablewall")
        {
            BoxCollider bc = gameObject.GetComponent<BoxCollider>();
            bc.enabled = false;
            Vector3 wallOffset = new Vector3(0f, -.5f, 0f);
            GameObject BrokenWallParent = Instantiate(brokenWall, this.transform.position + wallOffset, this.transform.rotation);
            Rigidbody[] rbs = BrokenWallParent.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbs)
            {
                Vector3 randForce = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
                rb.AddForce(randForce * explForce, ForceMode.Impulse);
            }
            Destroy(BrokenWallParent, 2f);
        }
        else if(this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(playerNumber + 3);
        }
        Destroy(this.gameObject);
    }
}
