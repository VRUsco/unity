using UnityEngine;
using TrafficSimulation;

public class VehicleController : MonoBehaviour
{

    WheelDrive wheelDrive;

    void Start()
    {
        wheelDrive = this.GetComponent<WheelDrive>();
    }

    void Update()
    {
        float acc = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        float brake = Input.GetKey(KeyCode.Space) ? 1 : 0;

        wheelDrive.Move(acc, steering, brake);
    }

    private void OnTriggerEnter(Collider obj)
    {
        RedLightStatus luces = FindObjectOfType<RedLightStatus>();
        SaveManager save = FindObjectOfType<SaveManager>();

        Light pointLightGreen;

        pointLightGreen = luces.transform.GetChild(1).GetComponent<Light>();

        if (obj.tag=="PeatonalBox" && pointLightGreen.enabled == true)
        {
            save.IncreaseError();
        }
    }
}
