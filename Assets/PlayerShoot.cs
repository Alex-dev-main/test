using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bolt;

    private void Start()
    {
        bolt = Resources.Load("bolt") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !DialogueSystem.Instance.isInDialogue)
        {
            GameObject projectile = Instantiate(bolt) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 40;
        }
    }
}
