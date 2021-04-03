using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbStateController : MonoBehaviour
{

    [SerializeField] private PlayerSharedComponent _sharedComponent;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerFootIkHandler _playerFootHandler;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerAimIkHandler _aimHandler;
    [SerializeField] private PlayerFootIkHandler _footHandler;
    [SerializeField] private PlayerLadderIkHandler _ladderHandler;

    [SerializeField] private Vector3 _distanceFromLadder;
    [SerializeField] private float _stateTime;
    [SerializeField] private float _takeOffTime;
    [SerializeField] private float _moveJointSpeed;
    private Ladder _climbingLadder;

    private ClimbLadderState _climbLadderState;
    [SerializeField] public JointPlacingHelper JointPlacing;

    #region initiation



    public void StartClimbUp(Ladder ladder)
    {
        SharedInitiation(ladder);
        JointPlacing = new JointPlacingHelper(1, 0, 2, 0, 2,
            new GameObject("Right Hand Goal").transform,
            new GameObject("Right Foot Goal").transform,
            new GameObject("Body Goal").transform,
            new GameObject("Left Hand Goal").transform,
            new GameObject("left Foot Goal").transform, 1);
        StartCoroutine(Grab());

    }

    public void StartClimbDown(Ladder ladder)
    {
        SharedInitiation(ladder);
        int ladderHighestIndex = ladder.Rungs.Count - 1;
        JointPlacing = new JointPlacingHelper(ladderHighestIndex - 1, ladderHighestIndex - 2, ladderHighestIndex,
            ladderHighestIndex - 2, ladderHighestIndex - 2,
            new GameObject("Right Hand Goal").transform,
            new GameObject("Right Foot Goal").transform,
            new GameObject("Body Goal").transform,
            new GameObject("Left Hand Goal").transform,
            new GameObject("left Foot Goal").transform, 1);
        StartCoroutine(Grab());
    }

    private void SharedInitiation(Ladder ladder)
    {
        print("shared inititation called");
        _climbingLadder = ladder;
        _characterController.enabled = false;
        _aimHandler.enabled = false;
        _footHandler.enabled = false;
        _ladderHandler.enabled = true;



        _animator.SetLayerWeight(0, 0);
        _animator.SetLayerWeight(1, 0);
        _animator.SetLayerWeight(2, 0);
        _animator.SetLayerWeight(3, 0);
        _animator.SetLayerWeight(4, 1);
    }

    #endregion


    #region Finalization

    private void FinishClimbing()
    {
        _animator.SetLayerWeight(0, 1);
        _animator.SetLayerWeight(1, 1);
        _animator.SetLayerWeight(2, 1);
        _animator.SetLayerWeight(3, 1);
        _animator.SetLayerWeight(4, 0);

        _aimHandler.enabled = true;
        _footHandler.enabled = true;
        _ladderHandler.enabled = false;
        _animator.transform.localPosition = new Vector3(0, -1.03f, 0);
        _sharedComponent.PlayerNormalState.enabled = true;
        _sharedComponent.CharacterController.enabled = true;
        _sharedComponent.PlayerClimbState.enabled = false;
    }


    #endregion




    #region climbMechanics

    [SerializeField] private bool _canMove = false;

    private float _input = 0;
    private void GetClimbInput(float input)
    {
        this._input = input;
    }

    private IEnumerator Climb(float input)
    {
        _canMove = false;
        if (input > 0) yield return StartCoroutine(ClimbLerp(true));
        if (input < 0) yield return StartCoroutine(ClimbLerp(false));
    }

    private IEnumerator ClimbLerp(bool up)
    {
        float timer1 = 0;
        float timer2 = 0;
        float timer3 = 0;
        JointPlacingHelper.LadderState climbState = JointPlacing.UpdateIndex(up, _climbingLadder);
        if (climbState != JointPlacingHelper.LadderState.OnLadder)
        {
            StartCoroutine(TakeOff(climbState));
            yield break;
        }


        while (timer1 < _stateTime)
        {
            timer1 += Time.deltaTime;

            yield return new WaitForEndOfFrame();
            JointPlacing.RightHandGoal.position = Vector3.MoveTowards(
                JointPlacing.RightHandGoal.position,
                new Vector3(_climbingLadder.RightSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.RightHandIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.RightHandIndex].position.z),
                _moveJointSpeed);

            JointPlacing.RightFootGoal.position = Vector3.MoveTowards(
                JointPlacing.RightFootGoal.position,
                new Vector3(_climbingLadder.RightSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.RightFootIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.RightFootIndex].position.z),
                _moveJointSpeed);
        }
        while (timer2 < _stateTime)
        {
            timer2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            JointPlacing.BodyGoal.position = Vector3.MoveTowards(
                JointPlacing.BodyGoal.position,
                _climbingLadder.Rungs[JointPlacing.BodyIndex].position +
                ((transform.position.z - _climbingLadder.transform.position.z) /
                 Mathf.Abs((transform.position.z - _climbingLadder.transform.position.z))) * _distanceFromLadder,
                _moveJointSpeed);
        }
        while (timer3 < _stateTime)
        {
            timer3 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            JointPlacing.LeftHandGoal.position = Vector3.MoveTowards(
                JointPlacing.LeftHandGoal.position,
                new Vector3(_climbingLadder.LeftSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.LeftHandIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.LeftHandIndex].position.z),
                _moveJointSpeed);

            JointPlacing.LeftFootGoal.position = Vector3.MoveTowards(
                JointPlacing.LeftFootGoal.position,
                new Vector3(_climbingLadder.LeftSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.LeftFootIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.LeftFootIndex].position.z),
                _moveJointSpeed);
        }




        _canMove = true;
    }

    private void InitHelperPositions()
    {
        JointPlacing.RightHandGoal.position = _animator.GetBoneTransform(HumanBodyBones.RightHand).position;
        JointPlacing.LeftHandGoal.position = _animator.GetBoneTransform(HumanBodyBones.LeftHand).position;
        JointPlacing.BodyGoal.position = transform.position;
        JointPlacing.RightFootGoal.position = _animator.GetBoneTransform(HumanBodyBones.RightFoot).position;
        JointPlacing.LeftFootGoal.position = _animator.GetBoneTransform(HumanBodyBones.LeftFoot).position;
    }

    private IEnumerator Grab()
    {
        InitHelperPositions();
        float timer = 0;
        while (timer < _stateTime)
        {

            timer += Time.deltaTime;
            JointPlacing.RightHandGoal.position = Vector3.MoveTowards(
                JointPlacing.RightHandGoal.position,
                new Vector3(_climbingLadder.RightSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.RightHandIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.RightHandIndex].position.z),
                _moveJointSpeed);

            JointPlacing.RightFootGoal.position = Vector3.MoveTowards(
                JointPlacing.RightFootGoal.position,
                new Vector3(_climbingLadder.RightSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.RightFootIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.RightFootIndex].position.z),
                _moveJointSpeed);
            yield return new WaitForEndOfFrame();


            JointPlacing.BodyGoal.position = Vector3.MoveTowards(
                JointPlacing.BodyGoal.position,
                _climbingLadder.Rungs[JointPlacing.BodyIndex].position +
                (transform.position - _climbingLadder.Rungs[JointPlacing.BodyIndex].position).normalized *
                _distanceFromLadder.z,
                _moveJointSpeed);


            timer += Time.deltaTime;
            JointPlacing.LeftHandGoal.position = Vector3.MoveTowards(
                JointPlacing.LeftHandGoal.position,
                new Vector3(_climbingLadder.LeftSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.LeftHandIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.LeftHandIndex].position.z),
                _moveJointSpeed);

            JointPlacing.LeftFootGoal.position = Vector3.MoveTowards(
                JointPlacing.LeftFootGoal.position,
                new Vector3(_climbingLadder.LeftSide.position.x,
                    _climbingLadder.Rungs[JointPlacing.LeftFootIndex].position.y,
                    _climbingLadder.Rungs[JointPlacing.LeftFootIndex].position.z),
                _moveJointSpeed);

        }

        _canMove = true;
    }


    private IEnumerator TakeOff(JointPlacingHelper.LadderState ladderState)
    {
        Transform goalTransform = null;
        print("take off called::::" + ladderState.ToString());
        switch (ladderState)
        {
            case JointPlacingHelper.LadderState.DownLadder:
                goalTransform = _climbingLadder.LadderStart;
                break;
            case JointPlacingHelper.LadderState.UpLadder:
                goalTransform = _climbingLadder.LadderEnding;
                break;

        }

        float timer = 0;

        while (timer < _takeOffTime)
        {
            timer += Time.deltaTime;
            JointPlacing.BodyGoal.position = Vector3.MoveTowards(JointPlacing.BodyGoal.position, goalTransform.position, _moveJointSpeed);

            JointPlacing.IkWeight = Mathf.Lerp(JointPlacing.IkWeight, 0, 0.05f);
            print("moving to ladder ending position");
            yield return new WaitForEndOfFrame();
        }
        FinishClimbing();

    }

    #endregion

    #region unity callbacks

    private void Start()
    {
        _sharedComponent.ControllerSettings.VerticalMoveControl.Action += GetClimbInput;
    }

    private void Update()
    {

        if (!_canMove) return;

        StartCoroutine(Climb(_input));
    }

    #endregion

    #region Utility

    #endregion
}

