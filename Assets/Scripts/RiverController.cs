using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
      
        if(other.gameObject.tag != "blox") return;
         other.transform.GetChild(0).GetComponent<BloxManager>().PlaySound();
    }
}
