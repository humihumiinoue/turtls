using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    public AudioClip sound1;            //�G�j��
    public AudioClip sound2;            //�M��
    public AudioClip sound3;            //����
    public AudioClip sound4;            //���G
    public AudioClip sound5;            //�X�s�[�h�_�E��
    public AudioClip sound6;            //�X�s�[�h�A�b�v
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(sound1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Already")
        {
            audioSource.PlayOneShot(sound3);
        }
        if (other.gameObject.tag == "BORNUS")
        {
            audioSource.PlayOneShot(sound2);
        }
        if (other.gameObject.tag == "Confusion")
        {
            audioSource.PlayOneShot(sound3);
        }
        if (other.gameObject.tag == "Invisible")
        {
            audioSource.PlayOneShot(sound4);
        }
        if (other.gameObject.tag == "SpeedDown")
        {
            audioSource.PlayOneShot(sound5);
        }
        if (other.gameObject.tag == "SpeedUp")
        {
            audioSource.PlayOneShot(sound6);
        }

    }
}
