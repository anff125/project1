using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Card_FireBall : MonoBehaviour, ICardUsage
{
    public void Use()
    {
        Debug.Log("FireBall Card Used");

    }
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10f);
    }
}