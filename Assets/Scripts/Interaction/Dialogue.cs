using UnityEngine;

[CreateAssetMenu(menuName ="Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string[] text;
    public Actor[] actor;
}
//Scriptable object that stores dialog next to the NPC who is saying it
