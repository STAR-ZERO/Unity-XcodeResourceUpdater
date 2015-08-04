using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Diagnostics;

public class XcodeResourceUpdater
{

    [PostProcessBuild(9999)]
    public static void OnPostprocessBuild (BuildTarget buildTarget, string path)
    {
        UnityEngine.Debug.Log ("Path: " + path);
        UnityEngine.Debug.Log ("BuildTarget: " + buildTarget);

        if (buildTarget != BuildTarget.iOS) {
            return;
        }

        Process proc = new Process ();
        proc.StartInfo.FileName = "Assets/Editor/XcodeResourceUpdater/xcode_resource_updater";
        proc.StartInfo.Arguments = path;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.OutputDataReceived += new DataReceivedEventHandler (OutputDataHandler);
        proc.ErrorDataReceived += new DataReceivedEventHandler(ErrorDataHandler);

        proc.Start ();
        proc.BeginOutputReadLine ();
        proc.BeginErrorReadLine ();
        proc.WaitForExit (30000);
        proc.Close ();
    }

    private static void OutputDataHandler (object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!string.IsNullOrEmpty (outLine.Data)) {
            UnityEngine.Debug.LogWarning (outLine.Data);
        }
    }

    private static void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!string.IsNullOrEmpty (outLine.Data)) {
            UnityEngine.Debug.LogError (outLine.Data);
        }
    }
}
