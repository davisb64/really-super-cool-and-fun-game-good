using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform chase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            pivot.position = target.position;
            pivot.rotation = target.rotation;
            transform.position = chase.position;
            transform.LookAt(target.position);
        }
    }
}
