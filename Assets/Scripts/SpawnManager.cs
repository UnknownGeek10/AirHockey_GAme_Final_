using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Spawnee;
    public bool StopSpawning= false;
    public float SpawnTime;
    public float SpawnDelay;
    public float SpawnDuration;


    public void SpawnObject()
    {
        Instantiate(Spawnee,transform.position,transform.rotation);
        IEnumerator CountdownToStop()
        {
            while (SpawnDuration > 0)
            {


                yield return new WaitForSeconds(1f);

                SpawnDuration--;
            }


            yield return new WaitForSeconds(1f);
            CancelInvoke("SpawnObject");


        }
    }
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnObject", SpawnTime, SpawnDelay);
        //StartCoroutine( CountdownToStop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
