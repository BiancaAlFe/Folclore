using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBall : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    public string TargetTag;
    Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.position = collision.ClosestPoint(transform.position);
            Speed = 0f;
            Animator.SetTrigger("Explode");
            Destroy(gameObject, 0.5f);
        }
        if (collision.gameObject.tag == TargetTag)
        {
            transform.position = collision.ClosestPoint(transform.position);
            Speed = 0f;
            Animator.SetTrigger("Explode");
            Destroy(gameObject, 0.5f);
        }
    }
}
