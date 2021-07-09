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
        _enemy.OnHealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        _enemy.OnHealthChanged -= UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay(int health)
    {
        
    }
}
