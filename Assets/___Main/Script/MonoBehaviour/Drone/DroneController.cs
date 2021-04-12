using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DroneController : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _decisionRate;
    [SerializeField] private List<BotFunctionBase> _functions;
    [HideInInspector] private BotFunctionBase _currentFunction;
    [SerializeField] private DroneConfiguration _droneConfiguration;
    [HideInInspector] private DroneEnvironmentKnowledge _knowledge;
    [Inject] public PoolManager PoolManager;
    //  [SerializeField] private Transform _muzzle;

    public void Init()
    {

        InitKnowledge();
        StartCoroutine(UpdateCurrentFunction());
        StartCoroutine(Deactivate(_lifeTime));
    }

    private void InitKnowledge()
    {
        _knowledge = new DroneEnvironmentKnowledge(this.transform, new List<EnemyControllerBase>(), null, _droneConfiguration);
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
                if (functionScore >= bestScore)
                {
                    bestFunction = item;
                    bestScore = functionScore;
                }
            }
            print("best function is::::" + bestFunction.GetType());
            _currentFunction = bestFunction;
        }
    }




    #region Unity Callbacks

    private void Start()
    {
        StartCoroutine(Deactivate(0.1f));
    }


    private IEnumerator Deactivate(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }


    private void Update()
    {

        _currentFunction?.Execute(_knowledge);
    }

    #endregion






}
