using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger

}
public class Enemy : MonoBehaviour
{
    // Enemy Class
    public EnemyState currentState;
    public float maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public HealthBar healthBar;
    private void Awake()
    {
        health = maxHealth;
        healthBar.SetHealth(health, maxHealth);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
        if(health <= 0)
        {
            IsDead();
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {   
        //StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    public bool IsDead(){
        return health <= 0;
    }
}
