using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBall : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Vector3 Direction;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Rigidbody.MovePosition(transform.position + Direction * Time.deltaTime * Speed);
    }
}
