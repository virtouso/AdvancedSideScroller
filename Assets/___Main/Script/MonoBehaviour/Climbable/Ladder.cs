using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Climbable
{
    [SerializeField] public Transform RightSide;
    [SerializeField] public Transform LeftSide;
    [SerializeField] public List<Transform> Rungs;
    [SerializeField] public Transform LadderEnding;
    [SerializeField] public Transform LadderStart;

}
