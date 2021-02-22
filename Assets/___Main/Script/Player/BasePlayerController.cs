using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class BasePlayerController : MonoBehaviour
{

    [SerializeField] protected CharacterController _controller;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _inputHelperLayerMask;

    #region inputVariables
    private Vector2 _mousePosition;
    private Action<float> _onShootHappen;
    private float _aimInput;
    private float _moveInput;
    #endregion

    protected virtual void Awake()
    {

    }


    protected virtual void Update()
    {
        ApplyPlayerGravity();
        ApplyPlayerRotation();
        ApplyPlayerMove();
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

        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit inputRaycastHit;
        Physics.Raycast(ray, out inputRaycastHit, _inputHelperLayerMask);
        print(inputRaycastHit.point);
        if (inputRaycastHit.point.z > transform.position.z)
            transform.rotation = Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(0, 0, 0), _rotationSpeed);
        else
            transform.rotation = Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(0, 180, 0), _rotationSpeed);
    }

    private void ApplyPlayerMove()
    {
        _controller.Move(new Vector3(0, 0, _moveInput * _moveSpeed));
    }



    #region Input Callbacks


    public void OnShoot(InputValue input)
    {
        _onShootHappen?.Invoke(input.Get<float>());
    }

    public void OnAim(InputValue input)
    {

        _aimInput = input.Get<float>();
    }

    public void OnLookDirection(InputValue input)
    {
        //print(input.Get<Vector2>());
        _mousePosition = input.Get<Vector2>();
    }

    public void OnMove(InputValue input)
    {
        //print(input.Get<float>());
        _moveInput = input.Get<float>();
    }




    #endregion

}
