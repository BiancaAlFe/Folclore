using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public GameObject Player;
    public Vector3 CastPosition;
    public float Speed, Damage;
    public List<string> TargetTag;
    public virtual void Cast() {}
}
