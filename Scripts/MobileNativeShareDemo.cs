﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile;

namespace EasyMobile.Demo
{
    public class MobileNativeShareDemo : MonoBehaviour
    {
        public Image clockRect;
        public Text clockText;

        // Screenshot names don't need to include the extension (e.g. ".png")
        string TwoStepScreenshotName = "EM_Screenshot";
        string OneStepScreenshotName = "EM_OneStepScreenshot";
        string TwoStepScreenshotPath;
        string sampleMessage = "This is a sample sharing message #sampleshare";
        string sampleText = "Hello from Easy Mobile!";
        string sampleURL = "http://u3d.as/Dd2";

        void OnEnable()
        {
            ColorChooser.colorSelected += ColorChooser_colorSelected;
        }

        void OnDisable()
        {
            ColorChooser.colorSelected -= ColorChooser_colorSelected;
        }

        void ColorChooser_colorSelected(Color obj)
        {
            clockRect.color = obj;
        }

        void Update()
        {
            clockText.text = System.DateTime.Now.ToString("hh:mm:ss");
        }

        public void ShareText()
        {
            MobileNativeShare.ShareText(sampleText);
        }

        public void ShareURL()
        {
            MobileNativeShare.ShareURL(sampleURL);
        }

        public void SaveScreenshot()
        {
            StartCoroutine(CRSaveScreenshot());
        }

        public void ShareScreenshot()
        {
            if (!string.IsNullOrEmpty(TwoStepScreenshotPath))
            {
                MobileNativeShare.ShareImage(TwoStepScreenshotPath, sampleMessage);
            }
            else
            {
                MobileNativeUI.Alert("Alert", "Please save a screenshot first.");
            }
        }

        public void OneStepSharing()
        {
            StartCoroutine(CROneStepSharing());
        }

        IEnumerator CRSaveScreenshot()
        {
            yield return new WaitForEndOfFrame();

            TwoStepScreenshotPath = MobileNativeShare.SaveScreenshot(TwoStepScreenshotName);

            MobileNativeUI.Alert("Alert", "A new screenshot was saved at " + TwoStepScreenshotPath);
        }

        IEnumerator CROneStepSharing()
        {
            yield return new WaitForEndOfFrame();

            MobileNativeShare.ShareScreenshot(OneStepScreenshotName, sampleMessage);
        }
    }
}
    