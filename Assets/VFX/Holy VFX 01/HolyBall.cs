using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBall : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Direction * Time.deltaTime * Speed;
    }
}
