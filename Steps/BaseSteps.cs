﻿using Aquality.Selenium.Core.Logging;
using System.Runtime.CompilerServices;

namespace VKAPI.Steps
{
    public class BaseSteps
    {
        private static Logger Logger => Logger.Instance;

        protected void LogStep([CallerMemberName] string stepInfo = "") => LogStep(stepInfo, stepType: "Action");

        protected void LogAssertion([CallerMemberName] string stepInfo = "") => LogStep(stepInfo, stepType: "Assertion");

        protected void LogPrecondition([CallerMemberName] string stepInfo = "") => LogStep(stepInfo, stepType: "Precondition");

        protected void LogError(string description, Exception exception) => Logger.Fatal($"Fatal: {description}", exception);

        private void LogStep(string stepInfo, string stepType)
        {
            var shift = new string('#', 10);
            Logger.Info($"{shift} {stepType} {shift} {Environment.NewLine}{GetType().Name}: {stepInfo}");
        }
    }
}
