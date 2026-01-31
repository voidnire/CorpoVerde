using TMPro;
using UnityEngine;

public class CollectPrompt : MonoBehaviour
{
    [SerializeField] private TMP_Text collectPrompt;
    private float floatSpeed;
    public void Start()
    {
        floatSpeed = UnityEngine.Random.Range(0.1f, 1.5f);
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        //transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0);
        transform.position += Vector3.up * Time.deltaTime * floatSpeed;
    }

}
