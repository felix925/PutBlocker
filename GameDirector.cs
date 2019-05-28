using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private int blockhab = 0;
    private int blocknum = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject scblocknum = GameObject.Find("Blocknum");
        GameObject scblockhab = GameObject.Find("Blockhab");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
