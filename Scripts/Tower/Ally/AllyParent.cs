using System;
using UnityEngine;

public class AllyParent : MonoBehaviour
{
    [SerializeField] private AllyBulletParent _bulletParent;

    public Ally Get(Ally prefab, Vector3 position)
    {
        if (prefab == null)
            throw new ArgumentNullException(nameof(prefab));

        var ally = Instantiate(prefab, position, Quaternion.identity);
        ally.WishedFire += _bulletParent.Create;

        return ally;
    }

    public void Put(Ally ally)
    {
        ally.WishedFire -= _bulletParent.Create;
        Destroy(ally.gameObject);
    }
}


