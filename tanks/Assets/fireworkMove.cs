using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworkMove : MonoBehaviour
{
    public float fireRate = 1f;
    public float blastSpeed = 10f;
    public float blastLife = 2f;
    public float timeDestroy = .5f;
    public float dmg = 10;
    public AudioClip expl;
    public GameObject smonk;
    public GameObject mmmmmmmyParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveFirework();
    }

    private void MoveFirework()
    {
        if (blastSpeed > 0)
        {
            transform.position += transform.forward * blastSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        target hit = other.gameObject.GetComponent<target>();
        if (other.tag == "Player")
        {
            hit = other.transform.root.GetComponent<target>();
        }
        if (hit != null)
        {
            hit.TakeDmg(dmg);
        }
        CreateSmonk();
        mmmmmmmyParent.GetComponent<FireControl>().soundy(expl);
        Destroy(this.gameObject);
    }

    private void CreateSmonk()
    {
        if (timeDestroy > 0f)
        {
            GameObject newSmonk;
            newSmonk = Instantiate(smonk, this.transform.position, Quaternion.identity);
            Destroy(newSmonk, timeDestroy);
        }
    }
}
