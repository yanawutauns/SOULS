using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 5f; 
    private bool facingRight = true; 

    private Rigidbody2D r2d; 
    private Animator anim; 

    public Player player; 

    void Start()
    {
        
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>(); 

        if (r2d == null) Debug.LogError("Rigidbody2D is missing from the player!");
        if (anim == null) Debug.LogError("Animator is missing from the player!");
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));

        r2d.linearVelocity = new Vector2(move * maxSpeed, r2d.linearVelocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0) && !player.isAttacking) 
        {
            player.Attack(); 
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}