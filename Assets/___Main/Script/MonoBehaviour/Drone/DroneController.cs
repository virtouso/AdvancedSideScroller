using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private float DecisionRate;
    [SerializeField] private List<BotFunctionBase> _functions;
    [SerializeField] private DroneEnvironmentKnowledge _knowledge;


}
