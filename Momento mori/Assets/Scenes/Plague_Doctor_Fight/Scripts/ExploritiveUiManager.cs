using UnityEngine;
using UnityEngine.UI;

public class ExploritiveUiManager : MonoBehaviour
{
    public Image MementoProgress;
    public PlayerMovement Player;
    void Update()
    {
        MementoProgress.fillAmount = (float)Player.CurrentMementos / (float)Player.MaxMementos;
    }
}
