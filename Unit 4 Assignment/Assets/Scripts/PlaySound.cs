using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip powerUp;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(powerUp);

        Invoke("DeleteMe", 0.4f);
    }

    private void DeleteMe(){
        Destroy(this.gameObject);
    }
}
