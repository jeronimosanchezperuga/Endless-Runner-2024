
using UnityEngine;

public class SetVariantes : MonoBehaviour
{
    public GameObject[] variants;

    public void ActivateRandomVariant()
    {
        DeactivateAllVariants();
        variants[Random.Range(0,variants.Length)].SetActive(true);
    }

    private void DeactivateAllVariants()
    {
        foreach (var variant in variants)
        {
            variant.SetActive(false);
        }
    }
}
