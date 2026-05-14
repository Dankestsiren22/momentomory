using UnityEngine;

public class maker : MonoBehaviour
{
    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;
    public GameObject Player;
    public PlayerData playerData;
    void Awake()
    {
        if (M1 == false && M2 == false && M3 == false && M4 == false)
        {
            playerData.SavePlayer();

        }
        playerData.LoadPlayer();

        if (playerData.Memento1 == false)
            Instantiate(M1);

        if (playerData.Memento2 == false)
            Instantiate(M2);

        if (playerData.Memento3 == false)
            Instantiate(M3);

        if (playerData.Memento4 == false)
            Instantiate(M4);

        Instantiate(Player);
    }

}
