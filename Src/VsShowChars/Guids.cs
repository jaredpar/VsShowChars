// Guids.cs
// MUST match guids.h
using System;

namespace VsShowChars
{
    static class GuidList
    {
        public const string guidVsShowCharsPkgString = "b2e3f7e8-cf16-419f-bbe4-1abe95c4dd6a";
        public const string guidVsShowCharsCmdSetString = "694a780c-9677-4c06-8f99-78347cb683ac";

        public static readonly Guid guidVsShowCharsCmdSet = new Guid(guidVsShowCharsCmdSetString);
    };
}