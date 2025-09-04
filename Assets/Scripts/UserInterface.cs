using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;
    [SerializeField] private TextMeshProUGUI _viewBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void UpdateViewBar()
    {

    }

    public void IsLookingUpdate(bool isLooking)
    {
        if (isLooking)
            _viewBar.text = "Looking...";
        else
            _viewBar.text = "NOT LOOKING";
    }
}
