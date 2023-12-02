using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDropdown : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    private float waitTime;
    public float delay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S)){
            waitTime = delay;
            effector2D.rotationalOffset = 0;
        }

        //flip effector down when S is held long enough
        if(Input.GetKey(KeyCode.S)){
            if(waitTime <=0){
                effector2D.rotationalOffset = 180f; //flip efffector

            } else {
                waitTime -= Time.deltaTime; //reduce wait time over time
            }
        }

        //flip effector back up
        if(Input.GetKey(KeyCode.W)){
            
        }
    }
}
