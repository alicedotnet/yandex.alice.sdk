namespace Yandex.Alice.Sdk.Demo.Models
{
    using System;

    public class AliceSettings
    {
        public Guid SkillId { get; set; }

        public AliceSettings(string skillId)
        {
            SkillId = Guid.Parse(skillId);
        }
    }
}
