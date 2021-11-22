using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        var hasPlayer = player != null;
        var thisIsPlayer = this.GetComponentInParent<Player>() != null;

        var enemy = other.GetComponent<Enemy>();
        var hasEnemy = enemy != null;

        if (hasPlayer || hasEnemy)
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    other.GetComponent<Player>().Knock(knockTime, damage);  
                }
            }
        }
    }
}

