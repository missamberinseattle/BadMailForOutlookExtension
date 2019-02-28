using System;
using System.Collections.Generic;

namespace BadMailForOutlook
{
    public class RuleGroupConfigMap
    {
        #region Constructors, Destructors, Initializers, and Factories
        private RuleGroupConfigMap()
        {
            _map.Add(RuleGroup.AttachedTrojans, "AttachiamentaeNonGratae.txt");
            _map.Add(RuleGroup.RejectImposters, "ApprovedFromHeaders.txt");
            _map.Add(RuleGroup.NoQuestionableBodies, "QuestionableBodies.txt");
            _map.Add(RuleGroup.RejectBadHeaders, "BadHeaders.txt");
            _map.Add(RuleGroup.RejectTabooTopics, "TabooSubjects.txt");
            _map.Add(RuleGroup.NoPoorlyChosenNames, "BadFromHeaders.txt");
            _map.Add(RuleGroup.BannedTldHosts, "BannedTLD.txt");
            _map.Add(RuleGroup.CaptureHostIgnore, "CaptureHostIgnore.txt");
            _map.Add(RuleGroup.ChameleonHostsForbidden, "ChameleonHosts.txt");
            _map.Add(RuleGroup.HostWhiteList, "HostWhiteList.txt");
            _map.Add(RuleGroup.TargetedSendLock, "TargetedPrefixes.txt");

        }

        public static RuleGroupConfigMap Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = new RuleGroupConfigMap();

                return _instance;
            }
        }
        #endregion

        #region Private Data Members
        // Singleton instance
        private static RuleGroupConfigMap _instance;

        private Dictionary<RuleGroup, string> _map = new Dictionary<RuleGroup, string>();
        #endregion

        public string GetFile(string groupName)
        {
            if (groupName == null || groupName.Length == 0)
            {
                throw new ArgumentNullException("groupName cannot be null");
            }

            RuleGroup group;

            try
            {
                group = (RuleGroup) Enum.Parse(typeof(RuleGroup), groupName);
            }
            catch (Exception ex)
            {
                throw new FormatException(groupName + " is an invalid rule name", ex);
            }

            return GetFile(group);
        }

        public string GetFile(RuleGroup group)
        {
            return _map[group];
        }
    }
}
