using System;
using UnityEngine;

public class AllyShopInput : MonoBehaviour
{
    [SerializeField] private float _distance = 100f;
    [SerializeField] private LayerMask _floor = new();

    [SerializeField] private Camera _camera = null;
    [SerializeField] private Ally _ally = null;
    [SerializeField] private AllyShop _shop = null;

    private Ray Mouse => _camera.ScreenPointToRay(Input.mousePosition);

    private Vector3 _point;

    private void FixedUpdate()
    {
        if (_shop.HasSpawned && _shop.IsPlaceNotStarted)
            _shop.MovePreview(_point);
    }

    private void Update()
    {
        if (Physics.Raycast(Mouse, out var hit, _distance, _floor))
            _point = hit.point;

        if (Input.GetMouseButtonDown(0) && _shop.HasNotSpawned)
            _shop.Spawn(_ally, _point);

        if (Input.GetMouseButtonDown(1) && _shop.HasSpawned && _shop.IsPlaceNotStarted)
            _shop.StartPlace();
    }
}
