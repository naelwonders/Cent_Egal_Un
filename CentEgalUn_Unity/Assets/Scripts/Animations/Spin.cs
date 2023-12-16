using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f , 40 * Time.deltaTime, Space.Self);
    }
}
