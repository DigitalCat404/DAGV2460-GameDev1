using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplerAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform playerTransformObj;

    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){
        if(isActive){
            agent.SetDestination(playerTransformObj.position);
        }
    }


    public void Pause(float seconds){
        isActive = false;

        Invoke("BecomeActive", seconds);
    }


    private void BecomeActive(){
        isActive = true;
    }
}
