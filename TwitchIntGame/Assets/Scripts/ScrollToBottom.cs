using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrollToBottom : MonoBehaviour
{
    ScrollView scrollView;
    void Start()
    {
        scrollView = GetComponent<ScrollView>();
    }

    void Update()
    {
        scrollView.scrollOffset = scrollView.contentContainer.layout.max - scrollView.contentViewport.layout.size;
    }
}
