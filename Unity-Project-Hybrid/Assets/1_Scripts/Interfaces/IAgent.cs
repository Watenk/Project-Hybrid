using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IAgent 
{
    public GameObject GameObject { get; }
    public NavMeshAgent Agent { get; }
}