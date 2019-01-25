using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject blockTemplate;
    [SerializeField] int minInterval;
    [SerializeField] int maxInterval;

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
        if (Time.time >= nextDropTime)
        {
            GameObject newBlock = GameObject.Instantiate<GameObject>(blockTemplate);
            newBlock.transform.position = this.transform.position;
            CalcNextDropTime();
        }
    }
}
