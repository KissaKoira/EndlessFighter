using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_handler : MonoBehaviour
{
    public List<Spell> spells;
    public GameObject spell_prefab;

    // Start is called before the first frame update
    void Start()
    {
        spells = new List<Spell>();
        spells.Add(new Spell("test_spell", 1));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < spells.Count; i++)
        {
            if(spells[i].cooldown <= 0)
            {
                GameObject newSpell = GameObject.Instantiate(spell_prefab);
                newSpell.transform.position = GameObject.Find("Player").transform.position;
                newSpell.GetComponent<Rigidbody2D>().velocity = GameObject.Find("Player").GetComponent<player_controller>().direction * 10;
                spells[i].cooldown = spells[i].speed;
            }

            spells[i].cooldown -= Time.deltaTime;
        }
    }
}
