using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rigidbody;
    public List<int> Spells;
    public SpellListSO SpellList;
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
        //CheckShot();
        if (Input.GetButtonDown("Fire1")) CastSpell(Spells[0]);
        if (Input.GetButtonDown("Fire2")) CastSpell(Spells[1]);
        if (Input.GetKeyDown(KeyCode.Q)) CastSpell(Spells[2]);
        if (Input.GetKeyDown(KeyCode.E)) CastSpell(Spells[3]);
        if (Input.GetKeyDown(KeyCode.R)) CastSpell(Spells[4]);
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

    void CastSpell(int spellIndex)
    {
        foreach (var spell in SpellList.SpellList)
        {
            if (spell.Id == spellIndex)
            {
                var newSpell = Instantiate(spell.SpellPrefab).GetComponent<SpellScript>();
                newSpell.Player = gameObject;
                Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                worldPosition.z = 0;
                newSpell.CastPosition = worldPosition;
                newSpell.Cast();
                break;
            }
        }
    }
}
