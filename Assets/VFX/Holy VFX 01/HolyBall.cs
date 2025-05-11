using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBall : SpellScript
{
    public Vector3 Direction;
    public float CastDistance;
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
        foreach (var tag in TargetTag)
        {
            if (collision.gameObject.tag == tag)
            {
                transform.position = collision.ClosestPoint(transform.position);
                Speed = 0f;
                Animator.SetTrigger("Explode");
                Destroy(gameObject, 0.5f);
                CombatEntity targetCombatEntity = collision.gameObject.GetComponent<CombatEntity>();
                if (targetCombatEntity != null)
                {
                    targetCombatEntity.TakeDamage(Damage);
                }
            }
        }
    }

    public override void Cast()
    {
        Direction = (CastPosition - Player.transform.position).normalized;
        transform.position = Player.transform.position + Direction * CastDistance;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Destroy(this.gameObject, 3f);
    }
}
