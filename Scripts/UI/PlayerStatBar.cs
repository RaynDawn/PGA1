using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public Image HPBar;
    public Image HPDelayBar;
    public Image GasBar;

    public Character currentCharacter;

    private void Update()
    {
        if(HPDelayBar.fillAmount > HPBar.fillAmount)
        {
            HPDelayBar.fillAmount -= Time.deltaTime;
        }
        float gasPercentage = currentCharacter.Gas / currentCharacter.MaxGas;
        GasBar.fillAmount = gasPercentage;
    }
    public void OnHPChange(float percentage)
    {
        HPBar.fillAmount = percentage;
    }
}
