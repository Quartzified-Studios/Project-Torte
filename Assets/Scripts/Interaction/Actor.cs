using UnityEngine;

[CreateAssetMenu(menuName ="Data/Actor")]
public class Actor : ScriptableObject
{
    public string Name;
    public Texture2D characterPortrait;
}
//Scriptable object that stores information about an NPC