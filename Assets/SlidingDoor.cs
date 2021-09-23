using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 leftStartPosition;
    public Vector3 leftPosition;
    public Vector3 rightStartPosition;
    public Vector3 rightPosition;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public bool opening = false;
    public bool closing = false;

    public AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        leftStartPosition = leftDoor.transform.localPosition;
        rightStartPosition = rightDoor.transform.localPosition;
        leftPosition.x = leftStartPosition.x - leftDoor.transform.localScale.x;
        rightPosition.x = rightStartPosition.x + rightDoor.transform.localScale.x;
        leftStartPosition.y = 0;
        rightStartPosition.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            leftDoor.transform.Translate(leftPosition * Time.deltaTime);
            rightDoor.transform.Translate(rightPosition * Time.deltaTime);

            if (leftDoor.transform.localPosition.x < leftPosition.x)
            {
                doorSound.Stop();
                opening = false;
            }
        }

        if (closing)
        {
            leftDoor.transform.Translate(-leftStartPosition * Time.deltaTime);
            rightDoor.transform.Translate(-rightStartPosition * Time.deltaTime);

            if (leftDoor.transform.localPosition.x > leftStartPosition.x)
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
