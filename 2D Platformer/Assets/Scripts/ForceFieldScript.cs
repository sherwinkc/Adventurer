using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour
{
    public Skel_King_Script skel_King_Script;

    public float lifetime;
    public bool isOn = false;

    private void Awake()
    {
        skel_King_Script = FindObjectOfType<Skel_King_Script>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(skel_King_Script.squibTransform.position.x, skel_King_Script.squibTransform.position.y, skel_King_Script.squibTransform.position.z);

        if (isOn)
        {
            Destroy(gameObject);
        }
    }
}