[System.Serializable]
public class JointPlacingHelper
{
    public enum LadderState { OnLadder, DownLadder, UpLadder }
    public JointPlacingHelper(int bodyIndex, int rightFootIndex, int rightHandIndex, int leftFootIndex, int leftHandIndex, Transform rightHandGoal, Transform rightFootGoal, Transform bodyGoal, Transform leftHandGoal, Transform leftFootGoal, float ikWeight)
    {
        BodyIndex = bodyIndex;
        RightFootIndex = rightFootIndex;
        RightHandIndex = rightHandIndex;
        LeftFootIndex = leftFootIndex;
        LeftHandIndex = leftHandIndex;
        RightHandGoal = rightHandGoal;
        RightFootGoal = rightFootGoal;
        BodyGoal = bodyGoal;
        LeftHandGoal = leftHandGoal;
        LeftFootGoal = leftFootGoal;
        IkWeight = ikWeight;
    }


    public LadderState UpdateIndex(bool up, Ladder ladder)
    {
        if (up)
            if (RightHandIndex >= ladder.Rungs.Count - 1 || LeftHandIndex >= ladder.Rungs.Count - 1)
                return LadderState.UpLadder;

        if (!up)
            if (RightFootIndex <= 0 || LeftFootIndex <= 0)
                return LadderState.DownLadder;

        if (up)
        {
            Debug.Log("up called");
            BodyIndex += 1;
            RightFootIndex += 1;
            RightHandIndex += 1;
            LeftFootIndex += 1;
            LeftHandIndex += 1;
            return LadderState.OnLadder;
        }


        BodyIndex -= 1;
        RightFootIndex -= 1;
        RightHandIndex -= 1;
        LeftFootIndex -= 1;
        LeftHandIndex -= 1;
        return LadderState.OnLadder;

    }

