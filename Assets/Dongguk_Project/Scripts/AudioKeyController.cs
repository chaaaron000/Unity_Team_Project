using UnityEngine;

public class AudioKeyController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Lock 오브젝트가 파괴되면 오디오를 재생합니다.
        if (!GameObject.Find(gameObject.name+ "/Prism"))
        {
            audioSource.enabled =true;
            //audioSource.Play();
        }
        if(!GameObject.Find(gameObject.name+ "/Cube"))
        {
            audioSource.enabled =true;
            //audioSource.Play();
        }
        if(!GameObject.Find(gameObject.name +"/Sphere"))
        {
            audioSource.enabled =true;
            //audioSource.Play();
        }
    }
}
