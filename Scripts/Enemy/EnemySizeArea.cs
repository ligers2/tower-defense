using UnityEngine;

public class EnemySizeArea : MonoBehaviour
{
    public Vector3 Position => _rigidbody.position;
    
    private Rigidbody _rigidbody;

    public void Init(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }
}


