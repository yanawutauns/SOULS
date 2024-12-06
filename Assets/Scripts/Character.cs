using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int maxHealth = 100;
    protected int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    
    public abstract int Damage { get; }

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }
}
