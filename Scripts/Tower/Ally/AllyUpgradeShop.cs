using System;
using UnityEngine;

public class AllyUpgradeShop : MonoBehaviour
{
    public void StartListen(ImperfectAlly ally)
    {
        if (ally == null)
            throw new ArgumentNullException(nameof(ally));

        ally.WishedUpgrade += OnWishedUpgrade;
    }

    public void StartListen(Ally ally)
    {
        if (ally == null)
            throw new ArgumentNullException(nameof(ally));

        var imperfect = ally.GetComponent<ImperfectAlly>();
        if (imperfect)
            StartListen(imperfect);
    }

    private void OnWishedUpgrade(ImperfectAlly from, Ally toPrefab)
    {
        if (from == null)
            throw new ArgumentNullException(nameof(from));

        if (toPrefab == null)
            throw new ArgumentNullException(nameof(toPrefab));

        StopListen(from);
        var to = Instantiate(toPrefab, from.Position, Quaternion.identity);

        from.FailUpgrade += OnFailUpgrade;
        from.Upgrade += OnUpgrade;

        from.StartUpgrage(to);
    }

    private void OnFailUpgrade(ImperfectAlly from, Ally toSuspect)
    {
        if (from == null)
            throw new ArgumentNullException(nameof(from));

        if (toSuspect == null)
            throw new ArgumentNullException(nameof(toSuspect));

        from.FailUpgrade -= OnFailUpgrade;
        from.Upgrade -= OnUpgrade;
        Destroy(toSuspect.gameObject);
        StartListen(from);
    }

    private void OnUpgrade(ImperfectAlly from, Ally toSuspect)
    {
        if (from == null)
            throw new ArgumentNullException(nameof(from));

        if (toSuspect == null)
            throw new ArgumentNullException(nameof(toSuspect));

        from.FailUpgrade -= OnFailUpgrade;
        from.Upgrade -= OnUpgrade;
        Destroy(from.gameObject);
        StartListen(toSuspect);
        toSuspect.Active();
    }

    private void StopListen(ImperfectAlly ally)
    {
        if (ally == null)
            throw new ArgumentNullException(nameof(ally));

        ally.WishedUpgrade -= OnWishedUpgrade;
    }
}
