using System;

namespace TestData.Environments
{
    [Serializable]
    public enum Environments
    {
        DEV, DEV2, QA, PREPROD, PROD
    }

    [Serializable]
    public enum EnvironmentTypes
    {
        DS, APIM
    }
}
