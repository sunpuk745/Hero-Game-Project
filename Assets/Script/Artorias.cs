using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Artorias : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private float nextAttack;
    private float nextAttack2;
    private float nextAttack3;
    private bool isFlipped = false;
    private int typeattack;
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
            typeattack = Random.Range(1, 4);
            if (typeattack == 1){
                anim.SetBool("attack1", true);
                yield return null;
                anim.SetBool("attack1", false);
                float attackRate = 2f;
                nextAttack = Time.time + attackRate;
            }
            if (typeattack == 2){
                anim.SetBool("attack2", true);
                yield return null;
                anim.SetBool("attack2", false);
                float attackRate2 = 2f;
                nextAttack2 = Time.time + attackRate2;
            }
            if (typeattack == 3){
                anim.SetBool("attack3", true);
                yield return null;
                anim.SetBool("attack3", false);
                float attackRate3 = 2f;
                nextAttack2 = Time.time + attackRate3;
            }
            yield return new WaitForSeconds(1.3f);
            currentState = EnemyState.walk;
        }
    }

	private void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > target.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < target.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
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
        SceneManager.LoadScene("Epilogue");
    }

    private void SFXFootstep()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasWalk);
    }

    private void SFXAttacking1()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasAttack1);
    }
    private void SFXAttacking2_1()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasAttack2_1);
    }
    private void SFXAttacking2_2()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasAttack2_2);
    }
    private void SFXAttacking3_1()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasAttack3_1);
    }
    private void SFXAttacking3_2()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasAttack3_2);
    }
    public void SFXDie()
    {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.ArtoriasDie);
    }
}