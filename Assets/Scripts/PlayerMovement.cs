using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{

    walk,
    attack,
    interact,
    stagger,
    idle
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
}

public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
<<<<<<< Updated upstream
    private Rigidbody2D myRigidbody;
=======
    private Rigidbody2D myRigidBody;
>>>>>>> Stashed changes
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
<<<<<<< Updated upstream
        myRigidbody = GetComponent<Rigidbody2D>();
=======
        myRigidBody = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {

        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }

    void UpdateAnimationAndMove()
    {

        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

    }

    void MoveCharacter()
    {
        change.Normalize();
<<<<<<< Updated upstream
        myRigidbody.MovePosition(
=======
        myRigidBody.MovePosition(
>>>>>>> Stashed changes
            transform.position + change * speed * Time.deltaTime
            );

    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }
<<<<<<< Updated upstream
    private IEnumerator KnockCo( float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    Vector3 Add(Vector3 a, Vector3 b)
    {
        return a + b;
    }
=======

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }
>>>>>>> Stashed changes
}
