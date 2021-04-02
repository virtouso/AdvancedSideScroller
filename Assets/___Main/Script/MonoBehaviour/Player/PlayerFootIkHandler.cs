using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootIkHandler : MonoBehaviour
{
    [Header("General References")]
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Animator _animator;
    [Header("Settings")]
    [SerializeField] private float _rightFootIkWeight;
    [SerializeField] private float _leftFootIkWeight;
    [SerializeField] private Vector3 _footPlaceOffset;

    [Header("Helper")]
    [SerializeField] private GameObject _rightFoot;
    [SerializeField] private GameObject _leftFoot;

    private FootIkState _footIkState = FootIkState.Apply;


    public void UppdateFootIk(float value, FootIkState footIkState)
    {
        _leftFootIkWeight = value;
        _rightFootIkWeight = value;
        _footIkState = footIkState;
    }



    private void Awake()
    {
        if (_rightFoot == null) _rightFoot = new GameObject("Right Foot");
        if (_leftFoot == null) _leftFoot = new GameObject("Left Foot");
    }

    private void Start() { }


    private void OnAnimatorIK(int layerIndex)
    {
        if (_footIkState == FootIkState.DontApply) return;

        float speed = _animator.GetFloat("speed");

        if (Mathf.Abs(speed) > 0.1f)
        {
            _leftFootIkWeight = 0.3f;
            _rightFootIkWeight = 0.3f;
            return;
        }

        _leftFootIkWeight = 1;
        _rightFootIkWeight = 1;

        Transform rightFootBone = _animator.GetBoneTransform(HumanBodyBones.RightFoot);
        Transform leftFootBone = _animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        Transform hipBone = _animator.GetBoneTransform(HumanBodyBones.Hips);

        RaycastHit rightFootHit;
        RaycastHit leftFootHit;
        RaycastHit hipHit;

        Ray rightRay = new Ray(rightFootBone.position, Vector3.down);
        bool rightFootHasHit = Physics.Raycast(rightRay, out rightFootHit, _groundLayerMask);

        Ray leftRay = new Ray(leftFootBone.position, Vector3.down);
        bool leftFootHasHit = Physics.Raycast(leftRay, out leftFootHit, _groundLayerMask);

        Ray hipRay = new Ray(hipBone.position, Vector3.down);
        bool hipHasHit = Physics.Raycast(hipRay, out hipHit, _groundLayerMask);



        if (rightFootHasHit)
        {
            {
                _rightFoot.transform.position = rightFootHit.point + _footPlaceOffset;
                _rightFoot.transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, rightFootHit.normal), rightFootHit.normal);
            }
        }
        else
        {
            _rightFoot.transform.position = new Vector3(rightFootBone.position.x, hipHit.point.y, rightFootBone.position.z) + _footPlaceOffset;
            _rightFoot.transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, rightFootHit.normal), rightFootHit.normal);
        }



        if (leftFootHasHit)
        {
            {
                _leftFoot.transform.position = leftFootHit.point + _footPlaceOffset;
                _leftFoot.transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, leftFootHit.normal), leftFootHit.normal);
            }

        }
        else
        {
            _leftFoot.transform.position = new Vector3(leftFootBone.position.x, hipHit.point.y, leftFootBone.position.z) + _footPlaceOffset;
            _leftFoot.transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, leftFootHit.normal), leftFootHit.normal);
        }

        _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, _rightFootIkWeight);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, _rightFootIkWeight);
        _animator.SetIKPosition(AvatarIKGoal.RightFoot, _rightFoot.transform.position);
        _animator.SetIKRotation(AvatarIKGoal.RightFoot, _rightFoot.transform.rotation);

        _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, _leftFootIkWeight);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, _leftFootIkWeight);
        _animator.SetIKPosition(AvatarIKGoal.LeftFoot, _leftFoot.transform.position);
        _animator.SetIKRotation(AvatarIKGoal.LeftFoot, _leftFoot.transform.rotation);
    }


}


public enum FootIkState { Apply, DontApply }