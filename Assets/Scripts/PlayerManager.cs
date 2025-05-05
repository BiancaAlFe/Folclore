using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float XAxis = Input.GetAxis("Horizontal");
        float YAxis = Input.GetAxis("Vertical");
        Vector3 Axis = new Vector3(XAxis, YAxis, 0f);
        if (Axis.magnitude > 1f)
        {
            Axis.Normalize();
        }

        Rigidbody.MovePosition(transform.position + Axis * Time.deltaTime * Speed);
    }
}
