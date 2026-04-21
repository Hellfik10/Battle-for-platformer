using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private AnimationEndHandler _animationEndHandler;
    private Dictionary<string, int> animationHashes = new Dictionary<string, int>();

    public event Action AttackEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animationEndHandler = _animator.GetBehaviour<AnimationEndHandler>();

        _animationEndHandler.AnimationEnded += OnAnimationEnded;

        animationHashes["Run"] = Animator.StringToHash("Run");
        animationHashes["Jump"] = Animator.StringToHash("Jump");
        animationHashes["Attack"] = Animator.StringToHash("Attack");
    }

    public void StartIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, true);
    }

    public void StartRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, true);
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsAttack, true);
    }

    public void StopIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, false);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, false);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(AnimationData.IsAttack, false);
    }

    private void OnAnimationEnded(int stateHash)
    {
        foreach (var pair in animationHashes)
        {
            if (stateHash == pair.Value)
            {
                HandleAnimationEnd(pair.Key);
                return;
            }
        }
    }

    private void HandleAnimationEnd(string animationName)
    {
        switch (animationName)
        {
            case "Attack":
                AttackEnded?.Invoke();
                break;
        }
    }
}
