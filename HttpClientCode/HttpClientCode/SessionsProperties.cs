using System;
using System.Runtime.CompilerServices;

internal class SessionsProperties
{
    public bool AreOnlyHTTP
    {
        get;
        set;
    }

    public bool ContainsCONNECT
    {
        get;
        set;
    }

    public SessionsProperties()
    {
    }
}