using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SiderPlayerAimHelper : MonoBehaviour
{
    [Inject] private PlayerController _playerController;

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerController.transform.position;
    }
}
