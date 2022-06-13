using UnityEngine;

public class AllyProduct : MonoBehaviour
{
    [SerializeField] private float _purchasePrice = 100f;

    public float PurchasePrice => _purchasePrice;
}
