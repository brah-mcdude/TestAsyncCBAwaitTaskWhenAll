using System;
using System.Threading.Tasks;
using Xunit;

namespace TestAsyncCBAwaitTaskWhenAll
{
    public class UnitTest1
    {
        static Task ExpectAsync(Func<Task> actionAsync)
        {
            return Task.Run(actionAsync);
        }

        static async Task ExpectLogNoWarningsNorErrors2(Func<Task> actionAsync)
        {
            await ExpectAsync(actionAsync: async () =>
                {
                    await actionAsync();
                });
        }

        [Fact]
        public async Task Test1()
        {
            await ExpectLogNoWarningsNorErrors2(async () =>
            {
                await Count();
            });
        }

        static private async Task Count()
        {
            await Parallel
                .ForEachAsync(new int[] { 1, 2, 3 },
                async (x, y) =>
                await Test(x));
        }

        static private async Task Test(int x)
        {
            await Task.Delay(1000);
            Assert.Equal(1, x);
        }
    }
}