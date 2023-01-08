using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    

    private void Start()
    {
        cam = transform;        
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
