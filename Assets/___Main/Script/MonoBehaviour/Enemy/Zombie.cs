using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Zombie : EnemyControllerBase
{
    public override Vector3 Position => transform.position;
    [SerializeField] public ZombieConfiguration Configuration;
    [SerializeField] public LayerMask DetectionMask;
    [Inject] [HideInInspector] public PlayerController PlayerReference;

    public override void ApplyDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    public void InvokeCrawling(Animator animator, ZombieConfiguration config)
    {
        StartCoroutine(StartCrawling(animator, config));
    }
    private IEnumerator StartCrawling(Animator animator, ZombieConfiguration config)
    {
        yield return new WaitForSeconds(config.DeathTakeLong);
        animator.SetTrigger(ZombieStringReferences.Crawl);
    }

    public void InvokeDeactivate()
    {
        StartCoroutine(Deactivate());
    }
    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    #region Utility



    #endregion


}

[System.Serializable]
public class ZombieConfiguration
{
    [SerializeField] public float DistanceToSeeHuman;
    [SerializeField] public float DistanceToHearHuman;
    [SerializeField] public float DeathTakeLong;


    [SerializeField] private List<ZombieHealthIInterval> _healthIntervalsList;


    private Dictionary<string, int> _healthIntervals;
    public Dictionary<string, int> HealthIntervals
    {
        get
        {
            if (_healthIntervals == null)
            {
                _healthIntervals = new Dictionary<string, int>();
                foreach (var item in _healthIntervalsList)
                {
                    _healthIntervals.Add(item.IntervalName, item.HealthValue);
                }
            }
            return _healthIntervals;
        }

    }
}

[System.Serializable]
public struct ZombieHealthIInterval
{
    public string IntervalName;
    public int HealthValue;
}
