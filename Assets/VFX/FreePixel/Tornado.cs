using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tornado : SpellScript
{
    public Vector3 Direction;
    public float CastDistance;
    List<CombatEntity> TargetsInside;
    public float DamageCooldown, DamageCounter, Duration;
    // Start is called before the first frame update
    void Start()
    {
        DamageCounter = DamageCooldown;
        TargetsInside = new List<CombatEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        DamageCounter += Time.deltaTime;
        while (DamageCounter > DamageCooldown)
        {
            DamageCounter -= DamageCooldown;
            CauseDamage();
        }
    }

    void CauseDamage()
    {
        for (int i = TargetsInside.Count - 1; i >= 0; i--)
        {
            if (TargetsInside[i] == null)
            {
                TargetsInside.RemoveAt(i);
                continue;
            } else {
                TargetsInside[i].TakeDamage(Damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tag in TargetTag)
        {
            if (collision.gameObject.tag == tag)
            {
                CombatEntity targetCombatEntity = collision.gameObject.GetComponent<CombatEntity>();
                TargetsInside.Add(targetCombatEntity);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = TargetsInside.Count - 1; i >= 0; i--)
        {
            if (TargetsInside[i] == null)
            {
                TargetsInside.RemoveAt(i);
                continue;
            } else if(TargetsInside[i].gameObject == collision.gameObject) {
                TargetsInside.RemoveAt(i);
            }
        }
    }

    public override void Cast()
    {
        transform.position = CastPosition;
        Destroy(this.gameObject, Duration);
    }
}
