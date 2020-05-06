using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.Models
{
    public class AliceResponseModelTests
    {
        private readonly string _tooLongString;
        public AliceResponseModelTests()
        {
            _tooLongString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras dignissim est odio, ut accumsan enim aliquam eget. Quisque odio sapien, posuere non vehicula eleifend, tincidunt eget lacus. Donec consectetur eros lectus, in interdum quam feugiat eget. Donec egestas tellus eu leo pharetra, sed dignissim justo malesuada. Duis eu elit at libero feugiat interdum. Suspendisse porttitor consequat fringilla. Nam in venenatis quam. Morbi tincidunt velit justo, eget mattis nunc bibendum a. Vivamus in nisi quam. Quisque scelerisque nisl ac mollis vestibulum. Fusce scelerisque, turpis sed placerat accumsan, tellus dolor ultrices ex, non efficitur ex sapien quis est. Phasellus ut ex quis ante dictum sodales. Donec vitae luctus libero. Mauris et ante egestas ante sodales commodo nec id metus. Duis vel rutrum neque, a volutpat nunc.Aliquam vel luctus ex. Cras sed eros tempor risus consequat auctor at non elit. Vivamus nec aliquet neque, quis tincidunt massa. Phasellus congue, velit vel venenatis pulvinar, urna nisl volutpat quam, nec iaculis felis enim eleifend velit.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Nullam placerat porta sapien, sit amet imperdiet augue euismod non.Sed vehicula libero finibus, aliquam diam a, sodales ligula.Aliquam sed euismod lorem, in porttitor ligula. In vestibulum diam ut libero dictum ultrices.Nullam et diam iaculis, faucibus erat sit amet, accumsan nulla. Vestibulum vehicula sodales elit, sed consequat dui mattis ut. Duis sollicitudin elementum sodales.Proin quis felis porta, tincidunt ipsum eget, imperdiet tortor.Morbi varius purus in mi lobortis lacinia.Donec pellentesque turpis eget ipsum tempus rutrum.Curabitur eget neque nec justo elementum porttitor sit amet at nunc.Sed placerat sed turpis a iaculis. Vivamus ut iaculis velit. Vestibulum nec nunc diam. Quisque quis elit justo. Suspendisse pretium non eros ut maximus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Fusce urna massa, dapibus id turpis dapibus, dapibus varius ex. Integer sed fermentum quam. Sed nisl ligula, maximus vitae efficitur sit amet, ultricies ut justo.Suspendisse lacinia massa eget placerat posuere.Quisque imperdiet ante vel ligula ornare, ut aliquam elit consectetur.Praesent interdum ipsum in tincidunt placerat. Ut vitae vestibulum urna. Nam efficitur nibh nec nisi tincidunt dictum.Maecenas sed venenatis ligula. Ut sed orci imperdiet, consectetur magna nec, sollicitudin massa.Pellentesque at lectus urna. Nunc ipsum lectus, molestie tempus euismod et, scelerisque et orci. Curabitur in eros nec lectus consectetur gravida.Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Donec pulvinar eget felis at varius. Maecenas feugiat massa at efficitur ullamcorper.";
        }

        [Fact]
        public void TextMaxLength()
        {
            var model = new AliceResponseModel();
            Assert.Throws<ArgumentException>(() => model.Text = _tooLongString);
        }

        [Fact]
        public void TtsMaxLength()
        {
            var model = new AliceResponseModel();
            Assert.Throws<ArgumentException>(() => model.Tts = _tooLongString);
        }
    }
}
