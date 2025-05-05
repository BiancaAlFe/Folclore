using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rigidbody;
    public GameObject HolyBall;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        CheckShot();
    }

    void Move()
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

    void Flip()
    {
        float XAxis = Input.GetAxis("Horizontal");
        Vector3 localScale = transform.localScale;
        if (XAxis > 0)
        {
            localScale.x = 1;
        } else if (XAxis < 0)
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;
    }

    void CheckShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            Vector3 positionRelative = worldPosition - transform.position;
            positionRelative.Normalize();
            var newHolyBall = Instantiate(HolyBall, transform.position + positionRelative, Quaternion.identity);
            Destroy(newHolyBall, 3f);
        }
    }
}
