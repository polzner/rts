using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _selectedIconGameObject;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Renderer _enemyRenderer;

    private void OnEnable()
    {
        _enemy.HealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay(int health,int maxHealth)
    {
        _enemyRenderer.material.color = new Color(_enemyRenderer.material.color.r + _enemyRenderer.material.color.r*health / maxHealth
            , _enemyRenderer.material.color.g* health / maxHealth, _enemyRenderer.material.color.b* health / maxHealth);
    }

}
