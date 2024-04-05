using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;
    public Transform numberCanvas;
    public DamageNumber numberToSpawn;
    //建立一个对象池
    private List<DamageNumber> damageNumbers = new List<DamageNumber>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDamage(float damageAmount, Vector3 position)
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        DamageNumber newNumber = GetNumberFromPool();
        newNumber.Setup(rounded);
        newNumber.transform.position = position;
        newNumber.gameObject.SetActive(true);
    }

    public DamageNumber GetNumberFromPool()
    {
        DamageNumber newNumberOut = null;
        if (damageNumbers.Count == 0)
        {
            newNumberOut = Instantiate(numberToSpawn,numberCanvas);
        }
        else
        {
            newNumberOut = damageNumbers[0];
            damageNumbers.RemoveAt(0);
        }
        return newNumberOut;
    }

    public void PlaceToPool(DamageNumber newNumberIn)
    {
        newNumberIn.gameObject.SetActive(false);

        damageNumbers.Add(newNumberIn);
    }
}
