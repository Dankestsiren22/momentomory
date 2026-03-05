using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvas : MonoBehaviour
{
    Canvas canvas;
    TextMeshProUGUI text;
    CombatMovement Player;
    public void Awake()
    {
        text = GameObject.Find("text").GetComponent<TextMeshProUGUI>();
        Player = GameObject.Find("Player").GetComponent<CombatMovement>();
    }
    public void FixedUpdate()
    {
        text.text = "Damage Dealt:" + " " + Player.DamageDelt;
    }

}
