using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildManager : MonoBehaviour
{
    [SerializeField] private Button backBtn;

    public static UIBuildManager Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackBtnClick);    
    }

    private void OnBackBtnClick()
    {
        UIManager.Instance.Toogle(UIType.HUD);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>().SwitchCameraMode();
    }
}
