using UnityEngine;

public class SectionDeployer : MonoBehaviour
{
    [SerializeField] GameObject panel;
    
    public void Open()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    public void Close()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }
}
