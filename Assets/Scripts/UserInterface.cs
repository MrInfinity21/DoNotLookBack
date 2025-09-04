using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;
    private int _viewBarFillAmount = 100;
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

    public void UpdateViewBar(bool isLooking)
    {
        if (isLooking)
        {
            _viewBarFillAmount++;
        }
        else
        {
            _viewBarFillAmount--;
            if (_viewBarFillAmount <= 0)
                GameManager.instance.EndGame();
        }
    }

    public void IsLookingUpdate(bool isLooking)
    {
        if (isLooking)
            _viewBar.text = "...";
        else
            _viewBar.text = "NOT LOOKING";
    }
}
