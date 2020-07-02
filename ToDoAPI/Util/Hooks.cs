using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace SbAutomation.Common
{
    [Binding]
    public class Hooks
    {
        //region Define Private Variables
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly ScenarioContext sContext;
        private readonly FeatureContext fContext;
        //endregion

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            sContext = scenarioContext;
            fContext = featureContext;
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentV3HtmlReporter(@"C:\Users\Documents\Visual Studio 2017\Projects\ToDoAPI\TestReport.html");
            htmlReporter.Config.Theme = Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext _featurecontex)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(_featurecontex.FeatureInfo.Title);

        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext sContext)
        {
            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(sContext.ScenarioInfo.Title);

        }


        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext sContext)
        {
            //Getting Step Type
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //Check for Pass cases
            if (sContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>("Given", ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>("When", ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>("Then", ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>("And", ScenarioStepContext.Current.StepInfo.Text);
            }

            //Check for Fail cases
            else if (sContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>("Given", ScenarioStepContext.Current.StepInfo.Text).Fail(sContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>("When", ScenarioStepContext.Current.StepInfo.Text).Fail(sContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>("Then", ScenarioStepContext.Current.StepInfo.Text).Fail(sContext.TestError.Message);
            }
        }

    }
}