    public LadderState UpdateRightIndex(bool up, Ladder ladder)
    {
        if (up)
            if (RightHandIndex >= ladder.Rungs.Count - 1)
                return LadderState.UpLadder;

        if (!up)
            if (RightFootIndex <= 0)
                return LadderState.DownLadder;

        if (up)
        {

            RightFootIndex += 1;
            RightHandIndex += 1;

            return LadderState.OnLadder;
        }
        RightFootIndex -= 1;
        RightHandIndex -= 1;
        return LadderState.OnLadder;
    }

    public LadderState UpdateLeftIndex(bool up, Ladder ladder)
    {
        if (up)
            if (LeftHandIndex >= ladder.Rungs.Count - 1)
                return LadderState.UpLadder;

        if (!up)
            if (LeftFootIndex <= 0)
                return LadderState.DownLadder;

        if (up)
        {

            LeftFootIndex += 1;
            LeftHandIndex += 1;
            return LadderState.OnLadder;
        }

        LeftFootIndex -= 1;
        LeftHandIndex -= 1;
        return LadderState.OnLadder;
    }

    public LadderState UpdateBodyIndex(bool up, Ladder ladder)
    {
        if (up)
            if (BodyIndex >= ladder.Rungs.Count - 1)
                return LadderState.UpLadder;

        if (!up)
            if (BodyIndex <= 0)
                return LadderState.DownLadder;

        if (up)
        {
            BodyIndex += 1;
            return LadderState.OnLadder;
        }
        BodyIndex -= 1;
        return LadderState.OnLadder;
    }

    public int BodyIndex;
    public int RightFootIndex;
    public int RightHandIndex;
    public int LeftFootIndex;
    public int LeftHandIndex;


    public Transform RightHandGoal;
    public Transform RightFootGoal;
    public Transform BodyGoal;
    public Transform LeftHandGoal;
    public Transform LeftFootGoal;
    public float IkWeight;
}
enum ClimbLadderState
{
    MoveBody = (byte)0,
    MoveRight = (byte)1,
    MoveLeft = (byte)2,
    Grab = (byte)3,
    TakeOff = (byte)4
}