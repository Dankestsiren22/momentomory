using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Fill;

    public void SetHealth(int Health,int MaxHealth)
    {
        Fill.fillAmount = (float)Health / (float)MaxHealth;
    }
}