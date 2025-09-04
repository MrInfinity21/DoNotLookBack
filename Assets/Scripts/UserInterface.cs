using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;
    
    
    [SerializeField] private TextMeshProUGUI _viewBar;

    [Header("Player Gauge")]
    private float _viewBarFillAmount = 100f;
    private float _currentGauge;
    [SerializeField] private Image _playerGauge;

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

        _currentGauge = _viewBarFillAmount;
        
    }

    public void UpdateViewBar(bool isLooking)
    {
        if (isLooking)
        {
            _viewBarFillAmount += Time.deltaTime;
        }
        else
        {
            _playerGauge.fillAmount = _viewBarFillAmount / 100;
            _viewBarFillAmount -= Time.deltaTime;
            
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
