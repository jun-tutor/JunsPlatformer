using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Debug.Log("Found a Player!");
        }else
        {
            Debug.LogError("Player Needs  to be found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        transform.position = newPosition;
    }
}
