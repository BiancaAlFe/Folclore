using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spell List")]
public class SpellListSO : ScriptableObject
{
    public List<Spell> SpellList;
}

[System.Serializable]
public class Spell
{
    public int Id;
    public GameObject SpellPrefab;
}