namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

using System;

public class AliceSettings
{
    public Guid SkillId { get; }

    public AliceSettings(string skillId)
    {
        SkillId = Guid.Parse(skillId);
    }
}