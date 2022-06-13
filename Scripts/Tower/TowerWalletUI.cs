using TMPro;
using UnityEngine;

public class TowerWalletUI : MonoBehaviour
{
    [SerializeField] private string _signature = "$";

    [SerializeField] private TowerWallet _wallet = null;
    [SerializeField] private TMP_Text _text = null;

    private void OnEnable()
    {
        _wallet.MoneyChanged += SetMoney;
        SetMoney();
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= SetMoney;
    }

    public void SetMoney()
    {
        _text.text = $"{Mathf.Floor(_wallet.Money)}{_signature}";
    }
}


