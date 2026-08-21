using UnityEngine;

public class Shift : MonoBehaviour
{
    [SerializeField] private GameObject upper;
    [SerializeField] private GameObject lower;

    private bool isUpper = false;

    public void Toggle()
    {
        SetIsUpper(!isUpper);
    }

    public void SetIsUpper(bool up)
    {
        isUpper = up;

        if (isUpper)
        {
            upper.SetActive(true);
            lower.SetActive(false);
        }
        else
        {
            upper.SetActive(false);
            lower.SetActive(true);
        }

    }
}
