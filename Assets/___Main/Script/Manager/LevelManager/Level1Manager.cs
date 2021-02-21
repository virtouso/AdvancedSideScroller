using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level1Manager : BaseLevelScenarioManager
{
    [Inject] private CameraSideFollow _baseGameCamera;

    private void Start()
    {
        ConfigurateLevel();
    }

    private void ConfigurateLevel()
    {
        _baseGameCamera.ChangeCameraMode(CameraModes.PlayerShooting);
    }

}
