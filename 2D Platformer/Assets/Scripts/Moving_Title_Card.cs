using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Title_Card : MonoBehaviour
{
    public float rotationTime;
    public bool coInUse;

    public bool moveRight;
    public bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!coInUse)
        {
            StartCoroutine(Swivel());
        }

        if(moveRight && !moveLeft)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + Time.deltaTime * 0.03f, transform.rotation.z, transform.rotation.w);
        }

        if(!moveRight && moveLeft)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - Time.deltaTime * 0.03f, transform.rotation.z, transform.rotation.w);
        }
    }

    public IEnumerator Swivel()
    {
        coInUse = true;
        moveRight = true;
        moveLeft = false;

        yield return new WaitForSeconds(rotationTime);

        moveRight = false;
        moveLeft = true;

        yield return new WaitForSeconds(rotationTime);

        coInUse = false;

        yield return null;
    }
}
