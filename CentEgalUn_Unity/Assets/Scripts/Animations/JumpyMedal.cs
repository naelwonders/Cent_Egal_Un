using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=YqMpVCPX2ls
public class JumpyMedal : MonoBehaviour
{
    private float jumpingHeight = 25f;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartJumpTweeen()
    {
        

        // Use LeanTween to tween to the new position in world space
        transform.LeanMove(new Vector3(0f, 125f + jumpingHeight), 0.5f).setEaseOutQuart().setLoopPingPong();

    
    }
}
