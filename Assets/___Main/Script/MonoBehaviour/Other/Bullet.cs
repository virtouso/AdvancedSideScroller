﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    public void Shoot(Vector3 position, Quaternion rotation, Vector3 moveDirection)
    {

        transform.position = position;
        transform.rotation = rotation;
        _rigidBody.velocity = moveDirection * _speed;
        Activate();
    }


    private void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }


    private void Update()
    {
        Ray ray = new Ray(transform.position, _rigidBody.velocity.normalized);
     
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit, _rayCastLength, _hitLayerMask);
        if (hasHit)
        {
            print("hit the anemy");
            hit.transform.root.GetComponent<EnemyControllerBase>().ApplyDamage(_damageAmount);
            gameObject.SetActive(false);
        }
    }



    [SerializeField] private LayerMask _hitLayerMask;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _rayCastLength;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidBody;





}
