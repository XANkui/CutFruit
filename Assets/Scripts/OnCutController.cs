using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnCutController : MonoBehaviour {

	[SerializeField]
	private GameObject halfFruit;

	private bool isCutted = false;

	public GameObject splahFlat;
	public GameObject splah;
	public GameObject fireworks;
	public AudioClip acCutFruit;

	public void OnCut() {

		if(isCutted == true){

			return;
		}

		if(gameObject.name.Contains ("Bomb")){

			Instantiate (fireworks, transform.position, Quaternion.identity);

			UIScore.Instance.RemoveScore (30);
		}else{

			for(int i = 0; i < 2; i++){

				GameObject go = Instantiate (halfFruit, transform.position, Random.rotation);
				go.GetComponent <Rigidbody>().AddForce (Random.onUnitSphere * 5f, ForceMode.Impulse);
				Instantiate (splahFlat, transform.position, Quaternion.identity);
				Instantiate (splah, transform.position, Quaternion.identity);
			}
			UIScore.Instance.AddScore (10);
		}

		AudioSource.PlayClipAtPoint (acCutFruit, transform.position);

		Destroy (gameObject);

		isCutted = true;
	}
}
