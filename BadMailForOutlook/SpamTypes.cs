using System;
using System.Collections.Generic;
using System.IO;

namespace BadMailForOutlook
{
    public class SpamTypes
    {
        public const string Senders = "Senders";
        public const string Subjects = "Subjects";
        public const string ApprovedFromHeaders = "Approved From Headers";
        public const string AttachmentSpam = "Attachment";
        public const string BadHeaders = "Bad Headers";
        public const string BannedTlds = "Banned TLD";
        public const string CaptureHostIgnore = "Do Not Capture Hosts";
        public const string ChameleonHosts = "Farm Hosts";
        public const string HostWhiteList = "HostWhiteList";
        public const string KnownBadHosts = "Known Bad Hosts";
        public const string KnownGoodHosts = "Known Good Hosts";
        public const string MessageBodies = "Message Bodies";
        public const string SenderWhiteList = "Sender White List";
        public const string SuspectHeaders = "Suspect Headers";
        public const string TargetedPrefixes = "Targeted Prefixes";

    }
}
