using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills = new List<Skill>();

    [SerializeField] private Transform _skillsPoint;

    public Transform SkillsPoint => _skillsPoint; 

    private void OnEnable()
    {
    }
}
