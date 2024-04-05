using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSword : MonoBehaviour
{
    public float rotateSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + rotateSpeed * Time.deltaTime);
    }
}
