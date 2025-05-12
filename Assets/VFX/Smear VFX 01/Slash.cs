using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SpellScript
{
    public Vector3 Direction, Offset;
    public float CastDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tag in TargetTag)
        {
            if (collision.gameObject.tag == tag)
            {
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
        Direction = (CastPosition - Offset - Player.transform.position).normalized;
        transform.position = Player.transform.position + Offset + Direction * CastDistance;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Destroy(this.gameObject, 0.5f);
    }
}
