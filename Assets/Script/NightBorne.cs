using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : Enemy
{
    private List<Vector3> pathVectorList;
    private Vector3 moveDir;
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    private float nextAttack;
    public bool isFlipped = false;
    private Enemy enemyMain;

    void Awake()
    {
        enemyMain = GetComponent<Enemy>();
    }

    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

    }

    void Update()
    {
        Die();
        switch (currentState)
        {
        default:
        case EnemyState.idle:
            FindTarget();
            break;
        case EnemyState.walk:
            {
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                LookAtPlayer();
                myRigidbody.MovePosition(temp);
                Chase();
            }
            break;
        case EnemyState.attack:
            StartCoroutine(Attack());
            break;
        }
    }

    private void FindTarget()
    {
        float chaseRadius = 2f;
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
        && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            // Player within chase radius
            currentState = EnemyState.walk;
            anim.SetBool("moving", true);
        }
    }
    
    private void Chase()
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRadius){
            currentState = EnemyState.attack;
        }
    }

    private IEnumerator Attack()
    {
        if(Time.time > nextAttack)
        {
            anim.SetBool("moving", false);
            anim.SetBool("Attacking", true);
            yield return null;
            anim.SetBool("Attacking", false);
            float attackRate = 2f;
            nextAttack = Time.time + attackRate;
            yield return new WaitForSeconds(1.3f);
            currentState = EnemyState.walk;
        }
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x < target.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, -180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x > target.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, -180f, 0f);
			isFlipped = true;
		}
	}

    public void Die()
    {
        if(enemyMain.IsDead())
        {
            currentState = EnemyState.stagger;
            anim.Play("Die");
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void SFXDie()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.NightDie);
    }

    public void SFXAttacking()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.NightAttack1);
    }

    public void SFXWalk()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.NightWalk);
    }
}