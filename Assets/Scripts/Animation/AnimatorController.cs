using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
        
    public void StartIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, true);
    }

    public void StartRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, true);
    }

    public void StartJumpAnimation()
    {
        _animator.SetBool(AnimationData.IsJump, true);
    }

    public void StartAttackAnimation()
    {
        _animator.SetTrigger(AnimationData.IsAttack);
    }

    public void StopIdleAnimation()
    {
        _animator.SetBool(AnimationData.IsIdle, false);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(AnimationData.IsRun, false);
    }

    public void StopJumpAnimation()
    {
        _animator.SetBool(AnimationData.IsJump, false);
    }
}
