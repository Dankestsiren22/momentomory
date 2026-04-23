using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image PlayerHp;
    public Image BossHp;
    public CombatMovement player;
    public PlagueDoctorCombatBrain plagueDoctor;
    // Update is called once per frame
    void Update()
    {
        PlayerHp.fillAmount = (float)player.Health / (float)player.MaxHealth;
        BossHp.fillAmount = (float)plagueDoctor.Health / (float)plagueDoctor.MaxHealth;

    }
}
