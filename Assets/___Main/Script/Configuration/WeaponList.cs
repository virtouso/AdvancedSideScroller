using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;



[CreateAssetMenu(fileName = "Weapon List", menuName = "Moeen Assets/ Weapon List", order = int.MaxValue)]
public class WeaponList : ScriptableObject
{

    public WeaponListModel GetWeaponList()
    {
        return _weaponListModel;
    }

    [SerializeField] private WeaponListModel _weaponListModel;
}

[System.Serializable]
public struct WeaponListModel
{



    public WeaponListModel(WeaponKnife knife, WeaponPistol pistol, WeaponRifle rifle)
    {
        Knife = knife;
        Pistol = pistol;
        Rifle = rifle;
    }

 

    public WeaponKnife Knife;
    public WeaponPistol Pistol;
    public WeaponRifle Rifle;
}
