namespace Yandex.Alice.Sdk.Tests.Models
{
    using System;
    using Xunit;
    using Xunit.Abstractions;
    using Yandex.Alice.Sdk.Helpers;
    using Yandex.Alice.Sdk.Models;
    using Yandex.Alice.Sdk.Tests.TestsInfrastructure;

    public class AliceGalleryCardItemTests : BaseTests
    {
        private const string _tooLongString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras dignissim est odio, ut accumsan enim aliquam eget. Quisque odio sapien, posuere non vehicula eleifend, tincidunt eget lacus. Donec consectetur eros lectus, in interdum quam feugiat eget.";

        public AliceGalleryCardItemTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void TrimString()
        {
            var cardItem = new AliceGalleryCardItem
            {
                Title = AliceHelper.PrepareGalleryCardItemTitle(_tooLongString),
            };
            Assert.True(cardItem.Title.Length < AliceGalleryCardItem.MaxTitleLength);
            Assert.EndsWith(AliceHelper.DefaultReducedStringEnding, cardItem.Title, StringComparison.OrdinalIgnoreCase);
            TestOutputHelper.WriteLine(cardItem.Title);
        }

        [Fact]
        public void TrimStringMandatoryEnding()
        {
            var fireEmoji = char.ConvertFromUtf32(0x1F525);
            var cardItem = new AliceGalleryCardItem
            {
                Title = AliceHelper.PrepareGalleryCardItemTitle(_tooLongString, fireEmoji, AliceHelper.DefaultReducedStringEnding),
            };
            Assert.True(cardItem.Title.Length < AliceGalleryCardItem.MaxTitleLength);
            Assert.EndsWith(fireEmoji, cardItem.Title, StringComparison.OrdinalIgnoreCase);
            TestOutputHelper.WriteLine(cardItem.Title);
        }

        [Fact]
        public void MandatoryEnding()
        {
            var fireEmoji = char.ConvertFromUtf32(0x1F525);
            var cardItem = new AliceGalleryCardItem
            {
                Title = AliceHelper.PrepareGalleryCardItemTitle("IamShort", fireEmoji, AliceHelper.DefaultReducedStringEnding),
            };
            Assert.True(cardItem.Title.Length < AliceGalleryCardItem.MaxTitleLength);
            Assert.EndsWith(fireEmoji, cardItem.Title, StringComparison.OrdinalIgnoreCase);
            TestOutputHelper.WriteLine(cardItem.Title);
        }

        [Fact]
        public void TitleLenghtOverflow()
        {
            var cardItem = new AliceGalleryCardItem();
            var exception = Assert.Throws<ArgumentException>(() => cardItem.Title = _tooLongString);
            Assert.Equal(nameof(cardItem.Title), exception.ParamName);
            TestOutputHelper.WriteLine($"Error message: {exception.Message}");
        }
    }
}
