using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [SerializeField] float distancetocover;
    public float speed = 5f;
    private Vector3 startingPosition;


    
    // Start is called before the first frame update
    void Start()
    {

        
        startingPosition= transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v= startingPosition;
        v.y += distancetocover * Mathf.Sin(Time.time * speed);
        transform.position = v;
        
    }

   

   
    


}
