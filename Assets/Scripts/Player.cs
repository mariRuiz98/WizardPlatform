using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;

    [Header("Jump System")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask jumpableLayer;
    [SerializeField] private Transform feetPoint;
    [SerializeField] private float groundDistance;

    [Header("Attack System")]
    [SerializeField] private float damageAttack;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask attackableLayer;


    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    
        Jump();

        SendAttack();
    }


    private void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * speedMovement, rb.velocity.y);
        if(inputH != 0) // Movement
        {
            anim.SetBool("running", true);
            if (inputH > 0) // Right Movement
            {
                transform.eulerAngles = Vector3.zero; 
            }
            else // Left Movement
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(feetPoint.position, Vector3.down, Color.red, 0.3f);
        return Physics2D.Raycast(feetPoint.position, Vector3.down, groundDistance, jumpableLayer);
    }

    private void SendAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }


    // Animation Event
    private void Attack()
    {
        Collider2D[] collidersTriggered = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, attackableLayer);
        foreach (Collider2D collider in collidersTriggered)
        {
            LifeSystem lifeSystem = collider.GetComponent<LifeSystem>();
            lifeSystem.RecieveDamage(damageAttack);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

}
