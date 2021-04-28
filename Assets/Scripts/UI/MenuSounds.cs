using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    AudioSource aS;
    private void Start() { aS = gameObject.GetComponent<AudioSource>(); }

    [Header("Settings Sounds")]
    [SerializeField] AudioClip volChange;
    [SerializeField] AudioClip openSettings;
    [SerializeField] AudioClip closeSettings;
    [SerializeField] AudioClip buttonSettings;
    public void OpenSettings() { aS.PlayOneShot(openSettings); }
    public void CloseSettings() { aS.PlayOneShot(closeSettings); }
    public void ButtonSettings() { aS.PlayOneShot(buttonSettings); }
    public void VolumeSettings() { aS.PlayOneShot(volChange); }

    [Header("Inv Sounds")]
    [SerializeField] AudioClip openInv;
    [SerializeField] AudioClip closeInv;
    [SerializeField] AudioClip cycleItem;
    [SerializeField] AudioClip useItem;
    [SerializeField] AudioClip itemReject;
    [SerializeField] AudioClip addItem;
    public void OpenInv() { aS.PlayOneShot(openInv); }
    public void CloseInv() { aS.PlayOneShot(closeInv); }
    public void CycleItemInv() { aS.PlayOneShot(cycleItem); }
    public void UseItemInv() { aS.PlayOneShot(useItem); }
    public void RejectItemInv() { aS.PlayOneShot(itemReject); }
    public void AddItemInv() { aS.PlayOneShot(addItem); }

}
