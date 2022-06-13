using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private float _secondsDelay = 7f;

    [SerializeField] private EnemyQueue _queue = null;
    [SerializeField] private List<Wave> _waves = new();

    private float _expiredSeconds;
    private int _waveIndex;

    private void Awake()
    {
        _waveIndex = -1;
        _expiredSeconds = 10;
    }

    private void Update()
    {
        _expiredSeconds += Time.deltaTime;
        if (_expiredSeconds >= _secondsDelay && _waves.Count > _waveIndex + 1)
        {
            _expiredSeconds = 0;
            StartNext();
        }
    }

    private void StartNext()
    {
        _waveIndex++;
        var wave = _waves[_waveIndex];
        _queue.Put(wave.Enemies);
    }
}
