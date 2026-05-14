using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvas : MonoBehaviour
{
    
    TextMeshProUGUI text;
    CombatMovement Player;
    public void Awake()
    {
        text = GameObject.Find("text").GetComponent<TextMeshProUGUI>();
        Player = GameObject.Find("Player").GetComponent<CombatMovement>();
    }

}
