using UnityEngine;
using UnityEngine.UI;

public class CombatUiManager : MonoBehaviour
{
    public Image PlayerHp;
    public Image BossHp;
    public EnemyAi Boss;
    public CombatMovement Player;


    void Update()
    {
        BossHp.fillAmount = (float)Boss.CurrentHealth/(float)Boss.MaxHealth;
        PlayerHp.fillAmount = (float)Player.health/(float)Player.MaxHealth;
    }
}
