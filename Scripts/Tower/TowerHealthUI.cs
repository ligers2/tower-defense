using TMPro;
using UnityEngine;

public class TowerHealthUI : MonoBehaviour
{
    [SerializeField] private string _signature = "HP";

    [SerializeField] private TowerHealth _health = null;
    [SerializeField] private TMP_Text _text = null;

    private void OnEnable()
    {
        _health.ValueChanged += SetHealth;
        SetHealth();
    }

    private void OnDisable()
    {
        _health.ValueChanged -= SetHealth;
    }

    public void SetHealth()
    {
        _text.text = $"{Mathf.Ceil(_health.Value)}{_signature}";
    }
}


