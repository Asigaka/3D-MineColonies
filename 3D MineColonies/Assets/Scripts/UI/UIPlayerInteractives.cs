using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInteractives : MonoBehaviour
{
    [SerializeField] private Button interactiveBtn;

    private PlayerInteractive playerInteractive;

    public static UIPlayerInteractives Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        interactiveBtn.onClick.AddListener(OnInteractiveClick);
        playerInteractive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractive>();
        InteractiveBtnActive(false);
    }

    public void OnInteractiveClick()
    {
        playerInteractive.OnInteractiveClick();
    }

    public void InteractiveBtnActive(bool state)
    {
        interactiveBtn.gameObject.SetActive(state);
    }
}
