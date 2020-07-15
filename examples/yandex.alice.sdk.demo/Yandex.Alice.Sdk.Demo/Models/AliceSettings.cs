using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yandex.Alice.Sdk.Demo.Models
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
