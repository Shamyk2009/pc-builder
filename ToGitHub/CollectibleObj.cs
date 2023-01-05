using UnityEngine;

public class CollectibleObj : MonoBehaviour
{
    public Sprite image;
    public string title;
    public string description;

    public bool isPut = false;

    [SerializeField] private GameObject PutableObjToUnlock;

    private void Update()
    {
        if (isPut)
        {
            PutableObjToUnlock.SetActive(true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.enabled = false;
        }
    }
}
