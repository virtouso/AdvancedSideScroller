using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtility
{
    public static float GetCurrentAnimatorTime(Animator targetAnim, int layer )
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        float currentTime = animState.normalizedTime % 1;
        return currentTime;
    }
}
