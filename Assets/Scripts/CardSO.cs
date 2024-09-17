using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
    public int cost;
}