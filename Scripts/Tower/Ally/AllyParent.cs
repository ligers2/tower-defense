using System;
using UnityEngine;

public class AllyParent : MonoBehaviour
{
    public Ally Get(Ally prefab, Vector3 position)
    {
        if (prefab == null)
            throw new ArgumentNullException(nameof(prefab));

        return Instantiate(prefab, position, Quaternion.identity);
    }
}


