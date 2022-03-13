using System.Threading.Tasks;
using MyBricksApp.Core.Mvvm;
using Prism.Navigation;
using RebrickableSharp.Client;

namespace MyBricksApp.Features.Parts
{
    public class PartsViewModel : ViewModelBase, IInitializeAsync
    {
        private readonly IRebrickableClient _rebrickableClient;

        public PartsViewModel(IRebrickableClient rebrickableClient)
        {
            _rebrickableClient = rebrickableClient;
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            var colors = await _rebrickableClient.GetPartsAsync(page: 1, pageSize: 10, includeDetails: true, bricklinkId: "3001");        
        }
    }
}