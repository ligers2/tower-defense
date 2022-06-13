using UnityEngine;

public class AllyView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer = null;

    private void Awake()
    {
        Disable();
    }

    public void Active()
    {
        _renderer.enabled = true;
    }

    public void Disable()
    {
        _renderer.enabled = false;
    }
}
