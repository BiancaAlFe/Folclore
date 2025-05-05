using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rigidbody;

    private bool viradoParaDireita = true;
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

        Virar();
    }

        void Virar()
    {
        float entradaMovimento = Input.GetAxis("Horizontal");
        if(entradaMovimento > 0 && !viradoParaDireita)
        {
            FliparPersonagem();
        }else if (entradaMovimento < 0 && viradoParaDireita)
        {
            FliparPersonagem();
        }
    }

    void FliparPersonagem()
    {
        viradoParaDireita = !viradoParaDireita;
        Vector3 escalaLocal = transform.localScale;
        escalaLocal.x *= -1;
        transform.localScale = escalaLocal;
    }
}
