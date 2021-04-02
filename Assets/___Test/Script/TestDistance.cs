using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistance : MonoBehaviour
{

    [SerializeField] private Ladder _ladder;

    void Start()
    {
        foreach (var item in _ladder.Rungs)
        {
            print(item.transform.position);
        }
    }


}
