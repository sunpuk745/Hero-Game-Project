using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle,
    die
}
public class Player : MonoBehaviour
{
    public bool isOpen;
    public GameObject ui_Window;
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;  
    private AudioSource footstep;
    
    void Start (){
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        footstep = GetComponent<AudioSource>();
    }

    void Update () {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal")* Time.deltaTime * speed;;
        change.y = Input.GetAxisRaw("Vertical")* Time.deltaTime * speed;;
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo()); 
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle && currentState != PlayerState.die)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.PlayerAttack);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false); 
        yield return new WaitForSeconds(.6f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            TurnCharacter();
            transform.Translate(new Vector3(change.x, change.y));
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving", false);
        }   
    }
    
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

    void TurnCharacter()
    {
        if (change.x > 0)
            transform.localScale = Vector3.one;
        else if (change.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();        
        if(currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }else
        {
            
            animator.Play("die");
            
        }
    }
    private IEnumerator KnockCo(float knockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void Footstep()
    {
        footstep.Play();
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);
        currentHealth.RuntimeValue = currentHealth.RuntimeValue + 12;
    }
}
