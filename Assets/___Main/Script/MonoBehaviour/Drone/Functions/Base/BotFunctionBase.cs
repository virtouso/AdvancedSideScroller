using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;


public abstract class BotFunctionBase : ScriptableObject
{
    [SerializeField] private List<ScoreCalculatorBase> _scoreCalculator;


    public abstract void Execute(DroneEnvironmentKnowledge knowledge);



    public int CalculateScore(DroneEnvironmentKnowledge knowledge)
    {
        int score = 0;
        StringBuilder builder = new StringBuilder();


        foreach (var item in _scoreCalculator)
        {

            int itemScore = item.Execute(knowledge);
            score += itemScore;
            builder.Append(item.GetType().Name + ":::" + itemScore);
        }
        builder.Append(this.GetType().Name + score).Append(Environment.NewLine);

        Debug.Log(builder);
        return score;
    }



}
