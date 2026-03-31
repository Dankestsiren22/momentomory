using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Transform SelectedLevel;
    public Transform NextLevel;

    int level;

    public Image Level1;
    public Image Level2;
    public void Nextlevel()
    {
        level++;
        if (level == 1)
        {
            Level1.transform.position = SelectedLevel.transform.position;
            Level2.transform.position = NextLevel.transform.position;
            
        }
        else if (level == 2)
        {
            Level1.transform.position = NextLevel.transform.position;
            Level2.transform.position = SelectedLevel.transform.position;
            level = 0;
        }

        
    }
}
