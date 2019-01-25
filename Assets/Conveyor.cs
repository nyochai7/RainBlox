using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private Vector3 force;

    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(transform.InverseTransformVector(force));
    }
}
