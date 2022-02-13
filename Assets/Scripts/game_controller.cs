using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_controller : MonoBehaviour
{
    public GameObject player;
    public float spawn_radius;
    private float waveCounter;

    public List<Spell> spells;
    public GameObject spell_prefab;

    public GameObject skeleton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawn_radius = 10;
        waveCounter = 0;

        spells = new List<Spell>();
        spells.Add(new Spell("test_spell", 20, 1, 1));
    }

    public void spawnMonster(GameObject prefab, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject newMonster = GameObject.Instantiate(prefab);
            float angle = Random.Range(0, 360);
            newMonster.transform.position = new Vector3(player.transform.position.x + (spawn_radius * Mathf.Cos(angle)), player.transform.position.y + (spawn_radius * Mathf.Sin(angle)), 0);
        }
    }

    public void restartGame() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player_controller>().alive)
        {
            if (waveCounter <= 0)
            {
                spawnMonster(skeleton, 5);
                waveCounter = 10;
            }
            waveCounter -= Time.deltaTime;

            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].activeCD <= 0)
                {
                    GameObject newSpell = GameObject.Instantiate(spell_prefab);
                    newSpell.GetComponent<spell_interaction>().damage = spells[i].damage;
                    newSpell.transform.position = GameObject.Find("Player").transform.position;
                    newSpell.GetComponent<Rigidbody2D>().velocity = GameObject.Find("Player").GetComponent<player_controller>().direction * 10;
                    spells[i].activeCD = spells[i].cooldown;
                }

                spells[i].activeCD -= Time.deltaTime;
            }
        }
    }
}
