using UnityEngine;
 
namespace WindEffect
{
  
    public class WindController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        private Vector3 windDirection;
        [SerializeField] private float windChangeInterval = 2.0f;
        [SerializeField] private float windForce = 10.0f;
        private bool isInWindBlock = false;
 
        private void Start()
        {
            ChangeWindDirection();
            StartCoroutine(ChangeWindDirectionCoroutine());
        }
        private System.Collections.IEnumerator ChangeWindDirectionCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(windChangeInterval);
                ChangeWindDirection();
            }
        }
        private void ChangeWindDirection()
        {
            float randomAngle = Random.Range(0f, 360f);
            windDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
        }
        private void FixedUpdate()
        {
            if (isInWindBlock)
            {
                ApplyWindForce();
            }
        }
        private void ApplyWindForce()
        {
            characterController.Move(windDirection * windForce*Time.deltaTime);
        }
 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInWindBlock = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isInWindBlock = false;
            }
        }
    }
}