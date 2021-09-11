using Xunit;

namespace RadarrApiWrapper.IntegrationTests.Common.Helpers
{
    [CollectionDefinition(nameof(CommonHelper))]
    public class CommonHelperCollection : ICollectionFixture<CommonHelper>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
