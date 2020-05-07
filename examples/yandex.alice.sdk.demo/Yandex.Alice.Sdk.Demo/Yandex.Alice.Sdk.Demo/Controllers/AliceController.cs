using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Yandex.Alice.Sdk.Helpers;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AliceController : ControllerBase
    {
        [HttpPost]
        [Route("/alice")]
        public IActionResult Get(AliceRequest aliceRequest)
        {
            try
            {
                string tts = "XH9vWSTYNdADOjPYVKoKcjZS0PaTYqXpkHqFUry3fY0q2bm1FzvyPhW6IC8ca11Cpdv0H57XhLI5qsGcHWyBOEi93P325MYNIGHYliYYa4zDc1qCX1eouDAvkDBpxgH6SHhSJzGfJuQ1K60lYTTqmQtchBeDYf0dcCxP6DbCXvPXKrXICGCUliXivtUfYlGUXxW6sdodFUElMhKGfdU9ypMbkyoZ3fXFj26LgMUAFXA7CMNffVSs6d45GOgnDFX5o2BiCvmA65p3tMjKiU0rV068kJOR9567ckQzBz5zNm6HWnz2pvgE9WW3VouEmVEiWY4VVlHLokRCcE2SV63KTttwg3vPJMS9AHfgyaoC7SLQuKFbkx0PQD6P9HKaPXVc8VKMKWLHgqYER24vfk858M3bDmaUNMb4V1aPMX0DQbhtsE2km508KeI0GX21Ha1Z0eCAOXMZrRySAccPNUmm4QGP3ObmuMSYXxHXGDlWUqywuaw67XIYEdZN81UkPlfCG09Oa0a08I6Uu77ajAqzONEk8gQYeqpVPLcxqdbwjXEpiK7xjksOUPYhSZgaHQUbZ05NCGUYJUTimA4TVJOTfz9H5xB6TYxCFn1pjr5R98oXhtwtiRM7KzrHppOAC1dPUotms24i5YlMTmuzMabls4V9FFR58hMTWfmdaqroirExgYwoDZ2r8rNpVR47ITLPdhkhhfjO2hjps0J2Xbj6IyFBBvkAAKSoSkSbfvCcgzkpJ9eHvzCsSCHjE86Vmeh3eXzm20TOwr0bMJ9Dwczxoap01MJevOkWQ4OmQXcCnHVjUAP6BsgHmN2yZLVCqg9FUn9fJIGfN9jVJBdz1qivBpqKsS2Yv2mN4p7GVkkwcgMDnGVxislnR3vCwhf0YNkQ24kAJOvhGVAHhcMKBCF8LmOlvWN04pDvSiZwWUrS4cnHxwJrm6qtkvFxyw4N1zd74wmXH1VuIf6YEPMoo5mo2WmaQdCOZwPqmfXIHLyLFl1LRjOGthwS0wqXO0aoFhHr";
                tts += AliceTtsHelper.GetSpeakerTag("asdsfsfd");
                var response = new AliceResponse(aliceRequest, string.Empty, tts);
                return Ok(response);
            }
            catch(Exception e)
            {
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Content(e.ToString());
            }
        }
    }
}
