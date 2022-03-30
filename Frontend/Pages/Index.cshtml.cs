﻿using ClassLibrary.Classes;
using ClassLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUserService _userService;
    private readonly IJobService _jobService;
    private readonly IOfferService _offerService;

    public IEnumerable<User> Users { get; private set; }
    public IEnumerable<Job> Jobs { get; private set; }
    public IEnumerable<Offer>? Offers { get; private set; }
    
    public IndexModel(ILogger<IndexModel> logger, IUserService userService, IJobService jobService, IOfferService offerService)
    {
        _logger = logger;
        _userService = userService;
        _jobService = jobService;
        _offerService = offerService;
    }

    public void OnGet()
    {
        Users = _userService.Get();
        Jobs = _jobService.Get();
        Offers = TestOffers();
    }

    // Create test offer and load it afterwards
    IEnumerable<Offer>? TestOffers()
    {

        _offerService.Create(new Offer(
                Guid.Empty, 
                Jobs.ToArray()[0].Id, 
                Users.ToArray()[0].Id, 
                400, 
                "2 Hours", 
                DateTime.Now));
        
        return _offerService.List(Jobs.ToArray()[0].Id);
    }
}
