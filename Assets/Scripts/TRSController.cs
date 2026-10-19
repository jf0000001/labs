using UnityEngine;
using UnityEngine.UI;

public class TRSController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("PositionSliders")]
    [SerializeField] private Slider posX;
    [SerializeField] private Slider posY;
    [SerializeField] private Slider posZ;

    [Header("PositionSliders")]
    [SerializeField] private Slider rotX;
    [SerializeField] private Slider rotY;
    [SerializeField] private Slider rotZ;
    
    [Header("PositionSliders")]
    [SerializeField] private Slider scaleX;
    [SerializeField] private Slider scaleY;
    [SerializeField] private Slider scaleZ;

    void Start()
    {
        if (target == null)
        {
            return;
        }

        posX.onValueChanged.AddListener(
            x => target.position = new Vector3(x, target.position.y, target.position.z)
        );
        posX.onValueChanged.AddListener(
            y => target.position = new Vector3(target.position.x, y, target.position.z)
        );
        posX.onValueChanged.AddListener(
            z => target.position = new Vector3(target.position.x, target.position.y, z)
        );

        rotX.onValueChanged.AddListener(
            x => target.eulerAngles = new Vector3(x, target.eulerAngles.y, target.eulerAngles.z)
        );
        rotY.onValueChanged.AddListener(
            y => target.eulerAngles = new Vector3(target.eulerAngles.x, y, target.eulerAngles.z)
        );
        rotZ.onValueChanged.AddListener(
            z => target.eulerAngles = new Vector3(target.eulerAngles.x, target.eulerAngles.y, z)
        );

        scaleX.onValueChanged.AddListener(
            x => target.localScale = new Vector3(x, target.localScale.y, target.localScale.z)
        );
        scaleY.onValueChanged.AddListener(
            y => target.localScale = new Vector3(target.localScale.x, y, target.localScale.z)
        );
        scaleZ.onValueChanged.AddListener(
            z => target.localScale = new Vector3(target.localScale.x, target.localScale.y, z)
        );
    }
}
