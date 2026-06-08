using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialog_Manager : MonoBehaviour
{
    public Button Button;
    public DialogData Dialog;
    public TextMeshProUGUI TextBox;
    public float TimePerCharacter;
    public bool IsTyping;
    public int currentIndex = 0;
    void Start()
    {
        #pragma warning disable CS0618
        IDialog[] targets = FindObjectsOfType<MonoBehaviour>().OfType<IDialog>().ToArray();
        #pragma warning restore CS0618
        foreach (IDialog target in targets)
        {
            target.InDialog = true;
        }
        StartCoroutine(TypeText(Dialog, currentIndex));
    }
    public void Next()
    {
        StartCoroutine(TypeText(Dialog, currentIndex));
    }
    private IEnumerator TypeText(DialogData data, int Index)
    {
        if (Index >= data.Text.Length)
        {
            TextBox.enabled = false;
            Button.enabled = false;
            #pragma warning disable CS0618
            IDialog[] targets = FindObjectsOfType<MonoBehaviour>().OfType<IDialog>().ToArray();
            #pragma warning restore CS0618
            foreach (IDialog target in targets)
            {
                target.InDialog = false;
            }
            yield break;
        }

        if (IsTyping)
        {
            StopAllCoroutines();
            TextBox.maxVisibleCharacters = TextBox.textInfo.characterCount;
            IsTyping = false;
            currentIndex++;
            yield break;
        }
        TextBox.maxVisibleCharacters = 0;
        TextBox.text = data.Text[Index];
        TextBox.ForceMeshUpdate();
        IsTyping = true;
        int totalVisibleCharacters = TextBox.textInfo.characterCount;
        for (int i = 0; i <= totalVisibleCharacters; i++)
        {
            TextBox.maxVisibleCharacters = i;

            yield return new WaitForSeconds(TimePerCharacter);
        }
        IsTyping = false;
        currentIndex++;
    }
}

