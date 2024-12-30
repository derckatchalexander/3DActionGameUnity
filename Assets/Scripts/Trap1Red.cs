using UnityEngine;
[RequireComponent(typeof(MeshCollider))]
public class Trap1Red : MonoBehaviour
{
   
    public static class CustomColors
{
    public static Color Orange = new Color(1.0f, 0.5f, 0.0f);
}
    public Color activeColor = CustomColors.Orange; 
    public Color damageColor = Color.red; 
    private float activationDelay = 1.0f; 
    private float cooldownTime = 5.0f; 
    private int damageAmount = 10;
 
    private bool isActive = false;
    private Renderer blockRenderer; 
 
    private void Start()
    {
        blockRenderer = GetComponent<Renderer>();
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
             StartCoroutine(ActivateTrap());
        }
    }

    private System.Collections.IEnumerator ActivateTrap()
    {
        isActive = true;
        blockRenderer.material.color = activeColor;
 
        yield return new WaitForSeconds(activationDelay);
        DealDamage();
    }
 
    private void DealDamage()
    {
        Collider[] playersOnTrap = Physics.OverlapBox(transform.position, transform.localScale , Quaternion.identity);
 
        foreach (var player in playersOnTrap)
        {
            if (player.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
            }
        }
 
        blockRenderer.material.color = damageColor;
        StartCoroutine(ResetTrapAfterCooldown());
    }
    private System.Collections.IEnumerator ResetTrapAfterCooldown()
{
    yield return new WaitForSeconds(cooldownTime);
    ResetTrap();
}
    private void ResetTrap() 
    {
        isActive = false;
        blockRenderer.material.color = Color.white;  
    }
 
}
 

 