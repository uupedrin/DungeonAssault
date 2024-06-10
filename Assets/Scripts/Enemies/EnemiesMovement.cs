using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent (typeof(Rigidbody))]
public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] ScriptableObject eStats;
    public Rigidbody rb;
    [SerializeField] float speed;
    public NavMeshAgent agent;
    public Behaviour eBehaviour;


    public enum Behaviour
    {
        Archer, Rogue, Tank
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }
    void Update()
    {
        switch (eBehaviour)
        {
            case Behaviour.Archer:
                transform.LookAt(GameManager.instance.pMove.transform.position);
                Debug.DrawRay(transform.position, -(transform.position - GameManager.instance.pMove.transform.position), Color.red);
                break;

            case Behaviour.Tank:
                agent.destination = GameManager.instance.pMove.transform.position;
                break;

            case Behaviour.Rogue:
                agent.destination = GameManager.instance.pMove.transform.position;
                break;

            default:
                Debug.LogError("Error: Object Not Seted in a Behaviour");
                break;
        }
    }
}
