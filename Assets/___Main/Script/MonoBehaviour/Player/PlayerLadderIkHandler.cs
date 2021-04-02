using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderIkHandler : MonoBehaviour
{


    [SerializeField] private PlayerClimbStateController _climbPlacing;
    [SerializeField] private Animator _animator;
    private void OnAnimatorIK(int layerIndex)
    {
        SetBodyPositions();
    }




    private void SetBodyPositions()
    {
        if (_climbPlacing.JointPlacing == null) return;


        _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, _climbPlacing.JointPlacing.IkWeight);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, _climbPlacing.JointPlacing.IkWeight);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _climbPlacing.JointPlacing.IkWeight);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _climbPlacing.JointPlacing.IkWeight);

        _animator.SetIKPosition(AvatarIKGoal.RightHand, _climbPlacing.JointPlacing.RightHandGoal.position);
        _animator.SetIKPosition(AvatarIKGoal.RightFoot, _climbPlacing.JointPlacing.RightFootGoal.position);

        transform.parent.position = _climbPlacing.JointPlacing.BodyGoal.position;
        transform.position = _climbPlacing.JointPlacing.BodyGoal.position;


        _animator.SetIKPosition(AvatarIKGoal.LeftHand, _climbPlacing.JointPlacing.LeftHandGoal.position);
        _animator.SetIKPosition(AvatarIKGoal.LeftFoot, _climbPlacing.JointPlacing.LeftFootGoal.position);
    }



    private void Start() { }

    private void Update()
    {
    }

}
