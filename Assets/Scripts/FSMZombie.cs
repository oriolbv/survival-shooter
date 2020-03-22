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
        stateActual = statePursuePlayer;
    }

    private void Update()
    {
        if ((PlayerObject.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
        {
            stateActual.ToStatePursuePlayer();
        }
        else
        {
            stateActual.ToStateStandby();
        }
        stateActual.UpdateState();
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
        // Zombie should pursue player
        fsm.agent.destination = fsm.PlayerObject.transform.position;
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
        // Zombie will not move
        fsm.agent.velocity = new Vector3(0f, 0f, 0f);
    }
}