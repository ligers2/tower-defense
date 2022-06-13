using UnityEngine;

public class TowerWork : MonoBehaviour
{
    [SerializeField] private float _startSalary = 10f;
    [SerializeField] private float _secondsDelay = 4f;

    [SerializeField] private TowerWallet _wallet = null;

    private Salary _salary;
    private float _expiredSeconds;

    private void Awake()
    {
        _salary = new Salary(_startSalary);
    }

    private void Update()
    {
        _expiredSeconds += Time.deltaTime;
        if (_expiredSeconds >= _secondsDelay)
        {
            _expiredSeconds = 0;
            Earn();
        }
    }

    private void Earn()
    {
        _wallet.Earn(_salary);
    } 
}


