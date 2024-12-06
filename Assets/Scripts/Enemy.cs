using UnityEngine;

public class Enemy : Character
{

    public override int Damage
    {
        get { return 100; } 
    }

    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);  

        if (health <= 0)
        {
            Die();  
        }
    }

    
    public override void Die()
    {
        base.Die();  
        Debug.Log("Enemy has died."); 
    }
}


