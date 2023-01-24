using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Light pointLightGreen;

    private void OnTriggerEnter(Collider obj)
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        if (obj.tag == "PlayerController" && pointLightGreen.enabled == true)
        {
            save.IncreaseError(LocalizationManager.Localize("[MapUiErrorCrosswalk]"));
        }
    }
}
