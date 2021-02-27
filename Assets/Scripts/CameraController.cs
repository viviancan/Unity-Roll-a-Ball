using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //references player position
    public GameObject player;
    
    //stores offset value
    //private - set in script
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // sets offset = to the cameras transform position - players transform position
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
     
        transform.position = player.transform.position + offset;
    }
}
