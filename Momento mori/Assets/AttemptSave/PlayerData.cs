using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerData : MonoBehaviour
{
    public bool Memento1;
    public bool Memento2;
    public bool Memento3;
    public bool Memento4;

    public void SavePlayer()
    {
        PlayerSaveLoadFunctions.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        SAvingSataTest data = PlayerSaveLoadFunctions.LoadPlayer();

        Memento1 = data.Memento1;
        Memento2 = data.Memento2;
        Memento3 = data.Memento3;
        Memento4 = data.Memento4;
    }
}