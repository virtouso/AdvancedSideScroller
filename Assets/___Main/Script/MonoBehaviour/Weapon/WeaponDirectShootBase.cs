using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDirectShootBase : WeaponBase
{

    [SerializeField] public Transform PrimaryHandSocket;
    [SerializeField] public Transform SecondaryHandSocket;
    [SerializeField] public Transform ShootMuzzle;
    [SerializeField] public int _totalReserved;
    [SerializeField] public int _loaded;
}
