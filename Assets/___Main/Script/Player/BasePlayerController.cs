using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class BasePlayerController : MonoBehaviour
{
    
    [SerializeField] protected CharacterController _controller;

    [SerializeField] private float _rotationSpeed;



 



  

    public void x(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
       print("pressed");
    }

    protected virtual void Update()
    {
        ApplyPlayerGravity();
        ApplyPlayerRotation();
    }

    private float _gravity;
    private void ApplyPlayerGravity()
    {
        _gravity = Physics.gravity.y * Time.deltaTime;
        _controller.Move(new Vector3(0, _gravity, 0));
        if (_controller.isGrounded) _gravity = 0;
    }



    private void ApplyPlayerRotation()
    {
      //  var keyboard = Keyboard.current;


     
        //Vector2 lookDirection = _controlls.Player.LookDirection.ReadValue<Vector2>();
        //print(lookDirection);

        //print(_controlls.Player.Shoot.ReadValue<bool>());

        //   Ray ray = Camera.main.ScreenPointToRay();

        //       transform.rotation = Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(0,goalW,0), _rotationSpeed);
    }

 
}
