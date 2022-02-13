using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ui_handler : MonoBehaviour
{
    public Camera cam;
    public GameObject player;

    public GameObject health_bar;
    public GameObject spell_bar;
    public GameObject xp_bar;
    public GameObject damage_prefab;

    Vector3 hb_scale;
    Vector3 sb_scale;
    Vector3 xb_scale;
    private void Start()
    {
        player = GameObject.Find("Player");

        hb_scale = health_bar.transform.localScale;
        sb_scale = spell_bar.transform.localScale;
        xb_scale = xp_bar.transform.localScale;
    }

    public void displayDamage(Vector3 point, float damage)
    {
        GameObject dmg = GameObject.Instantiate(damage_prefab);
        dmg.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = damage.ToString();
        dmg.transform.SetParent(transform);
        dmg.transform.position = cam.WorldToScreenPoint(point);
        dmg.GetComponent<damage_text_script>().point = point;
        dmg.GetComponent<damage_text_script>().cam = cam;
    }
    
    void Update()
    {
        //HealthBar
        float health = player.GetComponent<player_controller>().health;
        health_bar.transform.GetChild(1).transform.localScale = new Vector3(hb_scale.x * (health / 100), hb_scale.y, hb_scale.z);
        //SpellBar
        float cooldown = GameObject.Find("GameController").GetComponent<game_controller>().spells[0].cooldown;
        float activeCd = GameObject.Find("GameController").GetComponent<game_controller>().spells[0].activeCD;
        spell_bar.transform.GetChild(1).transform.localScale = new Vector3(sb_scale.x * (activeCd / cooldown), sb_scale.y, sb_scale.z);
        //XpBar
        float max_xp = player.GetComponent<player_controller>().max_xp;
        float xp = player.GetComponent<player_controller>().xp;
        xp_bar.transform.GetChild(0).transform.localScale = new Vector3(xb_scale.x * (xp / max_xp), xb_scale.y, xb_scale.z);
        xp_bar.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = player.GetComponent<player_controller>().level.ToString();
    }
}
