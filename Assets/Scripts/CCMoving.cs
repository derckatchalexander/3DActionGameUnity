using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CCMoving : Moving
{
     private CharacterController characterController;
     private void Start() => characterController = GetComponent<CharacterController>();
     private new void Update()
         {
         base.Update();
         characterController.Move( movementVector * movementspeed * Time.deltaTime );
         }
}