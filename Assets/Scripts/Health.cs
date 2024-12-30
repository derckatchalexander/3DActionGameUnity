using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    
    public Slider healthSlider;
   
     public void TakeDamage( int damage)
    {
        health -= damage;
        healthSlider.value = health;
     
        if (health <= 0 )
        {
            Die();
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
             Die();
        }
          if (other.CompareTag("Finish"))
         {
          GameManager.instance.Win();
         }
    }
     private void Die()
    {
        Destroy(gameObject);
        GameManager.instance.Lose();
    }
}
