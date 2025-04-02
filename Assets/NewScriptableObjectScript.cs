using UnityEngine;

[CreateAssetMenu(fileName = "NewUser", menuName = "ScriptableObjects/Users", order = 1)]
public class User: ScriptableObject
{
    public string pName;
    public int health;
}