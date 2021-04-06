using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public abstract class EnemyControllerBase : MonoBehaviour
{
    public abstract Vector3 Position { get; }
    [SerializeField] public Animator Animator;
    [Inject] public PlayerController PlayerController;


    private Rigidbody[] _bodyParts;
    protected virtual void Awake()
    {
        _bodyParts = transform.GetComponentsInChildren<Rigidbody>();
        SwitchToAnimation();
    }

    protected virtual void Update()
    {

      


    }


    public void SwitchToRagdoll()
    {
        for (int i = 0; i < _bodyParts.Length; i++)
        {
            _bodyParts[i].isKinematic = false;
        }

        Animator.enabled = false;
    }

    public void SwitchToAnimation()
    {
        for (int i = 0; i < _bodyParts.Length; i++)
        {
            _bodyParts[i].isKinematic = true;
        }

        Animator.enabled = true;
    }


}
