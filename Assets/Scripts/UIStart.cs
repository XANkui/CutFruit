using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour {

    private Button playBtn;
    private Button soundBtn;
    private AudioSource audioSound;
    private Image soundImg;

    public Sprite[] soundImgs;


    // Use this for initialization
    void Start () {

        GetComponents();
        playBtn.onClick.AddListener(OnPlayBtn);
        soundBtn.onClick.AddListener(OnSoundBtn);
    }

    void GetComponents()
    {

        playBtn = transform.Find("PlayButton").GetComponent<Button>();
        soundBtn = transform.Find("SoundButton").GetComponent<Button>();
        audioSound = transform.Find("SoundButton").GetComponent<AudioSource>();
        soundImg = transform.Find("SoundButton").GetComponent<Image>();
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveListener(OnPlayBtn);
        soundBtn.onClick.RemoveListener(OnSoundBtn);
    }

    // Update is called once per frame
    void Update () {
		
	}

    

    private void OnPlayBtn()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    private void OnSoundBtn()
    {
        if (audioSound.isPlaying)
        {
            audioSound.Pause();
            soundImg.sprite = soundImgs[1];
        }
        else
        {
            audioSound.Play();
            soundImg.sprite = soundImgs[0];
        }
    }

}
