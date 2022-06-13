using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    private List<ISourceTarget> _sources;

    private void Awake()
    {
        _sources = new();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var source = collider.GetComponent<ISourceTarget>();
        if (source != null)
            Add(source);
    }

    private void OnTriggerExit(Collider collider)
    {
        var source = collider.GetComponent<ISourceTarget>();
        if (source != null)
            Remove(source);
    }

    private void OnDisable()
    {
        RemoveAll();
    }

    private void OnDestroy()
    {
        RemoveAll();
    }

    private void RemoveAll()
    {
        var sources = _sources.ToArray();
        foreach (var source in sources)
            Remove(source);
    }

    private void Add(ISourceTarget source)
    {
        _sources.Add(source);
        source.Enter(this);
    }

    private void Remove(ISourceTarget source)
    {
        _sources.Remove(source);
        source.Exit(this);
    }
}


