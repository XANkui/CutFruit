using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    [SerializeField]
    private LineRenderer lineRenderer;

	[SerializeField]
	private AudioSource audioSource;

    private bool firstMouseDown = false;
    private bool mouseDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {

            firstMouseDown = true;
            mouseDown = true;

			audioSource.Play ();
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        OnDrawLine();

        firstMouseDown = false;
    }

    private Vector3[] positions = new Vector3[10];
    private int pointCount = 0;
    private Vector3 head;
    private Vector3 last;

    private void OnDrawLine() {

        if (firstMouseDown == true) {

            pointCount = 0;
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;
			Debug.Log (last);
        }
        if (mouseDown == true)
        {

            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log (head);
            if (Vector3.Distance(head, last) > 0.01f)
            {

                SavePosition(head);
                pointCount++;
				RayCast (head);
            }

            last = head;
        }
        else {

            positions = new Vector3[10];
        }

        ChangePositions(positions);

    }

	private void RayCast(Vector3 pos){

		Vector3 posToScreen = Camera.main.WorldToScreenPoint (pos);
	
		Ray ray = Camera.main.ScreenPointToRay (posToScreen);
		RaycastHit[] hitInfos = Physics.RaycastAll (ray);

		for(int i = 0; i<hitInfos.Length; i++){

			//Destroy (hitInfos[i].collider.gameObject);
			hitInfos[i].collider.SendMessage ("OnCut",SendMessageOptions.DontRequireReceiver);
		}
	}

    /// <summary>
    /// 保存点
    /// </summary>
    /// <param name="position"></param>
    private void SavePosition(Vector3 position) {

        position.z = 0;

        if (pointCount <= 9)
        {
            for (int i = pointCount; i < 10; i++)
            {
                positions[i] = position;

            }
        }
        else {
            for (int i = 0; i < 9; i++) {
                positions[i] = positions[i + 1];
            }
            positions[9] = position;
        }
    }

    /// <summary>
    /// 设置LineRenderer的位置
    /// </summary>
    /// <param name="positions"></param>
    private void ChangePositions(Vector3[] positions) {

        lineRenderer.SetPositions(positions);
    }
}
