using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameManager : MonoBehaviour
{
    public float flameTime, flameTurnOffTime, flameStartTime;
    public GameObject flame_1, flame_2, flame_3, flame_4, flame_5, flame_6;
    public GameObject bird_1, bird_2, bird_3, bird_4, bird_5;

    public Skel_King_Controller skel_King_Controller;

    public void Awake()
    {
        skel_King_Controller = GetComponent<Skel_King_Controller>();

        flame_1.SetActive(false);
        flame_2.SetActive(false);
        flame_3.SetActive(false);
        flame_4.SetActive(false);
        flame_5.SetActive(false);
        flame_6.SetActive(false);

        bird_1.SetActive(false);
        bird_2.SetActive(false);
        bird_3.SetActive(false);
        bird_4.SetActive(false);
        bird_5.SetActive(false);
    }


    void Start()
    {

    }


    void Update()
    {

    }

    public IEnumerator CreateFlamesCo()
    {

        yield return new WaitForSeconds(flameStartTime);

        flame_1.SetActive(true);

        yield return new WaitForSeconds(flameTime);

        flame_2.SetActive(true);

        yield return new WaitForSeconds(flameTime);

        flame_3.SetActive(true);

        yield return new WaitForSeconds(flameTime);

        flame_4.SetActive(true);

        yield return new WaitForSeconds(flameTime);

        flame_5.SetActive(true);

        yield return new WaitForSeconds(flameTime);

        flame_6.SetActive(true);

        bird_1.SetActive(true);
        bird_2.SetActive(true);
        bird_3.SetActive(true);
        bird_4.SetActive(true);
        bird_5.SetActive(true);

        yield return new WaitForSeconds(flameTurnOffTime);

        flame_1.SetActive(false);
        flame_2.SetActive(false);
        flame_3.SetActive(false);
        flame_4.SetActive(false);
        flame_5.SetActive(false);
        flame_6.SetActive(false);

        skel_King_Controller.startFlamesOnce = true;
    }
}
