using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level1Manager : BaseLevelScenarioManager
{
    [Inject] private CameraSideFollow _baseGameCamera;
    [Inject] private PlayerController _playerController;
    private void Start()
    {
        ConfigurateLevel();
    }

    private void ConfigurateLevel()
    {
        _baseGameCamera.ChangeCameraMode(CameraModes.PlayerShooting);
        _playerController.UpdatePlayerMoveMode(PlayerMoveMode.Walk);
    }

}
