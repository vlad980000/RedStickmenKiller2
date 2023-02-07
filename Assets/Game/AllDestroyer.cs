using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDestroyer : MonoBehaviour
{
    private void OnEnable() { PlayerPrefs.DeleteAll(); }
    private void OnDisable() { PlayerPrefs.DeleteAll(); }
}
