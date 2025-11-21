// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under The Standard Software License (TSSL).
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using ADotNet.Clients.Builders;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

namespace PrettyBlazor.Infrastructure.Build
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
            string directoryPath = Path.GetDirectoryName(buildScriptPath);

            if (Directory.Exists(directoryPath) is false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            GitHubPipelineBuilder.CreateNewPipeline()
                .SetName("Build & Test PrettyBlazor")
                    .OnPush("master")
                        .OnPullRequest("master")
                            .AddJob("build", job => job
                                .WithName("Build")
                                .RunsOn(BuildMachines.UbuntuLatest)
                                .AddCheckoutStep("Check Out")

                                .AddSetupDotNetStep(
                                    version: "9.0.101",
                                    includePrerelease: true)

                                .AddRestoreStep()
                                .AddBuildStep()
                                .AddTestStep())

                .SaveToFile(buildScriptPath);
        }
    }
}
