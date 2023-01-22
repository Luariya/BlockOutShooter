using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public float rotationSpeedX = 0f, rotationSpeedY = 0f, rotationSpeedZ = 0f;
    [SerializeField] public TMP_Text collectableAmount;
    [SerializeField] public Transform respawnPoint;
    public int amountOfCollectables = 0;

    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(
            rotationSpeedX * Time.deltaTime,
            rotationSpeedY * Time.deltaTime,
            rotationSpeedZ * Time.deltaTime
            );
        {
            collectableAmount.text = amountOfCollectables.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            amountOfCollectables++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Death")
        {
            controller.enabled = false;
            gameObject.transform.position = respawnPoint.transform.position;
            controller.enabled = true;
        }
    }
}