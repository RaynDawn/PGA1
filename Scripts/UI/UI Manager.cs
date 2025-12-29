using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
   public PlayerStatBar playerStatBar;
   public CharacterEventSO HealthEvent;

   private void OnEnable()
   {
    HealthEvent.OnEventRaised += OnHealthEvent;
   }
   private void OnDisable()
   {
    HealthEvent.OnEventRaised -= OnHealthEvent;
   }
   private void OnHealthEvent(Character character)
   {
     var percentage = character.HP / character.MaxHP;
     playerStatBar.OnHPChange(percentage);

     playerStatBar.currentCharacter = character;
   }
}
