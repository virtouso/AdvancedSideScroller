using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimIkHandler : MonoBehaviour
{

    [SerializeField] private Animator _characterAnimator;

    private float _aimingWeight;
    private Vector3 _aimingPosition;


    public void UpdateValues(float aimingWeight, Vector3 aimingPosition)
    {
        this._aimingWeight = aimingWeight;
        this._aimingPosition = aimingPosition;
    }




    private void OnAnimatorIK(int layerIndex)
    {
        if (layerIndex != 2) return;


        _characterAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, _aimingWeight);

        Vector3 rightShoulderPosition = _characterAnimator.GetBoneTransform(HumanBodyBones.RightShoulder).position + transform.right * 0.5f;
        Vector3 finalPosition = new Vector3(rightShoulderPosition.x, _aimingPosition.y, _aimingPosition.z);

        _characterAnimator.SetIKPosition(AvatarIKGoal.RightHand, finalPosition);


    }
}
