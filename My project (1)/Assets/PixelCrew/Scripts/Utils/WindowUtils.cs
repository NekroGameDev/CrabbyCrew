﻿using UnityEditor;
using UnityEngine;

namespace PixelCrew.Scripts.Utils
{
    public static class WindowUtils 
    {
       public static void CreateWindow(string resourcePath)
        {
            var window = Resources.Load<GameObject>(resourcePath);
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            Object.Instantiate(window, canvas.transform);
        }
    }
}