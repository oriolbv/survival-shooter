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

    // [HideInInspector] public float playerActualPosition;

    public GameObject PlayerObject;

    private void Awake()
    {
        statePursuePlayer = new StatePursuePlayer(this);
        stateStandby = new StateStandby(this);

        agent = GetComponent<NavMeshAgent>();

        // playerActualPosition = PlayerObject.transform.position.x;
    }

    private void Start()
    {
        stateActual = stateStandby;
    }

    private void Update()
    {
        // if (PlayerObject.transform.position.x != playerActualPosition && stateActual != statePursuePlayer)
        // {
        //     // Player has changed its position
        //     stateActual.ToStatePursuePlayer();
        //     playerActualPosition = PlayerObject.transform.position.x;
        // }
        // else if (PlayerObject.transform.position.x == playerActualPosition && stateActual != statePursueEnemy)
        // {
        //     // Player has NOT changed its position
        //     stateActual.ToStatePursueEnemy();
        // }
        // else
        // {
        //     stateActual.UpdateState();
        //     playerActualPosition = PlayerObject.transform.position.x;
        // }
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