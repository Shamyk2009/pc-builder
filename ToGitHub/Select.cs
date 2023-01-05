using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image icon;
    [SerializeField] private Text title;
    [SerializeField] private Text description;

    [Header("Dependencies")]
    [SerializeField] private Transform mainCamera;

    private RaycastHit hit;

    private bool isPutable = false;

    private void Update()
    {
        Check();

    }

    private void Check()
    {
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Collectible")
            {
                GameObject obj = hit.collider.gameObject;
                CollectibleObj collectibleObj = obj.GetComponent<CollectibleObj>();

                icon.sprite = collectibleObj.image;
                title.text = collectibleObj.title;
                description.text = collectibleObj.description;

                infoPanel.SetActive(true);
            }
            else
            {
                infoPanel.SetActive(false);
            }

            if (hit.collider.gameObject.tag == "Putable")
            {
                isPutable = true;
            }
            else
            {
                isPutable = false;
            }
        }
        else
        {
            infoPanel.SetActive(false);
            isPutable = false;
        }
    }
}
