using Fiddler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

internal static class Utility
{
    public static List<string> TempFiles;

    public static List<string> TempDirectories;

    static Utility()
    {
        Utility.TempFiles = new List<string>();
        Utility.TempDirectories = new List<string>();
    }

    public static void ClearTempFilesAndDirectories()
    {
        foreach (string tempFile in Utility.TempFiles)
        {
            try
            {
                File.Delete(tempFile);
            }
            catch (Exception exception)
            {
            }
        }
        foreach (string tempDirectory in Utility.TempDirectories)
        {
            try
            {
                Directory.Delete(tempDirectory);
            }
            catch (Exception exception1)
            {
            }
        }
    }

    public static bool ContainsNullByte(byte[] byteData)
    {
        return ((IEnumerable<byte>)byteData).Any<byte>((byte t) => t == 0);
    }

    public static string CreateTempDirectory()
    {
        string str = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
        while (Directory.Exists(str))
        {
            str = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
        }
        Directory.CreateDirectory(str);
        return str;
    }

    public static SessionsProperties GetSessionsProperties(IEnumerable<Session> sessions)
    {
        SessionsProperties sessionsProperty = new SessionsProperties()
        {
            AreOnlyHTTP = true,
            ContainsCONNECT = false
        };
        SessionsProperties sessionsProperty1 = sessionsProperty;
        foreach (Session session in sessions)
        {
            if (Uri.IsWellFormedUriString(session.fullUrl, UriKind.Absolute))
            {
                string upperInvariant = (new Uri(session.fullUrl)).Scheme.ToUpperInvariant();
                if (upperInvariant != "HTTP" && upperInvariant != "HTTPS")
                {
                    sessionsProperty1.AreOnlyHTTP = false;
                }
            }
            if (!session.HTTPMethodIs("CONNECT"))
            {
                continue;
            }
            sessionsProperty1.ContainsCONNECT = true;
        }
        return sessionsProperty1;
    }

    public static string MakeNameSafe(string name)
    {
        return Regex.Replace(name, "[^a-zA-Z0-9_]+", "_", RegexOptions.Compiled);
    }

    public static bool SessionsAreHTTP(IEnumerable<Session> sessions)
    {
        bool flag;
        using (IEnumerator<Session> enumerator = sessions.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                Session current = enumerator.Current;
                if (!Uri.IsWellFormedUriString(current.fullUrl, UriKind.Absolute))
                {
                    continue;
                }
                string upperInvariant = (new Uri(current.fullUrl)).Scheme.ToUpperInvariant();
                if (!(upperInvariant != "HTTP") || !(upperInvariant != "HTTPS"))
                {
                    continue;
                }
                flag = false;
                return flag;
            }
            return true;
        }
        return flag;
    }

    public static string Times(int times, string s)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < times; i++)
        {
            stringBuilder.Append(s);
        }
        return stringBuilder.ToString();
    }
}