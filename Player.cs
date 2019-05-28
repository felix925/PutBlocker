using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public float movespeed;
	public float jumphighth;
	public float timeOut;
	private float time;
	public GameObject obj;
	public GameObject block1;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
	public int blocknum = 1;
	public int blockmax;
	private Vector3 tmp = new Vector3(0.0f,0.0f,0.0f);
	private float x;
    private int[] blockhab = new int[4] {5,5,5,5};
    int zanki = 3;
    public bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("blockhab1",blockhab[0]);
        PlayerPrefs.SetInt("blockhab2", blockhab[1]);
        PlayerPrefs.SetInt("blockhab3", blockhab[2]);
        PlayerPrefs.SetInt("blockhab4", blockhab[3]);
        PlayerPrefs.SetInt("zanki", zanki);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true) { 
            playermove();
        }
		if (transform.position.y <= -4){
			this.obj.SetActive(false);
			this.obj.transform.position = new Vector3(-10,-1,0);
            zanki -= 1;
            if(zanki <= 0)
            {
                GameOver();
            }
			this.obj.SetActive(true);
		}
    }
	void playermove()
	{
		time += Time.deltaTime;
		if ((Input.GetKey(KeyCode.W))&&(time >= timeOut)){
				gameObject.GetComponent<Rigidbody>().AddForce(0,jumphighth,0);
			time = 0.0f;
			}
			if (Input.GetKey(KeyCode.D)){
				transform.position += new Vector3(movespeed,0,0);
			}
			if (Input.GetKey(KeyCode.A)){
				transform.position -= new Vector3(movespeed,0,0);
			}
		    if (Input.GetKeyDown(KeyCode.Space)){//スペース押された場合のブロック配置（ブロック番号をif文で分岐）
                if (blockhab[blocknum - 1] > 0)
                {
                    Vector3 tmp = GameObject.Find("Player").transform.position;
                    x = tmp.x;
                    x += 3.0f;
                    tmp.x = x;
                    tmp.y = 4.0f;
                    BlockInstance(blocknum, tmp);
                }
                else
                {
                Debug.Log("生成失敗");
                }
		    }
		    if (Input.GetKeyDown(KeyCode.F)){//配置ブロックの番号変更
                blocknum = BlockNumber(blocknum, blockmax);
		    }
            /*if (Input.GetKeyDown(KeyCode.P)){
            DestroyAll();
            }*/


    }

    void BlockInstance(int now,Vector3 tmp)
    {
        if (now == 1)
        {
            Instantiate(block1, tmp, Quaternion.identity);
            blockhab[0] -= 1;
            PlayerPrefs.SetInt("blockhab1", blockhab[0]);
        }
        if (now == 2)
        {
            Instantiate(block2,tmp, Quaternion.identity);
            blockhab[1] -= 1;
            PlayerPrefs.SetInt("blockhab2", blockhab[1]);
        }
        if (now == 3)
        {
            Instantiate(block3, tmp, Quaternion.identity);
            blockhab[2] -= 1;
            PlayerPrefs.SetInt("blockhab3", blockhab[2]);
        }
        if (now == 4)
        {
            Instantiate(block4, tmp, Quaternion.identity);
            blockhab[3] -= 1;
            PlayerPrefs.SetInt("blockhab4", blockhab[3]);
        }
        Debug.Log("Instanceなう");
    }

    int BlockNumber(int now, int max)
    {
        if (now < max)
        {
            now += 1;
        }
        else if (now >= max)
        {
            now -= max - 1;
        }
        Debug.Log(now);
        return (now);
    }

    void GameOver()
    {
        zanki += 5;
    }
}
