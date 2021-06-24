using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private bool _isSelected;
    private ResourceSite _resourceSite;
    private float _resourceMiningTimer;
    private int _resourceQuantity;
    private Enemy _enemy;
    private Transform _selfTransform;

    private StateMachine _stateMachine;
    private MovingState _groundedState;
    private AttackingState _attackingState;

    [SerializeField] private GameObject _selectedIconGameObject;
    [SerializeField] private int _damage = 5;

    public int Damage => _damage;
    public bool IsSelected => _isSelected;    
    public Enemy EnemyTarget => _enemy;
    public Vector3 Position => _selfTransform.position;
    public StateMachine StateMachine => _stateMachine; 
    public MovingState GroundedState => _groundedState;
    public AttackingState AttackingState  => _attackingState; 

    private void Start()
    {
        _stateMachine = new StateMachine();
        _groundedState = new MovingState(this, _stateMachine);
        _attackingState = new AttackingState(this, _stateMachine);
        _stateMachine.Initialise(_groundedState);
        _selfTransform = GetComponent<Transform>();

    }

    private void Update()
    {      
        _stateMachine.CurrentState.InputUpdate();
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        Selected(false);
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
}
