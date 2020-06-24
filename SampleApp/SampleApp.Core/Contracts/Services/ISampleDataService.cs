using System.Collections.Generic;
using System.Threading.Tasks;
using SampleApp.Core.Models;

namespace SampleApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleCompany>> GetWebApiSampleDataAsync();

        Task<IEnumerable<SampleOrder>> GetDataGridAsync();

        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();
    }
}
