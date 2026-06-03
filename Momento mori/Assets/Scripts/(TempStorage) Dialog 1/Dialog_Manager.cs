using System.Linq;
using UnityEngine;

public class Dialog_Manager : MonoBehaviour
{


    void Start()
    {

#pragma warning disable CS0618 // Type or member is obsolete
        IDialog[] targets = FindObjectsOfType<MonoBehaviour>().OfType<IDialog>().ToArray();
#pragma warning restore CS0618 // Type or member is obsolete
        foreach (IDialog target in targets)
        {
            target.InDialog = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
