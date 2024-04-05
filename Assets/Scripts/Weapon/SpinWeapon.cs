using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;
    public Transform holder, weaponToSpawn;
    public float timeBetweenSpawn = 8f;
    private float spawnCounter;
    bool getNewWeapon = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            getNewWeapon = true;
        }
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + rotateSpeed * Time.deltaTime);
        spawnCounter -=Time.deltaTime;
        if(spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawn;
            if (getNewWeapon)
            {
                Instantiate(weaponToSpawn, weaponToSpawn.position, weaponToSpawn.rotation, holder).gameObject.SetActive(true);
                getNewWeapon = false;
            }
        }
    }
}
