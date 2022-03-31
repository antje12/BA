using ClassLibrary.Classes;
using ClassLibrary.Interfaces;
using JobService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers;

[ApiController]
[Route("[controller]")]
public class JobServiceController : ControllerBase, IJobService
{
    private readonly ILogger<JobServiceController> _logger;
    private readonly IDataProvider _dataProvider;

    public JobServiceController(ILogger<JobServiceController> logger, IDataProvider dataProvider)
    {
        _logger = logger;
        _dataProvider = dataProvider;
    }

    [HttpGet("ListCategories")]
    public IEnumerable<Category> ListCategories()
    {
        return _dataProvider.ListCategories();
    }
    
    [HttpPost("CreateJob")]
    public Job? CreateJob([FromBody] Job job)
    {
        return _dataProvider.CreateJob(job);
    }
    
    [HttpGet("GetJobById/{id}")]
    public Job? GetJobById(Guid id)
    {
        return _dataProvider.GetJob(id);
    }

    [HttpPost("ListJobs")]
    public IEnumerable<Job> ListJobs([FromBody] Filter filter)
    {
        return _dataProvider.ListJobs(filter);
    }

    [HttpGet("ListJobsByUser/{id}")]
    public IEnumerable<Job> ListJobsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("ListJobsByIDs")]
    public IEnumerable<Job> ListJobsByIDs(IEnumerable<Guid> jobIds)
    {
        throw new NotImplementedException();
    }

    [HttpPut("UpdateJob")]
    public Job? UpdateJob([FromBody] Job job)
    {
        return _dataProvider.UpdateJob(job);
    }

    [HttpDelete("DeleteJobById/{id}")]
    public bool DeleteJobById(Guid id)
    {
        return _dataProvider.DeleteJob(id);
    }
}
