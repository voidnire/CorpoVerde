using TMPro;
using UnityEngine;

public class UXController : MonoBehaviour
{
    public static UXController Instance;
    public CollectPrompt prefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateCollectPrompt(Vector3 location)
    {

        CollectPrompt collectPrompt = Instantiate(prefab, location, Quaternion.identity, transform);

    }

}
