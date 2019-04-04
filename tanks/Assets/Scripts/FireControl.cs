using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public int playerNumber = 1;
    public GameObject bulletParticles;
    public GameObject fireworkParticles;
    public GameObject firePoint;
    public Transform barrelRotation;
    private bool canFire = true;
    private float timeToFire = 0f;
    public float timeDestroy = 10f;
    private AudioSource audioPlayer;
    public AudioClip shot;
    public float count = 0f;
    public float health = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            count -= Time.deltaTime;
            fireWorks();
        }
        else
        {
            fireBullets();
        }
    }

    private void fireBullets()
    {
        float fireButton = Input.GetAxis("P" + playerNumber.ToString() + "Fire");
        if (fireButton > .5f && canFire)
        {
            shooty();
            soundy(shot);
        }
        CheckFireRate();
    }

    private void fireWorks()
    {
        float fireButton = Input.GetAxis("P" + playerNumber.ToString() + "Fire");
        if (fireButton > .5f && canFire)
        {
            blasty();
            soundy(shot);
        }
        CheckFireWorkRate();
    }

    public void soundy(AudioClip clippy)
    {
        audioPlayer.clip = clippy;
        audioPlayer.Play();
    }

    private void CheckFireRate()
    {
        if (!canFire)
        {
            if (timeToFire > bulletParticles.GetComponent<bulletMove>().fireRate)
            {
                canFire = true;
            }
            else
            {
                timeToFire += Time.deltaTime;
            }
        }
    }

    private void CheckFireWorkRate()
    {
        if (!canFire)
        {
            if (timeToFire > fireworkParticles.GetComponent<fireworkMove>().fireRate)
            {
                canFire = true;
            }
            else
            {
                timeToFire += Time.deltaTime;
            }
        }
    }

    

    private void shooty()
    {
        GameObject myParticle;
        myParticle = Instantiate(bulletParticles, firePoint.transform.position, barrelRotation.rotation * Quaternion.Euler(0, -90, 0));
        canFire = false;
        timeToFire = 0f;
        myParticle.GetComponent<bulletMove>().mmmmmmmyParent = this.gameObject;
        Destroy(myParticle, myParticle.GetComponent<bulletMove>().bulletLife);
    }

    private void blasty()
    {
        GameObject myFirework;
        myFirework = Instantiate(fireworkParticles, firePoint.transform.position, barrelRotation.rotation * Quaternion.Euler(0, -90, 0));
        canFire = false;
        timeToFire = 0f;
        myFirework.GetComponent<fireworkMove>().mmmmmmmyParent = this.gameObject;
        Destroy(myFirework, myFirework.GetComponent<fireworkMove>().blastLife);
    }
}
