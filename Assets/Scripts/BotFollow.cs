using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotFollow : MonoBehaviour
{
    public Transform player; // referencia ao transform do jogador
    public float followSpeed = 5f; // velocidade de movimento do adversaaario
    public float offsetDistance = 2f; // sistancia fixa na frente do jogador
    public float tolerance = 0.1f; // toleancia para considerar que o adversario esta na posição correta no eixo X
    public float verticalFollowSpeed = 3f; // velolcidade de movimento para sempre ficar a frente do player
    private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveToFrontOfPlayer();
    }

    void MoveToFrontOfPlayer()
    {
        // determinar a posicao alvo no eixo X e Y
        float targetX = player.position.x + (player.localScale.x > 0 ? offsetDistance : -offsetDistance);
        float distanceToTargetX = Mathf.Abs(transform.position.x - targetX);

        float targetY = player.position.y;

        // atualizar posicao no eixo X
        float directionX = targetX > transform.position.x ? 1 : -1;
        float velocityX = distanceToTargetX > tolerance ? directionX * followSpeed : 0;

        // atualizar posicao no eixo Y
        float directionY = targetY > transform.position.y ? 1 : -1;
        float velocityY = Mathf.Abs(transform.position.y - targetY) > tolerance ? directionY * verticalFollowSpeed : 0;

        rb.velocity = new Vector2(velocityX, velocityY);

        animator.SetBool("isRunning", rb.velocity.magnitude > 0);

        // atualizar direcao do adversario
        Flip(targetX - transform.position.x);
    }

    void Flip(float direction)
    {
        if (direction > 0 && transform.localScale.x < 0 || direction < 0 && transform.localScale.x > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
