using UnityEngine;
using System.Collections;

namespace DclickUnityAds.Api
{
    public class AdConfig
    {
        private Hashtable apiKeys = new Hashtable();
        private Hashtable unitIds = new Hashtable();

        public Hashtable ApiKeys
        {
            get
                {
                    return apiKeys;
                }
        }

        public Hashtable UnitIds
        {
            get
                {
                    return unitIds;
                }
        }

        public AdConfig()
        {
        }

        public void SetApiKey(AdNetwork adNetwork, string apiKey) {
            apiKeys[adNetwork] = apiKey;
        }

        public string GetApiKey(AdNetwork adNetwork) {
            return (string) apiKeys[adNetwork];
        }

        public void SetUnitId(AdNetwork adNetwork, AdType adType, string unitId) {
            if (!unitIds.ContainsKey(adNetwork)) {
                unitIds[adNetwork] = new Hashtable();
            }

            Hashtable network = (Hashtable) unitIds[adNetwork];
            network[adType] = unitId;
        }

        public string GetUnitId(AdNetwork adNetwork, AdType adType) {
            Hashtable network = (Hashtable) unitIds[adNetwork];
            return (string) network[adType];
        }
    }
}
