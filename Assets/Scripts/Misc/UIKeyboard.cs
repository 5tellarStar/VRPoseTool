using TMPro;
using UnityEngine;

public class UIKeyboard : MonoBehaviour
{
    [HideInInspector] public string writtenText = "";
    [SerializeField] private TextMeshProUGUI textField;

    public void AddString(string str)
    {
        writtenText += str;
        textField.text = writtenText;
    }

    public void Backspace()
    {
        if (writtenText.Length == 0) return;
        writtenText = writtenText.Remove(writtenText.Length - 1);
        textField.text = writtenText;
    }
}
