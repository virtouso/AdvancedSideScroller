using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private float _decisionRate;
    [SerializeField] private List<BotFunctionBase> _functions;
    [HideInInspector] private BotFunctionBase _currentFunction;
    [SerializeField] private DroneConfiguration _droneConfiguration;
    [HideInInspector] private DroneEnvironmentKnowledge _knowledge;
    [SerializeField] private Transform _muzzle;
    private void InitKnowledge()
    {
        _knowledge = new DroneEnvironmentKnowledge(this.transform, this._muzzle, new List<EnemyControllerBase>(), null, _droneConfiguration);
    }


    private IEnumerator UpdateCurrentFunction()
    {

        BotFunctionBase bestFunction = null;
        int bestScore = int.MinValue;
        while (true)
        {
            yield return new WaitForSeconds(_decisionRate);
            foreach (var item in _functions)
            {
                int functionScore = item.CalculateScore(_knowledge);
                if (functionScore > bestScore)
                {
                    bestFunction = item;
                    bestScore = functionScore;
                }
            }
            print(bestFunction.GetType());
            _currentFunction = bestFunction;
        }
    }

    #region Unity Callbacks

    private void Start()
    {
        InitKnowledge();
        StartCoroutine(UpdateCurrentFunction());
    }

    private void Update()
    {
        _currentFunction?.Execute(_knowledge);
    }

    #endregion






}
