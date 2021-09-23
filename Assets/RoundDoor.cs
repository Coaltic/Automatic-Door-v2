using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundDoor : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;

    public Vector3 StartPosition1;
    public Vector3 OpenPosition1;
    public AudioSource doorSound;

    public bool opening = false;
    public bool closing = false;


    // Start is called before the first frame update
    void Start()
    {
        StartPosition1 = door1.transform.position;
        OpenPosition1.x = door1.transform.position.x - 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            door1.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            door2.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            door3.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            door4.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            door5.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
            door6.transform.Translate(Vector3.right * Time.deltaTime, Space.Self);


            if (door1.transform.position.x < OpenPosition1.x)
            {
                doorSound.Stop();
                opening = false;
            }
        }

        if (closing)
        {
            door1.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            door2.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            door3.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            door4.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            door5.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
            door6.transform.Translate(Vector3.left * Time.deltaTime, Space.Self);

            if (door1.transform.position.x > StartPosition1.x)
            {
                doorSound.Stop();
                closing = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        doorSound.Play();
        opening = true;
        closing = false;
    }

    private void OnTriggerExit(Collider other)
    {
        doorSound.Play();
        opening = false;
        closing = true;
    }
}
