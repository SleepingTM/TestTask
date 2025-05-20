using System;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool onGround;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Platform")) onGround = true;
    }

    private void OnTriggerEnter(Collider trigger)
    {
        string[] states = { "Dead_zone", "Trap" };

        if (states.Any(word => trigger.transform.GetComponent<MeshRenderer>().name.Contains(word, StringComparison.OrdinalIgnoreCase))) transform.position = new Vector3(-2, 3.1f, 0);
        if (states.Any(word => trigger.transform.GetComponent<MeshRenderer>().name.Contains("Finish"))) GameObject.Find("Canvas_game").transform.Find("End_UI").gameObject.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name.Contains("Platform")) onGround = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) GetComponent<Rigidbody>().linearVelocity = new Vector3(5, GetComponent<Rigidbody>().linearVelocity.y, 0);
        if (Input.GetKey(KeyCode.A)) GetComponent<Rigidbody>().linearVelocity = new Vector3(-5, GetComponent<Rigidbody>().linearVelocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space) && onGround) GetComponent<Rigidbody>().linearVelocity = new Vector3(GetComponent<Rigidbody>().linearVelocity.x, 7.5f, 0);
    }
}
