using UnityEngine;

[RequireComponent(typeof(Vampirism))]

public class AbilityEffects : MonoBehaviour 
{
    [SerializeField] private SpriteRenderer _effectAreaCircleSprite;

    private Vampirism _vampirism;
    private float _currentSpriteHeight;
    private float _currentSpriteWidth;
    private Vector3 _currentLocalScale;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
        _vampirism.ActivatedAbility += EnableEffect;
        _vampirism.DeactivatedAbility += DisableEffect;
        _effectAreaCircleSprite.enabled = false;
        SetAbilityArea();
    }

    private void OnDisable()
    {
        _vampirism.ActivatedAbility -= EnableEffect;
        _vampirism.DeactivatedAbility -= DisableEffect;
    }

    private void SetAbilityArea()
    {
        float multipleIndex = 2;
        float currentSpriteValueZ = 0;

        _currentSpriteHeight = _effectAreaCircleSprite.localBounds.size.y;
        _currentSpriteWidth = _effectAreaCircleSprite.localBounds.size.x;
        _currentLocalScale = _effectAreaCircleSprite.gameObject.transform.localScale;

        float localScaleHeight = (_vampirism.CircleRadius * multipleIndex * _currentLocalScale.y) / _currentSpriteHeight;
        float localScaleWidth = (_vampirism.CircleRadius * multipleIndex * _currentLocalScale.x) / _currentSpriteWidth;

        _effectAreaCircleSprite.transform.localScale = new Vector3(localScaleWidth, localScaleHeight, currentSpriteValueZ);
    }

    private void EnableEffect()
    {
        _effectAreaCircleSprite.enabled = true;
    }

    private void DisableEffect()
    {
        _effectAreaCircleSprite.enabled = false;
    }
}
