using UnityEditorInternal;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController Instance;
    public DamageNumber prefab;

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

    public void CreateNumber(float value, Vector3 location, Color color)
    {

        DamageNumber damageNumber = Instantiate(prefab, location, Quaternion.identity, transform);

        damageNumber.SetValue(value);
        damageNumber.SetColor(color);

    }
}
