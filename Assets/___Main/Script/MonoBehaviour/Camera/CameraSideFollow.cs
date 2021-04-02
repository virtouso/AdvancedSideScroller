using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraSideFollow : MonoBehaviour
{

    public void ChangeCameraMode(CameraModes cameraMode)
    {
        switch (cameraMode)
        {
            case CameraModes.PlayerShooting:
                _currentMode = FollowPlayerInShooterMode;
                break;
            case CameraModes.PlayerClimb:
                _currentMode = FollowPlayerInClimbMode;
                break;
        }
    }







    [Inject] private PlayerSharedComponent _playerController;
    [SerializeField] private Vector3 _shooterModeOffset;
    [SerializeField] private float _climbModeDistance;
    [SerializeField] private float _lerpSpeed;


    private System.Action _currentMode;

    private void Update()
    {
        _currentMode?.Invoke();
    }





    private void FollowPlayerInShooterMode()
    { if (_playerController == null) return;
        transform.position = Vector3.MoveTowards(transform.position, _playerController.transform.position + _shooterModeOffset, _lerpSpeed);
        transform.LookAt(_playerController.transform.position);
    }

    private void FollowPlayerInClimbMode()
    {
        if (_playerController == null) return;

        transform.position = Vector3.MoveTowards(transform.position,
            _playerController.transform.position + _playerController.transform.forward * _climbModeDistance,
            _lerpSpeed);

        transform.LookAt(_playerController.transform.position);
    }


}

public  enum CameraModes {PlayerShooting, PlayerClimb }

