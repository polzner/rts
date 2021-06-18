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
    private int _damage = 5;
    private Transform _selfTransform;

    private StateMachine _stateMachine;
    private MovingState _groundedState;
    private AttackingState _attackingState;
    //
    //
    //

    [SerializeField] private GameObject _selectedIconGameObject;

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
        //switch (_state)
        //{
        //    case State.Normal:                
        //        break;
        //    case State.GoingToMining:
        //        SetDestination(_resourceSite.GetPosition());
        //        float reachedDistance = 2;

        //        if(Vector3.Distance(transform.position, _resourceSite.GetPosition()) < reachedDistance)
        //        {
        //            _state = State.Mining;
        //        }
        //        break;
        //    case State.Mining:
        //        _resourceMiningTimer -= Time.deltaTime;
        //        if(_resourceMiningTimer < 0)
        //        {
        //            float resourceMiningMaxTime = 1f;
        //            int resourceMaxQuantity = 5;
        //            _resourceMiningTimer = resourceMiningMaxTime;
        //            _resourceQuantity++;

        //            if(_resourceQuantity == resourceMaxQuantity)
        //            {
        //                _state = State.GoingToStorage;
        //            }
        //        }
        //        break;
        //    case State.GoingToStorage:
        //        SetDestination(new Vector3(230,0.3f,130));
        //        reachedDistance = 2;

        //        if (Vector3.Distance(transform.position, new Vector3(230, 0.3f, 130)) < reachedDistance)
        //        {
        //            _state = State.GoingToMining;
        //            ResourceManager.Instance.AddResource(_resourceQuantity);
        //            _resourceQuantity = 0;
        //        }
        //        break;
        //    case State.MoveToTarget:
        //        SetDestination(_enemy.GetPosition());

        //        reachedDistance = 2;

        //        if (Vector3.Distance(transform.position, _enemy.GetPosition()) < reachedDistance)
        //        {
        //            _state = State.AttackingTarget;
        //        }
        //        break;
        //    case State.AttackingTarget:
        //        _attackTimer -= Time.deltaTime;
        //        float attackTimerMax = 1;

        //        if(_attackTimer < 0)
        //        {
        //            _attackTimer = attackTimerMax;
        //            _enemy.TakeDamege(_unitAttack);
        //        }
        //        break;
               
        //}

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
