using BadMailForOutlook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadMailForOutlook.UnitTests
{
    [TestClass]
    public class SpamResultTests
    {
        [TestMethod]
        public void InitializeForm()
        {
            var spamCollections = SpamLibraries.GetEmptyLibrary();
            AddTestSamples(spamCollections, SpamTypes.Senders);
            AddTestSamples(spamCollections, SpamTypes.Subjects);
            AddTestSamples(spamCollections, SpamTypes.KnownBadHosts);

            var finalSpam = SpamResultsForm.DisplayForm(spamCollections);
            
        }

        private void AddTestSamples(Dictionary<string, PatternCollection> spamCollections, string spamType)
        {
            PatternCollection patterns = null;

            switch (spamType)
            {
                case SpamTypes.KnownBadHosts:
                    patterns = GetSampleKnownBadHosts();
                    break;
                case SpamTypes.Senders:
                    patterns = GetSampleSenders();
                    break;
                case SpamTypes.Subjects:
                    patterns = GetSampleSubjects();
                    break;
                default:
                    throw new NotImplementedException("Support for " + spamType + " isn't there yet");

            }

            spamCollections[spamType].AddRange(patterns);
        }

        private PatternCollection GetSampleKnownBadHosts()
        {
            var patterns = new PatternCollection
            {
                Pattern.FromText("yudo.baselunar.net"),
                Pattern.FromText("yourfastnewsnow.com"),
                Pattern.FromText("wiy19gf.ruiykmninny.com"),
                Pattern.FromText("whosdrivingthetrain.com"),
                Pattern.FromText("whitestartnewstime.com"),
                Pattern.FromText("wherere.todogualeguaychu.com"),
                Pattern.FromText("webmail.orangepledge.com"),
                Pattern.FromText("warriornewsforyou.com"),
                Pattern.FromText("waferthinnews.com"),
                Pattern.FromText("vps70.pairvps.com"),
                Pattern.FromText("vps-1051087-7735.hbscloud.com"),
                Pattern.FromText("vortex176.figuresdiabetesvalue.org"),
                Pattern.FromText("vortex175.enoughfatsbustertype.org"),
                Pattern.FromText("vortex174.nationaleconomyissue.org"),
                Pattern.FromText("vortex173.dropdresssizeover.org"),
                Pattern.FromText("vortex171.specialflowerforgift.org"),
                Pattern.FromText("vmail40.golfmnb.com"),
                Pattern.FromText("vmail39.golfmnb.com")
            };
            return patterns;
        }

        private PatternCollection GetSampleSubjects()
        {
            var patterns = new PatternCollection
            {
                Pattern.FromText("Fly to your destination for half"),
                Pattern.FromText("Effortless loss from forced induction procedure"),
                Pattern.FromText("Flexible career change for working from home"),
                Pattern.FromText("Fixing sidewalk instead of replacing it"),
                Pattern.FromText("Nursing programs \\ Training open"),
                Pattern.FromText("Did you know about Keto Diet"),
                Pattern.FromText("Drive away in a 2017 for a lot less"),
                Pattern.FromText("Intro to medical coding from home"),
                Pattern.FromText("If you think your BP is normal please see new guidelines"),
                Pattern.FromText("Screenshots who's at front-door"),
                Pattern.FromText("Get a cabin upgrade for cheap right now"),
                Pattern.FromText("Lose all you want this summer"),
                Pattern.FromText("Stay cool this summer - super easy installation"),
                Pattern.FromText("Force your body to burn flab and pounds"),
                Pattern.FromText("Great opportunity with open medical billing training"),
                Pattern.FromText("BP guidelines have docs rethinking common prescription treatment"),
                Pattern.FromText("An unchecked mole could kill you"),
                Pattern.FromText("Safe comfortable ways to get ride of skin tags"),
                Pattern.FromText("Sitting at your desk can make you gain weight"),
                Pattern.FromText("Major discounts on new cars"),
                Pattern.FromText("We can stop your snoring tongight"),
                Pattern.FromText("Efficient way to shed 1lb every other day for a month"),
                Pattern.FromText("Great deals on caribbean resorts right now"),
                Pattern.FromText("Career change options for stay-at-home parents"),
                Pattern.FromText("Know your home is safe 24/7 wherever you are"),
                Pattern.FromText("All time low prices for cruises around Europe")
            };
            return patterns;
        }

        private PatternCollection GetSampleSenders()
        {
            var patterns = new PatternCollection
            {
                Pattern.FromText("Unsold Flight Locator"),
                Pattern.FromText("Career Service Office"),
                Pattern.FromText("Ketogenic Diet"),
                Pattern.FromText("Dealer Lots Clearing"),
                Pattern.FromText("Career Builder Placements"),
                Pattern.FromText("Watching Your Front Door"),
                Pattern.FromText("Best Chevy Cars"),
                Pattern.FromText("End Snoring Forever"),
                Pattern.FromText("Career Builder In Demand Positions"),
                Pattern.FromText("Auto Service"),
                Pattern.FromText("Jennifer From Public Health"),
                Pattern.FromText("Guide To Nurse Careers"),
                Pattern.FromText("pOWER bILLS"),
                Pattern.FromText("CNN HLN Wellness Alert"),
                Pattern.FromText("Very Rapid Loss"),
                Pattern.FromText("Blood Pressure Guidelines Revamped"),
                Pattern.FromText("Daily Travel Deals"),
                Pattern.FromText("RetroCube Apps"),
                Pattern.FromText("Web MD Plus Notice"),
                Pattern.FromText("USA Today Important Messag"),
                Pattern.FromText("Discunted Cruises"),
                Pattern.FromText("Split Ductless A/C"),
                Pattern.FromText("WaterSport Getaway"),
                Pattern.FromText("Cruise Boarding Pass")
            };
            return patterns;
        }
    }
}
