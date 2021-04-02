using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BotFunctionBase : ScriptableObject
{
    [SerializeField] private List<ScoreCalculatorBase> _scoreCalculator;


    public abstract void Execute(DroneEnvironmentKnowledge knowledge);



    public int CalculateScore(DroneEnvironmentKnowledge knowledge)
    {
        int score = 0;
        foreach (var item in _scoreCalculator)
        {
            score += item.Execute(knowledge);
        }

        return score;
    }



}
