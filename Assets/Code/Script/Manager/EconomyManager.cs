using TMPro;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public float animationTime = 1.5f;

    private double initialNumber;

    public static EconomyManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    void Update()
    {
        if (SaveAndLoadManager.Instance.game.money != initialNumber)
        {
            if (initialNumber < SaveAndLoadManager.Instance.game.money)
            {
                initialNumber += (animationTime * Time.unscaledDeltaTime) *
                                 (SaveAndLoadManager.Instance.game.money - initialNumber);
                if (SaveAndLoadManager.Instance.game.money <= initialNumber)
                    initialNumber = SaveAndLoadManager.Instance.game.money;
            }
            else
            {
                initialNumber -= (animationTime * Time.unscaledDeltaTime) *
                                 (initialNumber - SaveAndLoadManager.Instance.game.money);
                if (SaveAndLoadManager.Instance.game.money >= initialNumber)
                    initialNumber = SaveAndLoadManager.Instance.game.money;
            }

            moneyText.text = "$ " + initialNumber.ToString("n0");
        }
    }
    
    // Money
    public void AddMoney(double money)
    {
        initialNumber = SaveAndLoadManager.Instance.game.money;
        SaveAndLoadManager.Instance.game.money += money;
    }

    public void DeductMoney(double money)
    {
        initialNumber = SaveAndLoadManager.Instance.game.money;
        SaveAndLoadManager.Instance.game.money -= money;
    }

    public bool isEnoughMoney(double money)
    {
        if (SaveAndLoadManager.Instance.game.money >= money)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
