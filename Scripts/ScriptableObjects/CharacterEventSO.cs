using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CharacterEventSO", menuName = "Scriptable Objects/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<Character> OnEventRaised;
    public void RaiseEvent(Character character)
    {
        OnEventRaised?.Invoke(character);
    }
}
