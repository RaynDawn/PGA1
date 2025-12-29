using UnityEngine;
using UnityEngine.Events;
public class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [Header("Attributes")]
    public float HP = 100;
    public float MaxHP = 100;
    public float Armor = 100;
    public float MaxArmor = 100;
    public float Gas = 100;
    public float MaxGas = 100;
    [Range(0, 10)]
    public float GasConsumption = 1f;
    public bool GasConsumptionEnabled = true;

    public UnityEvent<Character> OnHealthChange;

    public UnityEvent OnTakeDamage;

    public UnityEvent<Character> OnGasRecovery;

    private void Start()
    {
        HP = MaxHP;
        Armor = MaxArmor;
        Gas = MaxGas;
        OnHealthChange.Invoke(this);
    }
    private void FixedUpdate()
    {
        if(GasConsumptionEnabled)
        {
            Gas -= GasConsumption * Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        if(HP - damage > 0)
        {
            HP -= damage;
        }
        else
        {
            HP = 0;
            Destroy(gameObject);
        }
        OnHealthChange.Invoke(this);
    }
    public void GasRecovery(float amount)
    {
        if(Gas + amount > MaxGas)
        {
            Gas = MaxGas;
        }
        else
        {
            Gas += amount;
        }
        OnGasRecovery.Invoke(this);
    }
    public void HPRecovery(float amount)
    {
        if(HP + amount > MaxHP)
        {
            HP = MaxHP;
        }
        else
        {
            HP += amount;
        }
        OnHealthChange.Invoke(this);
    }
}
