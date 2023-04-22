using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Lock 오브젝트가 파괴되면 오디오를 재생합니다.
        if (gameObject.transform.Find("Lock") == null)
        {
            audioSource.Play();
        }
    }
}
