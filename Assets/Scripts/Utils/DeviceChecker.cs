using UnityEngine;

public class DeviceChecker : MonoBehaviour
{
    public static bool IsEmulatorOrGoogle()
    {
        string deviceModel = SystemInfo.deviceModel.ToLower();
        string deviceName = SystemInfo.deviceName.ToLower();AndroidJavaClass osBuild;
        osBuild = new AndroidJavaClass("android.os.Build");

        string fingerPrint="";
        if (Application.platform == RuntimePlatform.Android) 
            fingerPrint = osBuild.GetStatic<string>("FINGERPRINT");

        Debug.Log(
            deviceModel + "\n" +
            deviceName + "\n" +
            fingerPrint + "\n"
        );

        return (
            deviceModel.Contains("google") ||
            deviceModel.Contains("google_sdk") ||
            deviceModel.Contains("droid4x") ||
            deviceModel.Contains("emulator") ||
            deviceModel.Contains("android sdk built for x86") ||
            deviceModel.Contains("nox") ||

            fingerPrint.StartsWith("generic") ||
            fingerPrint.Contains("google") ||
            fingerPrint.Contains("google_sdk") ||
            fingerPrint.Contains("droid4x") ||
            fingerPrint.Contains("emulator") ||
            fingerPrint.Contains("android sdk built for x86") ||
            fingerPrint.Contains("nox") ||

            deviceName.Contains("google") ||
            deviceName.Contains("google_sdk") ||
            deviceName.Contains("droid4x") ||
            deviceName.Contains("emulator") ||
            deviceName.Contains("android sdk built for x86") ||
            deviceName.Contains("nox")
        );
    } 
}
