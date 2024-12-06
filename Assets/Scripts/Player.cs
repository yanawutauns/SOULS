using UnityEngine;

public class Player : Character
{

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public bool isAttacking = false;

    
    public override int Damage
    {
        get { return 20; } 
    }

    protected override void Start()
    {
        base.Start();
    }

    
    public void Attack()
    {
        if (isAttacking)
            return;

        isAttacking = true;
        Debug.Log("Player is attacking!");

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Attack");

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Character>()?.TakeDamage(Damage); 
        }

        isAttacking = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Character enemyCharacter = collision.gameObject.GetComponent<Character>();
            if (enemyCharacter != null)
            {

                TakeDamage(enemyCharacter.Damage); 
                Debug.Log("Player hit by enemy! Remaining health: " + Health);
            }

            
            if (Health <= 0)
            {
                Die(); 
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}