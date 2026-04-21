using System;
using UnityEngine;

public class AnimationEndHandler : StateMachineBehaviour
{
    public event Action<int> AnimationEnded;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimationEnded?.Invoke(stateInfo.shortNameHash);
    }
}
