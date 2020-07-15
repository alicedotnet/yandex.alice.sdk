using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models
{
    public class AliceSettings
    {
        public Guid SkillId { get; set; }

        public AliceSettings(string skillId)
        {
            SkillId = Guid.Parse(skillId);
        }
    }
}
