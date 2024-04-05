using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;
    public float growSpeed = 0.5f;
    public float downSpeed = 0.1f;
    Vector3 targetSize;
    bool theChangeTrigger = true;
    public bool shouldKnockBack;
    Collider2D collider2;

    private void Start()
    {
        targetSize = transform.localScale;
        collider2 = GetComponent<Collider2D>();
    }
    private void Update()
    {
        
        if(theChangeTrigger )
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
            if (transform.localScale.x >= targetSize.x)
            {
                theChangeTrigger = false;
            }
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, downSpeed * Time.deltaTime);
            if (transform.localScale.x <= 0f)
            {
                theChangeTrigger = true;
            }
        }
        if(transform.localScale.x>0.45f)
        {
            collider2.enabled = true;
        }
        else
        {
            collider2.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Damage(damageAmount, shouldKnockBack);
        }
    }
}
