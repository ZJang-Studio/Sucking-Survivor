using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<PlayerControl>().transform;
        target = PlayerControl.instance.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);   
    }
}
