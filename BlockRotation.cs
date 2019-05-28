using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
	public float rotationspeed;
	public Vector3 gravity;
	private float timepassed;
	private Rigidbody rb;
//	private bool flag = true;
	public float movespeed;
    public bool playermove = false;
    private GameObject some;
    Player script;
    // Start is called before the first frame update
    void Start()
    {
		rb = this.GetComponent<Rigidbody>();
		rb.useGravity = false;
        some = GameObject.FindGameObjectWithTag("Player");
        script = some.GetComponent<Player>();

        //script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        script.flag = false;
    }
    // Update is called once per frame
    void Update()
    {
		if ((Input.GetKey(KeyCode.P)) && (rb.useGravity == false)){//ローテーションスピードを使用して、時間ごとに90度変更している
			timepassed += Time.deltaTime;
			if(timepassed >= rotationspeed){
				timepassed = 0.0f;
				transform.Rotate(new Vector3(0,0,90)); 
			}
		}
		if (Input.GetKey(KeyCode.X)){
			rb.useGravity = true;
			rb.AddForce(gravity,ForceMode.Acceleration);
			this.name = "trash";
//			flag = false;
            this.gameObject.layer = 13;//レイヤーによって、落下ボタンを押すまで当たり判定がかからないようにしている
            atosyori();

        }
		/*if (flag == false){
            script.flag = true;
			Destroy(this);
		}*/
		if (Input.GetKey(KeyCode.A)){
			this.transform.position -= new Vector3(movespeed,0,0);
		}
		if (Input.GetKey(KeyCode.D)){
			this.transform.position += new Vector3(movespeed,0,0);
		}
	}
    void atosyori()
    {
        script.flag = true;
        Destroy(this);
    }
}