using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [Header("水果预设")]
    public GameObject[] fruits;

    [Header("炸弹预设")]
    public GameObject bomb;

	[SerializeField]
	private AudioSource audioSource;

    private float spwanTime = 3.0f;
    private float timer;
    private bool isPlaying = true;
    private int ZTmp = 0;

    // Use this for initialization
    void Start () {

        timer = spwanTime;
	}
	
	// Update is called once per frame
	void Update () {

        if (isPlaying == false) {

            return;
        }

        timer += Time.deltaTime;
        if (timer >= spwanTime) {

            timer -= spwanTime;

            int count = Random.Range(1, 5);
            for (int i = 0;i <count; i++) {

                Spwan(true);
            }

            int randomNum = Random.Range(0, 100);
            if (randomNum > 75) {

                Spwan(false);
            }

			audioSource.Play ();
        }
	}

    private void Spwan(bool isFruit)
    {
        //x范围 -7，7
        //y范围 transform.position.y
        float x = Random.Range(-7, 7);
        float y = transform.position.y;
        int index = Random.Range(0, fruits.Length);

        GameObject go;
        if (isFruit == true) {

            go = Instantiate(fruits[index], new Vector3(x, y, ZTmp), Random.rotation);
        }
        else
        {
            go = Instantiate(bomb, new Vector3(x, y, ZTmp), Random.rotation);
        }

        if (ZTmp <= -10)
        {
            ZTmp = 0;
        }

        ZTmp -= 2;
        print(ZTmp);

        Vector3 velocity = new Vector3(-x * Random.Range(0.5f, 0.8f), -Physics.gravity.y * Random.Range(1.2f, 1.5f), 0);
        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
    }
}
