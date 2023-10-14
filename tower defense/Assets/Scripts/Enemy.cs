// Enemy.cs
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitpoints = 10; // Default hitpoints value, you can adjust this in the inspector

    public void TakeDamage(int damage)
    {
        hitpoints -= damage;

        if(hitpoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Optional: Add any death animations or effects here

        Destroy(gameObject); // Destroy the enemy
    }
}
