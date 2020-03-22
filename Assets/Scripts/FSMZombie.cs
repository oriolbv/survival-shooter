using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMZombie : MonoBehaviour
{
    // List of the different states
    [HideInInspector] public IStateZombie stateActual;
    [HideInInspector] public StatePursuePlayer statePursuePlayer;
    [HideInInspector] public StateStandby stateStandby;

    [HideInInspector] public NavMeshAgent agent;

    public GameObject PlayerObject;

    private void Awake()
    {
        statePursuePlayer = new StatePursuePlayer(this);
        stateStandby = new StateStandby(this);

        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        stateActual = stateStandby;
    }

    private void Update()
    {
        //agent.Warp(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        agent.destination = PlayerObject.transform.position;
    }
}
 
public interface IStateZombie
{
    void UpdateState();

    void ToStatePursuePlayer();

    void ToStateStandby();
}

public class StatePursuePlayer : IStateZombie
{
    private readonly FSMZombie fsm;
    public StatePursuePlayer(FSMZombie fsmZombie)
    {
        fsm = fsmZombie;
    }

    public void ToStateStandby()
    {
        fsm.stateActual = fsm.stateStandby;
    }

    public void ToStatePursuePlayer()
    {
        Debug.Log("Transition not permitted.");
    }

    public void UpdateState()
    {
        // Agent should pursue player
        // fsm.agent.destination = fsm.PlayerObject.transform.position + new Vector3(2f, 0f, 0f);
    }
}

public class StateStandby : IStateZombie
{
    private readonly FSMZombie fsm;
    public StateStandby(FSMZombie fsmZombie)
    {
        fsm = fsmZombie;
    }
    public void ToStateStandby()
    {
        Debug.Log("Transition not permitted.");
    }

    public void ToStatePursuePlayer()
    {
        fsm.stateActual = fsm.statePursuePlayer;
    }

    public void UpdateState()
    {
        // Agent should pursue enemy
        // fsm.agent.destination = fsm.EnemyObject.transform.position + new Vector3(2f, 0f, 0f);
    }
}