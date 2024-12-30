using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving : MonoBehaviour
{
    [SerializeField] protected float movementspeed = 6;
   
    protected Vector3 movementVector;
    protected void Update() 
   {
       movementVector = (transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward).normalized;
   }
}

