using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingBallController : MonoBehaviour
{
    public float swingSpeed = 2.0f; 
    public float hitForce = 10.0f; 

    private Vector3 swingDirection; 
    void Start()
    {
        swingDirection = transform.right; 
    }

    void Update()
    {
        transform.RotateAround(transform.position, swingDirection, swingSpeed);
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                hit.gameObject.GetComponent<CharacterController>().Move(hitForce * swingDirection* Time.deltaTime);

            }
        }
    }
}
