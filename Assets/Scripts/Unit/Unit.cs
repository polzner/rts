using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, Character
{
    private int _maxHealth;
    private NavMeshAgent _navMeshAgent;
    private bool _isSelected;
    private ResourceSite _resourceSite;
    private Enemy _enemy;
    private Transform _selfTransform;
    [SerializeField] private int _health = 100;
    [SerializeField] private float _attackTimerMax = 1;
    [SerializeField] private float _attackDistance = 3;
    [SerializeField] private Billboard _billboard;

    private StateMachine _stateMachine;
    private MovingState _groundedState;
    private AttackingState _attackingState;
    private MiningState _miningState;

    [SerializeField] private GameObject _selectedIconGameObject;
    [SerializeField] private int _damage = 5;

    public float AttackTimerMax => _attackTimerMax;
    public float AttackDistance => _attackDistance;
    public int Damage => _damage;
    public bool IsSelected => _isSelected;    
    public Enemy EnemyTarget => _enemy;
    public Vector3 Position => _selfTransform.position;
    public StateMachine StateMachine => _stateMachine; 
    public MovingState GroundedState => _groundedState;
    public AttackingState AttackingState  => _attackingState; 
    public MiningState MiningState  => _miningState;
    public ResourceSite ResourceSite => _resourceSite;

    private void Awake()
    {
        _maxHealth = _health;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        Selected(false);
    }

    private void Start()
    {
        _stateMachine = new StateMachine();
        _billboard.Init(_stateMachine);
        _groundedState = new MovingState(this, _stateMachine);
        _attackingState = new AttackingState(this, _stateMachine);
        _miningState = new MiningState(this, _stateMachine);
        
        _stateMachine.Initialise(_groundedState);
        _selfTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        _stateMachine.CurrentState.InputUpdate();
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SetEnemyTarget(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void SetDestination(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
    }

    public void Selected(bool isSelected)
    {
        _isSelected = isSelected;
        _selectedIconGameObject.SetActive(isSelected);
    }

    public void SetResourceSite(ResourceSite resourseSite)
    {
        _resourceSite = resourseSite;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }
}
