using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 200;
    CoinCounter counter;
    void Start()
    {
        Debug.Log("Start");
        counter = FindAnyObjectByType<CoinCounter>();
    }

    void Update()
    {
        transform.position = transform.position + Vector3.forward * Time.deltaTime * speed;
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        counter.AddCoin();
        Destroy(gameObject);
    }
}
