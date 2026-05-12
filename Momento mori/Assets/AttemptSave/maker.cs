using UnityEngine;

public class maker : MonoBehaviour
{
    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;
    public GameObject Player;
    public PlayerData playerData;
    void Start()
    {
        Instantiate(M1);
        Instantiate(M2);
        Instantiate(M3);
        Instantiate(Player);
        playerData.LoadPlayer();
    }

}
