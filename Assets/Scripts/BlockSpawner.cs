using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Rigidbody2D blockTemplate;
    [SerializeField] int minInterval;
    [SerializeField] int maxInterval;
    [SerializeField] Vector3 spawnThrowForce;

    float nextDropTime;

    // Start is called before the first frame update
    void Start()
    {
        CalcNextDropTime();
    }

    void CalcNextDropTime()
    {
        nextDropTime = Time.time + Random.value * (maxInterval - minInterval) + minInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time left: " + (nextDropTime - Time.time));
        if (Time.time >= nextDropTime)
        {

            Debug.Log("Creating!!");
            Rigidbody2D newBlock = GameObject.Instantiate<Rigidbody2D>(blockTemplate);
            newBlock.transform.position = this.transform.position;

            newBlock.AddForce(spawnThrowForce, ForceMode2D.Impulse);
            CalcNextDropTime();
        }
    }
}
