using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float lifeTime;
    private float lifeTimeCounter;

    public float floatSpeed = 0.5f;
    void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    
    void Update()
    {
        if(lifeTimeCounter > 0)
        {
            lifeTimeCounter -= Time.deltaTime;
            if(lifeTimeCounter <= 0 )
            {
                DamageNumberController.instance.PlaceToPool(this);
            }
        }
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }
    public void Setup(int damageNumber)
    {
        lifeTimeCounter = lifeTime;
        damageText.text = damageNumber.ToString();
    }
}
