using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController Player;
    public Vector3 initialPos;
    public bool teleport = false;

    void Start()
    {
        initialPos = Player.GetComponent<Transform>().position;
        Debug.Log(initialPos);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            teleport = true;

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            teleport = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Player.transform.position = new Vector3(-21f, 24f, -22.8f);
        if (teleport)
            Player.gameObject.transform.position = initialPos;
        //Debug.Log(Player.transform.position);
    }
}