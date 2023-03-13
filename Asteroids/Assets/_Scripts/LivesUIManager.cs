using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUIManager : MonoBehaviour
{
    [SerializeField] private Transform _lifeTemplate;

    void Awake()
    {
        _lifeTemplate.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Player.OnHit += OnHit;
    }

    void OnDisable()
    {
        Player.OnHit -= OnHit;
    }

    void Start()
    {
        UpdateVisual();
    }

    private void OnHit()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == _lifeTemplate)
            {
                continue;
            }

            Destroy(child.gameObject);
        }

        for (int i = 0; i < Player.Instance.GetLives(); i++)
        {
            Transform lifeUITransform = Instantiate(_lifeTemplate, transform);
            lifeUITransform.gameObject.SetActive(true);
        }
    }
}
