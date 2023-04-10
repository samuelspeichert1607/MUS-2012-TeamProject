using UnityEngine;
using Random = UnityEngine.Random;

public class CryingPO : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] cryingSounds;

    [SerializeField]
    private AudioClip[] happySounds;

    [SerializeField]
    private GameObject beginningCanvas;
    [SerializeField]
    private GameObject endingCanvas;

    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private GameObject tearParticle;

    private int partitionCount;

    private bool isSad = true;

    private void Start()
    {
        partitionCount = GetPartitionCount();
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("SmolJump", 0.0f, 0.5f);
        DecideEmotion();
    }

    private void DecideEmotion()
    {
        if (partitionCount >= 5)
        {
            Rejoice();
        }
        else
        {
            Cry();
        }
    }

    private void Rejoice()
    {
        InvokeRepeating("PlayWahey", 4.0f, 4f);
        var tearGenerators = GameObject.FindGameObjectsWithTag("TearGenerator");

        for (int i = 0; i < tearGenerators.Length; i++)
        {
            tearGenerators[i].SetActive(false);
        }

        beginningCanvas.SetActive(false);
        endingCanvas.SetActive(true);
    }

    private void Cry()
    {
        InvokeRepeating("PlayRandomCry", 4.0f, 4f);
    }

    private void PlayRandomCry()
    {
        if (partitionCount < 5)
        {
            int random = Random.Range(0, cryingSounds.Length);
            audioSource.clip = cryingSounds[random];
            audioSource.Play();
        }   
    }

    private void PlayWahey()
    {
        int random = Random.Range(0, happySounds.Length);
        audioSource.clip = happySounds[random];
        audioSource.Play();
    }

    private void SmolJump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
        rigidbody.AddForce(transform.up * 1, ForceMode.Impulse);
    }

    private int GetPartitionCount()
    {
        GameObject globalObject = GameObject.Find("GlobalObject");
        return globalObject.GetComponent<Inventory>().Items.Count;
    }

    public void AddNewNumberOfPartitions(int newNumberOfPartitions)
    {
        partitionCount += newNumberOfPartitions;
        DecideEmotion();
    }
}
